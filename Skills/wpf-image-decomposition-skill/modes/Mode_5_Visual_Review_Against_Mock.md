# Mode 5 — Visual Review Against Mock

## Purpose

Compare an original mock image against a screenshot of an implemented WPF view, then produce a visual discrepancy report, prioritised fix plan, and coding-agent fix prompt.

## Input

- Original mock image.
- Screenshot of implemented WPF view.
- Optional repository/branch context.

## Output

- Visual discrepancy report.
- Prioritised fix plan.
- Copy-ready implementation fix prompt.

## Required Output Template

1. Review Summary
2. Fidelity Score
3. Critical Layout Discrepancies
4. Component-Level Discrepancies
5. Spacing and Density Discrepancies
6. Typography Discrepancies
7. Colour and Contrast Discrepancies
8. Interaction and State Discrepancies
9. WPF Architecture Risks
10. Accessibility Issues
11. Prioritised Fix Plan
12. Detailed Fix Instructions
13. Regression Risk Warnings
14. Implementation Fix Prompt
15. Final Verification Checklist

## Review Rules

- Compare UI systems, not isolated pixels.
- Do not demand exact pixel perfection unless requested.
- Identify what is already correct.
- Prioritise layout fidelity before polish.
- Separate functional issues from visual discrepancies.
- Give concrete WPF-level fixes.

## Severity Model

P0:
- blocks use
- major layout broken
- selected data cannot be viewed
- table unusable
- navigation broken

P1:
- obvious mismatch with mock
- wrong layout region
- missing major component
- incorrect proportions

P2:
- typography, colour, border, density, or polish issue

P3:
- optional refinement

## Review Template

```text
VISUAL REVIEW — IMPLEMENTATION AGAINST MOCK

======================================================================
1. REVIEW SUMMARY
======================================================================

Mock:
[MOCK_IMAGE_NAME]

Implementation:
[IMPLEMENTATION_SCREENSHOT_NAME]

Target view:
[TARGET_VIEW_NAME]

Overall assessment:
[Brief summary]

Main conclusion:
[Acceptable / minor correction / major rework]

======================================================================
2. FIDELITY SCORE
======================================================================

Overall fidelity:
[0-100]%

Breakdown:
- Layout fidelity: [score]
- Component fidelity: [score]
- Spacing/density fidelity: [score]
- Typography fidelity: [score]
- Colour fidelity: [score]
- Interaction/state fidelity: [score]
- Architectural cleanliness risk: [low/medium/high]

======================================================================
3. CRITICAL LAYOUT DISCREPANCIES
======================================================================

For each discrepancy:

- ID
- Severity
- Area
- Mock expectation
- Actual implementation
- Impact
- Recommended WPF fix

======================================================================
4. COMPONENT-LEVEL DISCREPANCIES
======================================================================

Review:
- navigation
- top bar
- page header
- toolbar
- search box
- filters
- buttons
- metric cards
- table
- badges
- details panel
- quick actions
- bottom status bar

======================================================================
5. SPACING AND DENSITY DISCREPANCIES
======================================================================

Check margins, padding, gaps, row heights, card heights, icon sizes, details field spacing, and status bar spacing.

======================================================================
6. TYPOGRAPHY DISCREPANCIES
======================================================================

Check title sizes, headings, table headers, cells, captions, badges, and button text.

======================================================================
7. COLOUR AND CONTRAST DISCREPANCIES
======================================================================

Check background, card surfaces, borders, accent colours, status badges, muted text, selected state, hover, and focus.

======================================================================
8. INTERACTION AND STATE DISCREPANCIES
======================================================================

Check selected row/details sync, command enabling, active navigation, hover/focus, pagination, search/filter, refresh, empty/loading/error states.

======================================================================
9. WPF ARCHITECTURE RISKS
======================================================================

Identify monolithic XAML, duplicated styles, hard-coded colours, code-behind logic, poor ViewModel separation, direct service calls from views, missing reusable controls, missing ResourceDictionary tokens, broken navigation boundaries, and non-virtualised tables.

======================================================================
10. ACCESSIBILITY ISSUES
======================================================================

Review keyboard order, focus visuals, accessible names, status text, contrast, and DataGrid keyboard support.

======================================================================
11. PRIORITISED FIX PLAN
======================================================================

P0 — Must fix before merge.
P1 — Should fix before merge.
P2 — Polish.
P3 — Optional.

======================================================================
12. DETAILED FIX INSTRUCTIONS
======================================================================

Provide exact WPF-level fix guidance: Grid changes, margin/padding changes, style updates, DataGrid template fixes, binding fixes, command state fixes, and ResourceDictionary token updates.

======================================================================
13. REGRESSION RISK WARNINGS
======================================================================

Warn where global style changes may affect other screens. Prefer scoped styles if global impact is uncertain.

======================================================================
14. IMPLEMENTATION FIX PROMPT
======================================================================

Generate a copy-ready fix prompt for a coding agent.

======================================================================
15. FINAL VERIFICATION CHECKLIST
======================================================================

Verify layout, navigation, toolbar, metric cards, table, details panel, quick actions, status bar, selected item behaviour, search/filter/pagination, accessibility, build, and tests.
```
