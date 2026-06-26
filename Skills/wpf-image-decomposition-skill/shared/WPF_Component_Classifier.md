# Shared Skill — WPF Component Classifier

## Purpose

Decide whether a visual element should be implemented as inline XAML, Style, DataTemplate, UserControl, CustomControl, ViewModel, or Service.

## Decision Rules

### Inline XAML

Use when:
- the element is one-off
- layout is simple
- no reuse is expected
- no complex behaviour exists

### Style

Use when:
- the same visual appearance applies to existing WPF controls
- no custom layout structure is needed
- example: Button, TextBox, ComboBox, Border, DataGridRow

### DataTemplate

Use when:
- rendering repeated data items
- examples: metric cards, quick action cards, navigation items, table cell templates

### UserControl

Use when:
- repeated composite UI exists
- a feature section is large enough to obscure the main page
- layout has multiple child controls
- examples: DetailsPanel, QuickActionCard, MetricCard, StatusBadge

### CustomControl

Use rarely.

Use when:
- control must be themeable through ControlTemplate
- control is library-quality
- behaviour is reusable across applications

### ViewModel

Use when:
- state changes
- commands exist
- selection/filtering/pagination is needed
- display logic needs testing

### Service

Use when:
- data is loaded or saved
- export occurs
- navigation is orchestrated
- business rules run
- dialogs are opened through abstraction

## Output Format

| Visual Element | Recommended Implementation | Reason |
|---|---|---|
