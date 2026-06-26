# Shared Skill — MVVM Contract Builder

## Purpose

Infer ViewModel properties and commands from a mock UI image.

## Output Sections

1. ViewModel Responsibilities
2. Observable Properties
3. Collections
4. Selected State
5. Commands
6. Derived Properties
7. Validation and Error Properties
8. Service Dependencies
9. Testing Targets

## ViewModel Responsibilities

Describe:
- data loading
- filtering
- searching
- selection
- pagination
- command state
- details panel state
- refresh/status state
- navigation action state

## Observable Properties

Use a table:

| Property | Type | Bound From | Purpose |
|---|---|---|---|

Typical properties:
- SearchText
- SelectedStatusFilter
- SelectedItem
- IsBusy
- ErrorMessage
- StatusMessage
- LastRefreshDisplay
- RowsPerPage
- CurrentPage
- TotalPages

## Collections

Include:
- main item collection
- filtered collection
- paged collection
- metric cards collection
- quick actions collection
- status filters
- rows-per-page options

## Selected State

Include:
- SelectedItem
- HasSelectedItem
- SelectedItemDetails
- selected row visual state
- details panel binding

## Commands

Use a table:

| Command | Source Control | CanExecute | Async | Expected Effect |
|---|---|---|---|---|

Typical commands:
- RefreshCommand
- ExportCommand
- CreateCommand
- EditCommand
- ViewDetailsCommand
- OpenRowActionsCommand
- ChangePageCommand
- ChangeRowsPerPageCommand
- NavigateCommand

## Derived Properties

Include:
- HasItems
- HasFilteredResults
- IsEmpty
- IsNoResults
- CanGoNextPage
- CanGoPreviousPage
- PageRangeText
- LastRefreshDisplay

## Validation and Error Properties

Include:
- IsBusy
- ErrorMessage
- HasError
- StatusMessage
- ValidationErrors
