namespace BlankTest.Core.MatchRules;

public enum MatchRuleStatusFilter
{
    All,
    Active,
    Inactive
}

public sealed record MatchRuleListItem(
    Guid Id,
    string RuleName,
    string Description,
    string ApplicationName,
    string ModuleName,
    string MatchType,
    string Priority,
    bool IsActive,
    string EmailTypeName,
    int RecipientMappingCount,
    DateTimeOffset LastUpdated,
    string UpdatedBy,
    bool IsInUse)
{
    public string Status => IsActive ? "Active" : "Inactive";
    public string LastUpdatedDisplay => LastUpdated.ToLocalTime().ToString("MM/dd/yyyy hh:mm tt");
}

public sealed record MetricCardItem(string Title, string Value, string Icon, string Semantic);
public sealed record QuickActionItem(string Title, string Description, string Icon, string Route);
public sealed record StatusFilterOption(string DisplayName, MatchRuleStatusFilter Value);
public sealed record PaginationItem(int? PageNumber, string DisplayText, bool IsSelected, bool IsEllipsis);
public sealed record MatchRulesSnapshot(
    IReadOnlyList<MatchRuleListItem> Rules,
    int TotalMatchRules,
    int ActiveMatchRules,
    int InactiveMatchRules,
    int RulesInUse,
    DateTimeOffset LastRefresh);
