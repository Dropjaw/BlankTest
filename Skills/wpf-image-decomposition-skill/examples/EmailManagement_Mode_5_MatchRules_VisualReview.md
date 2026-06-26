# Example — EmailManagement Match Rules Review Example

## Review Summary

The implementation should be reviewed against the mock as a full WPF screen, not as isolated components. The most important fidelity points are shell proportions, two-column main content, card structure, table density, selected details panel, and bottom status bar.

## Sample Discrepancy

| ID | Severity | Area | Mock Expectation | Actual | Impact | WPF Fix |
|---|---|---|---|---|---|---|
| LAYOUT-001 | P1 | Details Panel | Right-side fixed-width inspector aligned with table | Details panel below table | Breaks intended enterprise layout | Use feature root Grid with left `*` column and right fixed column around 360-400px |
| STYLE-001 | P2 | Status Badge | Rounded green/red badge with text | Plain text status | Loses visual semantics | Replace inline TextBlock with StatusBadgeControl/DataTemplate |
| DENSITY-001 | P2 | Table | Compact 40-48px rows | Rows too tall | Reduces information density | Adjust DataGridRow height/style resource |

## Sample Fix Prompt

```text
FIX PROMPT — ALIGN MATCH RULES VIEW TO MOCK

Correct the Match Rules WPF view so it more closely matches the supplied mock.

Priority fixes:
1. Restore two-column table/details layout.
2. Apply card styling consistently to metrics, list, details, and quick actions.
3. Replace plain status text with status badge template.
4. Adjust table header/row density to match enterprise mock.
5. Ensure SelectedMatchRule updates details panel.
6. Ensure Edit and View Mappings are disabled when no rule is selected.

Preserve MVVM and existing architecture. Do not rewrite unrelated screens. Run restore/build/test and report results. Do not merge unless instructed.
```
