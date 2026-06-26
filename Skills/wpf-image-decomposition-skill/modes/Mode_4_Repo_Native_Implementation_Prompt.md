# Mode 4 — Repo-Native Implementation Prompt

## Purpose

Generate a complete, copy-ready coding-agent prompt from a mock image plus repository/project context.

## Input

- Mock UI image.
- Repository name and base branch.
- Target view/feature.
- Optional implementation branch and PR title.
- Optional specification files, existing architecture notes, screenshots, or workflow instructions.

## Output

A complete implementation prompt for an AI coding agent.

## Required Output Template

1. Implementation Prompt Header
2. Role and Expertise Declaration
3. Repository Context
4. Source Inputs
5. Target Objective
6. Non-Negotiable Constraints
7. Existing Architecture Discovery Requirements
8. Mock Decomposition Summary
9. Required WPF Composition Architecture
10. Required Files and Suggested File Locations
11. Required View Structure
12. Required ViewModel Contract
13. Required Commands
14. Required Models / DTOs / Design-Time Data
15. Required ResourceDictionaries and Styles
16. Required Shared Components
17. Required DataGrid/List Specification
18. Required Details Panel Behaviour
19. Required Quick Actions Behaviour
20. Required Navigation Behaviour
21. Required Loading, Empty, Error, Disabled States
22. Required Accessibility
23. Testing Requirements
24. Build and CI Requirements
25. Visual Verification Checklist
26. Prohibited Changes
27. Final Deliverables
28. Pull Request Instructions
29. Fix Loop Instructions
30. Final Agent Checklist

## Mandatory Prompt Rules

- The prompt must stand alone.
- The prompt must instruct the agent to inspect the repository before editing.
- The prompt must prohibit broad rewrites.
- The prompt must preserve MVVM/SOLID boundaries.
- The prompt must require restore/build/test validation.
- The prompt must require final reporting of changed files, tests run, and known deviations.
- The prompt must say not to merge unless explicitly instructed.

## Implementation Prompt Skeleton

```text
IMPLEMENTATION PROMPT — WPF VIEW FROM MOCK IMAGE

You are an expert C#/.NET WPF implementation agent, MVVM/SOLID architect, XAML layout specialist, enterprise UI styling specialist, ResourceDictionary designer, accessibility reviewer, and GitHub PR workflow operator.

Your task is to implement the specified WPF view from the supplied mock UI image.

======================================================================
REPOSITORY
======================================================================

Repository:
[REPOSITORY_NAME]

Base branch:
[BASE_BRANCH]

Implementation branch:
[BRANCH_NAME]

Pull request title:
[PR_TITLE]

Target application:
[APPLICATION_NAME]

Target view:
[TARGET_VIEW_NAME]

Target feature:
[TARGET_FEATURE_NAME]

======================================================================
SOURCE INPUTS
======================================================================

Primary visual source:
[MOCK_IMAGE_FILENAME]

Additional context:
[PROJECT_CONTEXT_FILES_OR_NOTES]

Existing architecture:
Inspect the repository before implementation. Do not assume structure.

======================================================================
OBJECTIVE
======================================================================

Implement the target WPF view so that it closely matches the supplied mock image while preserving the existing application architecture.

The implementation must:
- follow MVVM
- preserve SOLID boundaries
- avoid code-behind business logic
- use reusable ResourceDictionary styles where appropriate
- compose the UI from shell, feature, and shared components
- bind state and commands through ViewModels
- support maintainable future extension

======================================================================
NON-NEGOTIABLE CONSTRAINTS
======================================================================

1. Do not implement unrelated features.
2. Do not rewrite the application shell unless required by the mock and existing architecture.
3. Do not introduce business logic into XAML code-behind.
4. Do not bypass existing services, navigation patterns, or DI patterns.
5. Do not hard-code production data access inside the view.
6. Do not remove existing tests.
7. Do not break existing navigation.
8. Do not introduce large monolithic XAML if reusable components already exist.
9. Do not create duplicate styles if equivalent styles already exist.
10. Do not change database schema unless explicitly requested.
11. Do not merge the PR unless explicitly instructed.

======================================================================
REPOSITORY DISCOVERY REQUIREMENTS
======================================================================

Before editing files:

1. Inspect solution and project structure.
2. Identify WPF project.
3. Identify existing Views, ViewModels, Services, Models, Resources, Styles, and DI registrations.
4. Identify current navigation pattern.
5. Identify existing shared controls.
6. Identify existing theme/resource dictionaries.
7. Identify existing DataGrid/table styling.
8. Identify existing command implementation pattern.
9. Identify existing test projects.
10. Identify whether design-time data exists.

Produce a short implementation plan before making changes.

======================================================================
REQUIRED WPF COMPOSITION ARCHITECTURE
======================================================================

Use this composition model unless the repository already has an equivalent structure:

Application Shell
 ├── TopBar
 ├── SideNavigation
 ├── ContentHost
 └── BottomStatusBar

Feature View
 ├── PageHeader
 ├── Toolbar
 ├── MetricCards
 ├── MainGrid/List
 ├── DetailsPanel
 └── QuickActions

Shared Components
 ├── MetricCard
 ├── QuickActionCard
 ├── StatusBadge
 ├── SearchBox
 ├── IconButton
 ├── PrimaryButton
 ├── SecondaryButton
 ├── DetailFieldRow
 └── EnterpriseDataGrid styles/templates

======================================================================
REQUIRED VIEWMODEL CONTRACT
======================================================================

Create or extend the relevant ViewModel with observable state equivalent to:

- SearchText
- SelectedStatusFilter
- StatusFilters
- Items
- FilteredItems or paged result collection
- SelectedItem
- TotalCount
- ActiveCount
- InactiveCount
- InUseCount
- RowsPerPage
- AvailableRowsPerPage
- CurrentPage
- TotalPages
- IsBusy
- ErrorMessage
- StatusMessage
- LastRefreshDisplay

Selection behaviour:
- selecting a row updates SelectedItem
- details panel binds to SelectedItem
- edit/view buttons are disabled when SelectedItem is null

======================================================================
REQUIRED COMMANDS
======================================================================

Implement or bind commands appropriate to the mock:

- RefreshCommand
- ExportCommand
- CreateCommand
- EditCommand
- ViewDetailsCommand
- ViewMappingsCommand
- ManageRelatedEntitiesCommand
- TestLogicCommand
- ChangePageCommand
- ChangeRowsPerPageCommand
- OpenRowActionsCommand
- ClearSearchCommand

Commands must expose CanExecute where appropriate and avoid blocking the UI thread.

======================================================================
TESTING, BUILD, AND PR REQUIREMENTS
======================================================================

Add/update tests for ViewModel state, filtering, selection, command CanExecute, pagination, loading/error state, and any new reusable component mapping logic.

Run restore/build/test. Fix failures. Create a PR if requested. Do not merge unless explicitly instructed.

Final response must include:
- files changed
- architectural decisions
- tests run
- build/test result
- known deviations from the mock
```
