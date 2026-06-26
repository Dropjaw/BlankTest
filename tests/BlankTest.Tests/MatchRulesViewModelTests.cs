using BlankTest.Core.MatchRules;
using Xunit;

namespace BlankTest.Tests;

public sealed class MatchRulesViewModelTests
{
    [Fact]
    public async Task InitialLoadPopulatesRowsAndMetrics()
    {
        var vm = CreateViewModel();
        await vm.LoadAsync();
        Assert.Equal(6, vm.MatchRules.Count);
        Assert.Equal(186, vm.TotalMatchRules);
        Assert.Equal(172, vm.ActiveMatchRules);
        Assert.Equal(14, vm.InactiveMatchRules);
        Assert.Equal(158, vm.RulesInUse);
        Assert.NotEmpty(vm.MetricCards);
    }

    [Fact]
    public async Task SearchFiltersRowsAndResetsPage()
    {
        var vm = CreateViewModel();
        await vm.LoadAsync();
        vm.RowsPerPage = 1;
        vm.CurrentPage = 2;
        vm.SearchText = "HR";
        Assert.Equal(1, vm.CurrentPage);
        Assert.Single(vm.MatchRules);
        Assert.Equal("HR Onboarding Sender", vm.MatchRules[0].RuleName);
    }

    [Fact]
    public async Task StatusFilterFiltersInactiveRows()
    {
        var vm = CreateViewModel();
        await vm.LoadAsync();
        vm.SelectedStatusFilter = vm.StatusFilters.Single(x => x.Value == MatchRuleStatusFilter.Inactive);
        Assert.Single(vm.MatchRules);
        Assert.False(vm.MatchRules[0].IsActive);
    }

    [Fact]
    public async Task SelectionUpdatesSelectedRuleAndCommandState()
    {
        var vm = CreateViewModel();
        await vm.LoadAsync();
        vm.SelectedMatchRule = null;
        Assert.False(vm.HasSelectedRule);
        Assert.False(vm.EditSelectedRuleCommand.CanExecute(null));
        Assert.False(vm.ViewMappingsCommand.CanExecute(null));
        vm.SelectedMatchRule = vm.PagedMatchRules[0];
        Assert.True(vm.HasSelectedRule);
        Assert.True(vm.EditSelectedRuleCommand.CanExecute(null));
        Assert.True(vm.ViewMappingsCommand.CanExecute(null));
    }

    [Fact]
    public async Task ExportCommandIsFalseWhenNoRowsExist()
    {
        var vm = CreateViewModel(new EmptyMatchRulesService());
        await vm.LoadAsync();
        Assert.False(vm.ExportCommand.CanExecute(null));
        Assert.True(vm.HasNoRules);
    }

    [Fact]
    public async Task PaginationUpdatesCurrentPageAndSummary()
    {
        var vm = CreateViewModel();
        await vm.LoadAsync();
        vm.RowsPerPage = 2;
        vm.CurrentPage = 2;
        Assert.Equal(2, vm.CurrentPage);
        Assert.Equal(2, vm.PagedMatchRules.Count);
        Assert.Contains("Showing 3 to 4", vm.PageSummaryText);
    }

    [Fact]
    public async Task RowsPerPageChangeRecalculatesTotalPages()
    {
        var vm = CreateViewModel();
        await vm.LoadAsync();
        vm.RowsPerPage = 3;
        Assert.Equal(62, vm.TotalPages);
        Assert.Equal(1, vm.CurrentPage);
    }

    [Fact]
    public async Task RefreshUpdatesLastRefreshDisplay()
    {
        var vm = CreateViewModel();
        await vm.RefreshAsync();
        Assert.False(string.IsNullOrWhiteSpace(vm.LastRefreshDisplay));
        Assert.NotEqual("Never", vm.LastRefreshDisplay);
    }

    [Fact]
    public async Task FilteredEmptyStateIsSetWhenSearchHasNoMatches()
    {
        var vm = CreateViewModel();
        await vm.LoadAsync();
        vm.SearchText = "does-not-exist";
        Assert.True(vm.HasNoFilteredResults);
        Assert.Empty(vm.MatchRules);
    }

    [Fact]
    public async Task ErrorStateIsSurfacedWhenLoadFails()
    {
        var vm = CreateViewModel(new FailingMatchRulesService());
        await vm.LoadAsync();
        Assert.True(vm.HasError);
        Assert.Contains("load failed", vm.ErrorMessage);
    }

    [Fact]
    public async Task QuickActionCommandsNavigateToExpectedRoutes()
    {
        var navigation = new RecordingNavigationService();
        var vm = CreateViewModel(navigation: navigation);
        await vm.LoadAsync();
        vm.ManageEmailTypesCommand.Execute(null);
        Assert.Equal("EmailTypes", navigation.LastRoute);
        vm.OpenRecipientMappingsCommand.Execute(null);
        Assert.Equal("RecipientMappings", navigation.LastRoute);
        vm.TestMatchLogicCommand.Execute(null);
        Assert.Equal("TestMatch", navigation.LastRoute);
    }

    [Fact]
    public async Task ViewMappingsPassesSelectedRuleIdentifier()
    {
        var navigation = new RecordingNavigationService();
        var vm = CreateViewModel(navigation: navigation);
        await vm.LoadAsync();
        vm.ViewMappingsCommand.Execute(null);
        Assert.Equal("RecipientMappings", navigation.LastRoute);
        Assert.Equal(vm.SelectedMatchRule!.Id, navigation.LastMatchRuleId);
    }

    private static MatchRulesViewModel CreateViewModel(IMatchRulesService? service = null, IMatchRuleNavigationService? navigation = null)
    {
        return new MatchRulesViewModel(service ?? new SampleMatchRulesService(), navigation ?? new RecordingNavigationService(), new NullMatchRuleExportService());
    }

    private sealed class RecordingNavigationService : IMatchRuleNavigationService
    {
        public string? LastRoute { get; private set; }
        public Guid? LastMatchRuleId { get; private set; }
        public void NavigateTo(string route, Guid? matchRuleId = null) { LastRoute = route; LastMatchRuleId = matchRuleId; }
    }

    private sealed class EmptyMatchRulesService : IMatchRulesService
    {
        public Task<MatchRulesSnapshot> GetSnapshotAsync(CancellationToken cancellationToken = default) => Task.FromResult(new MatchRulesSnapshot(Array.Empty<MatchRuleListItem>(), 0, 0, 0, 0, DateTimeOffset.UtcNow));
    }

    private sealed class FailingMatchRulesService : IMatchRulesService
    {
        public Task<MatchRulesSnapshot> GetSnapshotAsync(CancellationToken cancellationToken = default) => throw new InvalidOperationException("load failed");
    }
}
