# Mode 5 Template — Visual Review and Fix Prompt

```text
VISUAL REVIEW — IMPLEMENTATION AGAINST MOCK

======================================================================
1. REVIEW SUMMARY
======================================================================

Mock:
[MOCK_IMAGE_NAME]

Implementation screenshot:
[IMPLEMENTATION_SCREENSHOT_NAME]

Target view:
[TARGET_VIEW_NAME]

Overall assessment:
[SUMMARY]

Main conclusion:
[ACCEPTABLE / MINOR CORRECTION / MAJOR REWORK]

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

| ID | Severity | Area | Mock Expectation | Actual | Impact | WPF Fix |
|---|---|---|---|---|---|---|

======================================================================
4. COMPONENT-LEVEL DISCREPANCIES
======================================================================

======================================================================
5. SPACING AND DENSITY DISCREPANCIES
======================================================================

======================================================================
6. TYPOGRAPHY DISCREPANCIES
======================================================================

======================================================================
7. COLOUR AND CONTRAST DISCREPANCIES
======================================================================

======================================================================
8. INTERACTION AND STATE DISCREPANCIES
======================================================================

======================================================================
9. WPF ARCHITECTURE RISKS
======================================================================

======================================================================
10. ACCESSIBILITY ISSUES
======================================================================

======================================================================
11. PRIORITISED FIX PLAN
======================================================================

P0 — Must fix before merge:

P1 — Should fix before merge:

P2 — Polish:

P3 — Optional:

======================================================================
12. DETAILED FIX INSTRUCTIONS
======================================================================

======================================================================
13. REGRESSION RISK WARNINGS
======================================================================

======================================================================
14. IMPLEMENTATION FIX PROMPT
======================================================================

Provide a copy-ready prompt that instructs a coding agent to align the WPF view with the mock while preserving MVVM, existing styles, existing navigation, and existing architecture.

======================================================================
15. FINAL VERIFICATION CHECKLIST
======================================================================

- overall shell proportions match
- active navigation item matches
- page header and toolbar align
- metric cards match size and spacing
- table card matches mock structure
- details panel is correctly positioned
- quick actions match layout
- bottom status bar remains fixed
- selected item behaviour works
- search/filter/pagination still work
- accessibility basics remain intact
- build succeeds
- tests pass
```
