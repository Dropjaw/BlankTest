using System.Collections.ObjectModel;
using BlankTest.Core.Presentation;

namespace BlankTest.Core.MatchRules;

public sealed class MatchRulesViewModel : ObservableObject
{
    private readonly IMatchRulesService _service;
    private readonly IMatchRuleNavigationService _navigation;
    private readonly IMatchRuleExportService _exportService;
    private readonly List<MatchRuleListItem> _allRules = new();
    private string _searchText = string.Empty;
    private StatusFilterOption _selectedStatusFilter;
    private MatchRuleListItem? _selectedMatchRule;
    private int _totalMatchRules;
    private int _activeMatchRules;
    private int _inactiveMatchRules;
    private int _rulesInUse;
    private int _currentPage = 1;
    private int _totalPages = 1;
    private int _rowsPerPage = 10;
    private bool _isBusy;
    private bool _isRefreshing;
    private bool _hasError;
    private string? _errorMessage;
    private DateTimeOffset? _lastRefreshUtc;
    private bool _hasNoRules;
    private bool _hasNoFilteredResults;

    public MatchRulesViewModel(IMatchRulesService service, IMatchRuleNavigationService? navigation = null, IMatchRuleExportService? exportService = null)
    {
        _service = service;
        _navigation = navigation ?? new NullMatchRuleNavigationService();
        _exportService = exportService ?? new NullMatchRuleExportService();
        StatusFilters = new ObservableCollection<StatusFilterOption> { new("All Statuses", MatchRuleStatusFilter.All), new("Active", MatchRuleStatusFilter.Active), new("Inactive", MatchRuleStatusFilter.Inactive) };
        _selectedStatusFilter = StatusFilters[0];
        MatchRules = new ObservableCollection<MatchRuleListItem>();
        PagedMatchRules = new ObservableCollection<MatchRuleListItem>();
        MetricCards = new ObservableCollection<MetricCardItem>();
        QuickActions = new ObservableCollection<QuickActionItem> { new("Manage Email Types", "Create and organize email types used by match rules for classification.", "✉", "EmailTypes"), new("Open Recipient Mappings", "Review and manage routing mappings connected to these rules.", "👥", "RecipientMappings"), new("Test Match Logic", "Simulate and validate rule behavior with sample emails.", "◎", "TestMatch") };
        RowsPerPageOptions = new ObservableCollection<int> { 10, 25, 50 };
        PaginationItems = new ObservableCollection<PaginationItem>();
        LoadCommand = new AsyncRelayCommand(LoadAsync, () => !IsBusy);
        RefreshCommand = new AsyncRelayCommand(RefreshAsync, () => !IsBusy);
        SearchCommand = new RelayCommand(ApplyFilters);
        ClearSearchCommand = new RelayCommand(() => SearchText = string.Empty);
        ApplyStatusFilterCommand = new RelayCommand(ApplyFilters);
        ExportCommand = new AsyncRelayCommand(ExportAsync, () => CanExport);
        CreateMatchRuleCommand = new RelayCommand(() => _navigation.NavigateTo("CreateMatchRule"), () => CanCreateMatchRule);
        EditSelectedRuleCommand = new RelayCommand(() => _navigation.NavigateTo("EditMatchRule", SelectedMatchRule?.Id), () => CanEditSelectedRule);
        ViewMappingsCommand = new RelayCommand(() => _navigation.NavigateTo("RecipientMappings", SelectedMatchRule?.Id), () => CanViewMappings);
        OpenRuleActionsCommand = new RelayCommand(parameter => SelectedMatchRule = parameter as MatchRuleListItem);
        ChangeRowsPerPageCommand = new RelayCommand(parameter => ChangeRowsPerPage(parameter));
        ChangePageCommand = new RelayCommand(parameter => ChangePage(parameter));
        GoToPreviousPageCommand = new RelayCommand(() => CurrentPage--, () => CanGoPrevious);
        GoToNextPageCommand = new RelayCommand(() => CurrentPage++, () => CanGoNext);
        ManageEmailTypesCommand = new RelayCommand(() => _navigation.NavigateTo("EmailTypes"));
        OpenRecipientMappingsCommand = new RelayCommand(() => _navigation.NavigateTo("RecipientMappings"));
        TestMatchLogicCommand = new RelayCommand(() => _navigation.NavigateTo("TestMatch"));
        OpenQuickActionCommand = new RelayCommand(parameter => { if (parameter is QuickActionItem item) _navigation.NavigateTo(item.Route); });
    }

    public string PageTitle => "Match Rules";
    public string PageSubtitle => "Create, edit, and manage rule definitions used to classify emails and trigger routing behavior.";
    public ObservableCollection<StatusFilterOption> StatusFilters { get; }
    public ObservableCollection<MatchRuleListItem> MatchRules { get; }
    public ObservableCollection<MatchRuleListItem> PagedMatchRules { get; }
    public ObservableCollection<MetricCardItem> MetricCards { get; }
    public ObservableCollection<QuickActionItem> QuickActions { get; }
    public ObservableCollection<int> RowsPerPageOptions { get; }
    public ObservableCollection<PaginationItem> PaginationItems { get; }
    public AsyncRelayCommand LoadCommand { get; }
    public AsyncRelayCommand RefreshCommand { get; }
    public RelayCommand SearchCommand { get; }
    public RelayCommand ClearSearchCommand { get; }
    public RelayCommand ApplyStatusFilterCommand { get; }
    public AsyncRelayCommand ExportCommand { get; }
    public RelayCommand CreateMatchRuleCommand { get; }
    public RelayCommand EditSelectedRuleCommand { get; }
    public RelayCommand ViewMappingsCommand { get; }
    public RelayCommand OpenRuleActionsCommand { get; }
    public RelayCommand ChangeRowsPerPageCommand { get; }
    public RelayCommand ChangePageCommand { get; }
    public RelayCommand GoToPreviousPageCommand { get; }
    public RelayCommand GoToNextPageCommand { get; }
    public RelayCommand ManageEmailTypesCommand { get; }
    public RelayCommand OpenRecipientMappingsCommand { get; }
    public RelayCommand TestMatchLogicCommand { get; }
    public RelayCommand OpenQuickActionCommand { get; }

    public string SearchText { get => _searchText; set { if (SetProperty(ref _searchText, value)) { CurrentPage = 1; ApplyFilters(); } } }
    public StatusFilterOption SelectedStatusFilter { get => _selectedStatusFilter; set { if (SetProperty(ref _selectedStatusFilter, value)) { CurrentPage = 1; ApplyFilters(); } } }
    public MatchRuleListItem? SelectedMatchRule { get => _selectedMatchRule; set { if (SetProperty(ref _selectedMatchRule, value)) { OnPropertyChanged(nameof(HasSelectedRule)); OnPropertyChanged(nameof(CanEditSelectedRule)); OnPropertyChanged(nameof(CanViewMappings)); RaiseCommandStates(); } } }
    public int TotalMatchRules { get => _totalMatchRules; private set { if (SetProperty(ref _totalMatchRules, value)) UpdateMetrics(); } }
    public int ActiveMatchRules { get => _activeMatchRules; private set { if (SetProperty(ref _activeMatchRules, value)) UpdateMetrics(); } }
    public int InactiveMatchRules { get => _inactiveMatchRules; private set { if (SetProperty(ref _inactiveMatchRules, value)) UpdateMetrics(); } }
    public int RulesInUse { get => _rulesInUse; private set { if (SetProperty(ref _rulesInUse, value)) UpdateMetrics(); } }
    public int CurrentPage { get => _currentPage; set { var normalized = Math.Clamp(value, 1, Math.Max(1, TotalPages)); if (SetProperty(ref _currentPage, normalized)) RefreshPage(); } }
    public int TotalPages { get => _totalPages; private set => SetProperty(ref _totalPages, Math.Max(1, value)); }
    public int RowsPerPage { get => _rowsPerPage; set { if (SetProperty(ref _rowsPerPage, value)) { CurrentPage = 1; ApplyFilters(); } } }
    public bool IsBusy { get => _isBusy; private set { if (SetProperty(ref _isBusy, value)) RaiseCommandStates(); } }
    public bool IsRefreshing { get => _isRefreshing; private set => SetProperty(ref _isRefreshing, value); }
    public bool HasError { get => _hasError; private set => SetProperty(ref _hasError, value); }
    public string? ErrorMessage { get => _errorMessage; private set => SetProperty(ref _errorMessage, value); }
    public DateTimeOffset? LastRefreshUtc { get => _lastRefreshUtc; private set { if (SetProperty(ref _lastRefreshUtc, value)) OnPropertyChanged(nameof(LastRefreshDisplay)); } }
    public string LastRefreshDisplay => LastRefreshUtc?.ToLocalTime().ToString("M/d/yyyy h:mm:ss tt") ?? "Never";
    public bool HasSelectedRule => SelectedMatchRule is not null;
    public bool CanCreateMatchRule => !IsBusy;
    public bool CanEditSelectedRule => !IsBusy && SelectedMatchRule is not null;
    public bool CanExport => !IsBusy && MatchRules.Count > 0;
    public bool CanViewMappings => !IsBusy && SelectedMatchRule is not null;
    public bool CanGoPrevious => CurrentPage > 1;
    public bool CanGoNext => CurrentPage < TotalPages;
    public bool HasNoRules { get => _hasNoRules; private set => SetProperty(ref _hasNoRules, value); }
    public bool HasNoFilteredResults { get => _hasNoFilteredResults; private set => SetProperty(ref _hasNoFilteredResults, value); }
    public string PageSummaryText { get { var total = GetPagingTotalCount(); if (MatchRules.Count == 0 || PagedMatchRules.Count == 0) return $"Showing 0 of {total} match rules"; var start = ((CurrentPage - 1) * RowsPerPage) + 1; var end = start + PagedMatchRules.Count - 1; return $"Showing {start} to {end} of {total} match rules"; } }

    public async Task LoadAsync() => await LoadInternalAsync(false).ConfigureAwait(true);
    public async Task RefreshAsync() => await LoadInternalAsync(true).ConfigureAwait(true);

    private async Task LoadInternalAsync(bool refreshing)
    {
        IsBusy = true; IsRefreshing = refreshing; HasError = false; ErrorMessage = null;
        var selectedId = SelectedMatchRule?.Id;
        try
        {
            var snapshot = await _service.GetSnapshotAsync().ConfigureAwait(true);
            _allRules.Clear(); _allRules.AddRange(snapshot.Rules);
            TotalMatchRules = snapshot.TotalMatchRules; ActiveMatchRules = snapshot.ActiveMatchRules; InactiveMatchRules = snapshot.InactiveMatchRules; RulesInUse = snapshot.RulesInUse; LastRefreshUtc = snapshot.LastRefresh;
            ApplyFilters();
            SelectedMatchRule = MatchRules.FirstOrDefault(x => x.Id == selectedId) ?? PagedMatchRules.FirstOrDefault();
        }
        catch (Exception ex) { HasError = true; ErrorMessage = ex.Message; }
        finally { IsRefreshing = false; IsBusy = false; }
    }

    private async Task ExportAsync() => await _exportService.ExportAsync(MatchRules.ToList()).ConfigureAwait(true);

    private void ApplyFilters()
    {
        var query = SearchText.Trim();
        IEnumerable<MatchRuleListItem> rules = _allRules;
        if (SelectedStatusFilter.Value == MatchRuleStatusFilter.Active) rules = rules.Where(x => x.IsActive);
        else if (SelectedStatusFilter.Value == MatchRuleStatusFilter.Inactive) rules = rules.Where(x => !x.IsActive);
        if (!string.IsNullOrWhiteSpace(query)) rules = rules.Where(x => x.RuleName.Contains(query, StringComparison.OrdinalIgnoreCase) || x.ApplicationName.Contains(query, StringComparison.OrdinalIgnoreCase) || x.ModuleName.Contains(query, StringComparison.OrdinalIgnoreCase) || x.MatchType.Contains(query, StringComparison.OrdinalIgnoreCase));
        MatchRules.Clear(); foreach (var rule in rules) MatchRules.Add(rule);
        HasNoRules = _allRules.Count == 0; HasNoFilteredResults = _allRules.Count > 0 && MatchRules.Count == 0;
        TotalPages = (int)Math.Ceiling((double)Math.Max(1, GetPagingTotalCount()) / RowsPerPage);
        if (CurrentPage > TotalPages) { _currentPage = TotalPages; OnPropertyChanged(nameof(CurrentPage)); }
        RefreshPage();
    }

    private int GetPagingTotalCount()
    {
        var isUnfiltered = string.IsNullOrWhiteSpace(SearchText) && SelectedStatusFilter.Value == MatchRuleStatusFilter.All && _allRules.Count > 0;
        return isUnfiltered ? TotalMatchRules : MatchRules.Count;
    }

    private void RefreshPage()
    {
        PagedMatchRules.Clear(); foreach (var rule in MatchRules.Skip((CurrentPage - 1) * RowsPerPage).Take(RowsPerPage)) PagedMatchRules.Add(rule);
        if (SelectedMatchRule is not null && !MatchRules.Any(x => x.Id == SelectedMatchRule.Id)) SelectedMatchRule = PagedMatchRules.FirstOrDefault();
        UpdatePaginationItems(); OnPropertyChanged(nameof(PageSummaryText)); OnPropertyChanged(nameof(CanGoPrevious)); OnPropertyChanged(nameof(CanGoNext)); RaiseCommandStates();
    }

    private void UpdateMetrics()
    {
        MetricCards.Clear(); MetricCards.Add(new MetricCardItem("Total Match Rules", TotalMatchRules.ToString(), "☰", "Primary")); MetricCards.Add(new MetricCardItem("Active", ActiveMatchRules.ToString(), "✓", "Success")); MetricCards.Add(new MetricCardItem("Inactive", InactiveMatchRules.ToString(), "⊘", "Danger")); MetricCards.Add(new MetricCardItem("Rules In Use", RulesInUse.ToString(), "▤", "Primary"));
    }

    private void UpdatePaginationItems()
    {
        PaginationItems.Clear();
        if (TotalPages <= 7) { for (var page = 1; page <= TotalPages; page++) PaginationItems.Add(new PaginationItem(page, page.ToString(), page == CurrentPage, false)); return; }
        PaginationItems.Add(new PaginationItem(1, "1", CurrentPage == 1, false)); PaginationItems.Add(new PaginationItem(2, "2", CurrentPage == 2, false)); PaginationItems.Add(new PaginationItem(3, "3", CurrentPage == 3, false)); PaginationItems.Add(new PaginationItem(null, "...", false, true)); PaginationItems.Add(new PaginationItem(TotalPages, TotalPages.ToString(), CurrentPage == TotalPages, false));
    }

    private void ChangeRowsPerPage(object? parameter) { if (parameter is int value) RowsPerPage = value; else if (parameter is string text && int.TryParse(text, out var parsed)) RowsPerPage = parsed; }
    private void ChangePage(object? parameter) { if (parameter is PaginationItem { PageNumber: not null, IsEllipsis: false } item) CurrentPage = item.PageNumber.Value; else if (parameter is int value) CurrentPage = value; }
    private void RaiseCommandStates()
    {
        LoadCommand.RaiseCanExecuteChanged(); RefreshCommand.RaiseCanExecuteChanged(); ExportCommand.RaiseCanExecuteChanged(); CreateMatchRuleCommand.RaiseCanExecuteChanged(); EditSelectedRuleCommand.RaiseCanExecuteChanged(); ViewMappingsCommand.RaiseCanExecuteChanged(); GoToPreviousPageCommand.RaiseCanExecuteChanged(); GoToNextPageCommand.RaiseCanExecuteChanged();
        OnPropertyChanged(nameof(CanCreateMatchRule)); OnPropertyChanged(nameof(CanEditSelectedRule)); OnPropertyChanged(nameof(CanExport)); OnPropertyChanged(nameof(CanViewMappings));
    }
}
