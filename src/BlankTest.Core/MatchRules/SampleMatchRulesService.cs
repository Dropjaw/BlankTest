namespace BlankTest.Core.MatchRules;

public sealed class SampleMatchRulesService : IMatchRulesService
{
    public Task<MatchRulesSnapshot> GetSnapshotAsync(CancellationToken cancellationToken = default)
    {
        var rules = new List<MatchRuleListItem>
        {
            Create("Vendor Invoice Subject Match", "Matches vendor invoice-related subjects and routes them for accounts payable processing", "FinanceApp", "Accounts Payable", "Subject", "High", true, "Vendor Invoice", 8, new DateTimeOffset(2025, 5, 20, 9, 41, 0, TimeSpan.Zero), true),
            Create("Approved Vendor Sender", "Routes emails from approved vendor sender addresses.", "FinanceApp", "Accounts Payable", "Sender", "High", true, "Vendor Invoice", 5, new DateTimeOffset(2025, 5, 20, 9, 15, 0, TimeSpan.Zero), true),
            Create("Invoice Attachment Present", "Identifies invoice messages that include a required attachment.", "FinanceApp", "Accounts Payable", "Content", "Medium", true, "Vendor Invoice", 3, new DateTimeOffset(2025, 5, 19, 16, 22, 0, TimeSpan.Zero), true),
            Create("Payment Reminder Keywords", "Matches payment reminder subject keywords.", "FinanceApp", "Accounts Receivable", "Subject", "Medium", true, "Payment Reminder", 2, new DateTimeOffset(2025, 5, 18, 11, 3, 0, TimeSpan.Zero), true),
            Create("HR Onboarding Sender", "Matches onboarding emails from HR systems.", "HRApp", "Employee Services", "Sender", "Low", false, "Onboarding", 1, new DateTimeOffset(2025, 5, 18, 9, 27, 0, TimeSpan.Zero), false),
            Create("Supplier Inquiry Route", "Routes supplier inquiry subjects to vendor management.", "ProcurementApp", "Vendor Management", "Subject", "Medium", true, "Supplier Inquiry", 4, new DateTimeOffset(2025, 5, 17, 14, 11, 0, TimeSpan.Zero), true)
        };

        var snapshot = new MatchRulesSnapshot(
            rules,
            TotalMatchRules: 186,
            ActiveMatchRules: 172,
            InactiveMatchRules: 14,
            RulesInUse: 158,
            LastRefresh: new DateTimeOffset(2025, 5, 20, 10, 52, 22, TimeSpan.Zero));

        return Task.FromResult(snapshot);
    }

    private static MatchRuleListItem Create(
        string ruleName,
        string description,
        string application,
        string module,
        string matchType,
        string priority,
        bool active,
        string emailType,
        int mappings,
        DateTimeOffset lastUpdated,
        bool inUse)
    {
        return new MatchRuleListItem(Guid.NewGuid(), ruleName, description, application, module, matchType, priority, active, emailType, mappings, lastUpdated, "Admin", inUse);
    }
}
