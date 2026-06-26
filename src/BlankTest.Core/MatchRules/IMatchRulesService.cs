namespace BlankTest.Core.MatchRules;

public interface IMatchRulesService
{
    Task<MatchRulesSnapshot> GetSnapshotAsync(CancellationToken cancellationToken = default);
}

public interface IMatchRuleNavigationService
{
    void NavigateTo(string route, Guid? matchRuleId = null);
}

public interface IMatchRuleExportService
{
    Task ExportAsync(IReadOnlyList<MatchRuleListItem> rows, CancellationToken cancellationToken = default);
}

public sealed class NullMatchRuleNavigationService : IMatchRuleNavigationService
{
    public string? LastRoute { get; private set; }
    public Guid? LastMatchRuleId { get; private set; }

    public void NavigateTo(string route, Guid? matchRuleId = null)
    {
        LastRoute = route;
        LastMatchRuleId = matchRuleId;
    }
}

public sealed class NullMatchRuleExportService : IMatchRuleExportService
{
    public int ExportCallCount { get; private set; }

    public Task ExportAsync(IReadOnlyList<MatchRuleListItem> rows, CancellationToken cancellationToken = default)
    {
        ExportCallCount++;
        return Task.CompletedTask;
    }
}
