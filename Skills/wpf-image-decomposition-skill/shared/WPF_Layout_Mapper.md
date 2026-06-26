# Shared Skill — WPF Layout Mapper

## Purpose

Translate visual layout zones into WPF layout containers.

## Rules

Use `Grid` when:
- layout has stable rows/columns
- shell composition is needed
- details panel and table need side-by-side alignment

Use `DockPanel` when:
- simple top/bottom/left/right docking is enough
- status bar or toolbar alignment is simple

Use `StackPanel` when:
- child elements flow in one direction
- content size is naturally determined
- the region is not a virtualised list

Do not use `StackPanel` as the direct parent of large virtualised lists if it gives infinite available height.

Use `WrapPanel` when:
- metric cards or quick actions should wrap at smaller widths

Use `UniformGrid` when:
- equal-sized metric cards are required
- fixed number of columns is acceptable

Use `ItemsControl` when:
- repeated cards or nav items are bound from collections

Use `DataGrid` when:
- tabular data, sorting, selection, virtualization, and column templates are required

Use `ListView/GridView` when:
- tabular style is needed but DataGrid behaviour is too heavy

Use `ContentControl` when:
- active page or selected detail content changes

Use `ScrollViewer` when:
- page content may exceed vertical space
- avoid wrapping virtualised DataGrid directly in an unconstrained ScrollViewer

## Output Format

| Mock Region | WPF Layout Construct | Notes |
|---|---|---|
