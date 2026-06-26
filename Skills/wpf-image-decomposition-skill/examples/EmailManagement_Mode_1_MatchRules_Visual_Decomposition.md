# Example — EmailManagement Match Rules Decomposition

## 1. Mock Overview

The mock shows an `EmailManagement` enterprise WPF management screen for `Match Rules`. The screen uses a fixed left navigation rail, top application bar, bottom status bar, page header, toolbar/search row, summary metric cards, central match rule table, right-side details inspector, and quick action cards.

Primary entity: Match Rule.

Primary workflows:
- search/filter match rules
- create a new match rule
- export match rules
- select a rule
- inspect selected rule details
- edit selected rule
- view mappings for selected rule
- navigate to related workflows

## 2. Layout Zone Decomposition

| Zone | Position | Approximate Behaviour | Purpose | WPF Construct | Ownership |
|---|---|---|---|---|---|
| Top Bar | top, full width | fixed height | account/options/help/window controls | Grid/DockPanel | Shell |
| Left Navigation | left | fixed width around 250px | feature navigation | ListBox/ItemsControl | Shell |
| Page Header | main top | auto height | title/subtitle | Grid | Feature |
| Toolbar | main top right | auto height | search/filter/export/create | Grid | Feature |
| Metric Cards | below header | four cards, equal width | summary counts | ItemsControl/UniformGrid | Feature/Shared |
| Match Rule List | main left | fills available height | primary data table | DataGrid in Card Border | Feature |
| Details Panel | main right | fixed width around 360-400px | selected rule inspector | Border/UserControl | Feature |
| Quick Actions | lower left | three cards | related navigation | ItemsControl | Feature/Shared |
| Bottom Status Bar | bottom, full width | fixed height | connection/environment/refresh | Grid/DockPanel | Shell |

## 3. Recommended Components

Shell:
- AppShellView
- TopBarView
- SideNavigationView
- BottomStatusBarView

Feature:
- MatchRulesView
- MatchRulesHeaderView
- MatchRulesMetricsView
- MatchRulesGridView
- MatchRuleDetailsPanelView
- MatchRulesQuickActionsView

Shared:
- MetricCardControl
- QuickActionCardControl
- StatusBadgeControl
- DetailFieldRowControl
- EnterpriseDataGrid styles/templates

## 4. ViewModel Contract

Observable properties:
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

Commands:
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

## 5. DataGrid Columns

- Rule Name
- Application
- Module
- Match Type
- Priority
- Status
- Last Updated
- Updated By
- Actions

Status should use `StatusBadgeControl` or equivalent DataTemplate.

## 6. Details Panel Fields

- RuleName
- Description
- ApplicationName
- ModuleName
- MatchType
- Priority
- StatusDisplay
- EmailTypeName
- RecipientMappingCount
- LastUpdatedDisplay

Actions:
- Edit
- View Mappings

Empty state:
- “Select a match rule to view details.”

## 7. Visual Priorities

Highest fidelity targets:
1. Shell proportions.
2. Two-column table/details layout.
3. Card-based summary/list/details/quick-action structure.
4. Blue/white enterprise theme.
5. Active nav and selected row states.
6. Status badges.
7. Bottom status bar.
