# Example — EmailManagement Match Rules Implementation Prompt

```text
IMPLEMENTATION PROMPT — EMAILMANAGEMENT MATCH RULES WPF VIEW

You are an expert C#/.NET WPF implementation agent, MVVM/SOLID architect, XAML layout specialist, enterprise UI styling specialist, ResourceDictionary designer, accessibility reviewer, and GitHub PR workflow operator.

Repository:
EmailManagement

Base branch:
master

Implementation branch:
phase-7-4-match-rules-wpf-ui

Pull request title:
Phase 7.4 - Match Rules WPF UI

Target view:
Match Rules

Primary visual source:
Email Management - Match Rules View.png

Objective:
Implement the Match Rules WPF view so it closely matches the supplied mock image while preserving existing MVVM/SOLID architecture.

Required layout:
- fixed left navigation rail
- top shell bar
- bottom status bar
- page title/subtitle
- search/status/export/new toolbar
- four metric cards
- main Match Rule List card
- right-side Match Rule Details card
- lower Quick Actions card row

Required ViewModel properties:
- SearchText
- SelectedStatusFilter
- StatusFilters
- MatchRules
- SelectedMatchRule
- TotalMatchRules
- ActiveMatchRules
- InactiveMatchRules
- RulesInUse
- RowsPerPage
- CurrentPage
- TotalPages
- PageRangeText
- IsBusy
- StatusMessage
- LastRefreshDisplay

Required commands:
- RefreshCommand
- ExportCommand
- CreateMatchRuleCommand
- EditMatchRuleCommand
- ViewMappingsCommand
- ManageEmailTypesCommand
- OpenRecipientMappingsCommand
- TestMatchLogicCommand
- ChangePageCommand
- ChangeRowsPerPageCommand
- OpenRowActionsCommand

Required DataGrid columns:
- Rule Name
- Application
- Module
- Match Type
- Priority
- Status
- Last Updated
- Updated By
- Actions

Required details panel:
- icon
- selected rule title
- description
- application
- module
- match type
- priority
- status badge
- email type
- recipient mappings count
- last updated
- Edit button
- View Mappings button

Constraints:
- preserve MVVM
- avoid code-behind business logic
- reuse existing styles/resources where possible
- do not rewrite unrelated screens
- do not change database schema
- do not merge unless explicitly instructed

Testing:
- add/update ViewModel tests for filtering, selection, command CanExecute, pagination, loading/error state
- run restore/build/test
- fix all failures

Final response:
- files changed
- architecture decisions
- tests run
- build/test status
- known deviations from mock
```
