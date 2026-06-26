# Mode 1 — Visual Decomposition

## Purpose

Convert a mock UI image into a structured WPF/MVVM design specification. This mode produces engineering guidance, not implementation code.

## Input

- One or more mock UI images.
- Optional target application/view name.

## Output

A structured WPF design specification with layout, tokens, controls, bindings, commands, states, risks, and implementation boundaries.

## Required Output Template

1. Mock Overview
2. Application Shell Analysis
3. Layout Zone Decomposition
4. Visual Hierarchy
5. Design Token Extraction
6. Typography Analysis
7. Colour System Approximation
8. Spacing and Density Analysis
9. Shape, Borders, Radius, and Elevation
10. Control Inventory
11. WPF Layout Strategy
12. Component Decomposition
13. ResourceDictionary Plan
14. MVVM Binding Contract
15. Command and Interaction Contract
16. Data Display Specification
17. Details Panel / Inspector Specification
18. Navigation and Routing Implications
19. State Management Requirements
20. Empty, Loading, Error, and Disabled States
21. Responsive and Scaling Behaviour
22. Accessibility Requirements
23. Implementation Boundaries
24. Risks, Ambiguities, and Required Clarifications
25. Final WPF Design Specification Summary

## Section Requirements

### 1. Mock Overview

Identify:
- application name
- screen/view name
- primary feature
- main entity
- visible workflow
- apparent user role/context
- dominant visual style
- dominant layout pattern

### 2. Application Shell Analysis

Identify:
- top app bar
- title bar/window chrome
- user/account area
- help/options controls
- left navigation rail
- bottom status bar
- content host
- active navigation state

For each, state whether it should be shell-level, feature-level, or shared.

### 3. Layout Zone Decomposition

Use a table:

| Zone | Position | Approximate Behaviour | Purpose | WPF Construct | Ownership |
|---|---|---|---|---|---|

Include all major regions visible in the image.

### 4. Visual Hierarchy

Explain:
- first visual focus
- strongest action
- secondary content
- selected/active item emphasis
- information density

### 5. Design Token Extraction

Extract approximate tokens:
- colours
- typography
- spacing
- shape
- borders
- elevation
- icon sizing
- button sizing
- table density

State explicitly that exact colours are approximate unless sampled.

### 6. Typography Analysis

Recommend WPF text styles:
- PageTitleTextStyle
- SectionTitleTextStyle
- BodyTextStyle
- CaptionTextStyle
- TableHeaderTextStyle
- TableCellTextStyle
- MetricValueTextStyle
- DetailLabelTextStyle
- DetailValueTextStyle
- ButtonTextStyle

### 7. Colour System Approximation

Provide a token table:

| Token | Approx Value | Usage |
|---|---:|---|

Include primary accent, surface, border, text, success, warning, danger, selected, hover, focus, and disabled colours.

### 8. Spacing and Density Analysis

Identify:
- page padding
- card padding
- section gaps
- table row height
- nav item height
- button/control height
- icon badge size
- details row spacing

### 9. Shape, Borders, Radius, and Elevation

Identify:
- card radius
- button radius
- badge radius
- border thickness
- shadow/elevation strategy

Prefer border-first enterprise styling unless shadows are clearly visible.

### 10. Control Inventory

Use a table:

| UI Element | WPF Control | Binding | Command | Style/Template | Owner |
|---|---|---|---|---|---|

Include all visible controls.

### 11. WPF Layout Strategy

Specify:
- root Grid structure
- shell rows/columns
- feature rows/columns
- ScrollViewer placement
- fixed vs star sizing
- min widths
- DataGrid virtualization
- details panel collapse/scaling behaviour

### 12. Component Decomposition

Classify components as:
- Shell-level
- Feature-level
- Shared reusable controls
- Styles/DataTemplates

### 13. ResourceDictionary Plan

Recommend dictionaries:
- Colors.xaml
- Typography.xaml
- Spacing.xaml
- Cards.xaml
- Buttons.xaml
- DataGrid.xaml
- Navigation.xaml
- Badges.xaml
- Icons.xaml
- Layout.xaml

### 14. MVVM Binding Contract

Define observable properties, collections, selected state, derived state, loading/error state, and detail bindings.

### 15. Command and Interaction Contract

Define commands, source controls, CanExecute logic, async behaviour, and expected effects.

### 16. Data Display Specification

For tables/lists define:
- columns
- sorting
- selection mode
- row templates
- status badge templates
- row action templates
- pagination
- virtualization
- empty states

### 17. Details Panel / Inspector Specification

Define:
- selected item binding
- header icon/title
- description
- field/value rows
- status badge
- action buttons
- empty state

### 18. Navigation and Routing Implications

Identify active route, destination routes, quick action routes, and implied route parameters.

### 19. State Management Requirements

Include selected item, filters, search, pagination, busy state, validation, stale refresh timestamp, and error state.

### 20. Empty, Loading, Error, and Disabled States

Define no data, no filtered results, no selected item, loading, service failure, command disabled, export failure, and invalid state handling.

### 21. Responsive and Scaling Behaviour

Define minimum width, wrapping rules, details panel collapse, horizontal table scroll, text trimming, and fixed status bar behaviour.

### 22. Accessibility Requirements

Include keyboard navigation, focus visuals, AutomationProperties.Name, text status labels, DataGrid keyboard selection, contrast, and icon-only button names.

### 23. Implementation Boundaries

Separate implement vs do-not-implement unless requested.

### 24. Risks, Ambiguities, and Required Clarifications

List uncertain colours, unreadable labels, unknown data model, unknown icons, ambiguous navigation, and missing responsive requirements.

### 25. Final WPF Design Specification Summary

End with a concise engineering summary.
