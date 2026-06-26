# Mode 4 Template — Repo-Native Implementation Prompt

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
MOCK DECOMPOSITION SUMMARY
======================================================================

[INSERT MOCK SUMMARY]

======================================================================
REQUIRED WPF COMPOSITION ARCHITECTURE
======================================================================

[INSERT ARCHITECTURE]

======================================================================
REQUIRED VIEW STRUCTURE
======================================================================

[INSERT VIEW LAYOUT REQUIREMENTS]

======================================================================
REQUIRED VIEWMODEL CONTRACT
======================================================================

[INSERT PROPERTIES, COLLECTIONS, SELECTED STATE, DERIVED STATE]

======================================================================
REQUIRED COMMANDS
======================================================================

[INSERT COMMANDS]

======================================================================
REQUIRED RESOURCE DICTIONARIES AND STYLES
======================================================================

[INSERT STYLE REQUIREMENTS]

======================================================================
REQUIRED SHARED COMPONENTS
======================================================================

[INSERT COMPONENTS]

======================================================================
REQUIRED DATA TABLE/LIST SPECIFICATION
======================================================================

[INSERT TABLE REQUIREMENTS]

======================================================================
REQUIRED DETAILS PANEL BEHAVIOUR
======================================================================

[INSERT DETAILS REQUIREMENTS]

======================================================================
REQUIRED QUICK ACTIONS BEHAVIOUR
======================================================================

[INSERT QUICK ACTION REQUIREMENTS]

======================================================================
LOADING, EMPTY, ERROR, AND DISABLED STATES
======================================================================

[INSERT STATE REQUIREMENTS]

======================================================================
ACCESSIBILITY REQUIREMENTS
======================================================================

[INSERT ACCESSIBILITY REQUIREMENTS]

======================================================================
TESTING REQUIREMENTS
======================================================================

[INSERT TEST REQUIREMENTS]

======================================================================
BUILD AND CI REQUIREMENTS
======================================================================

Run restore/build/test. Fix failures. Do not merge unless explicitly instructed.

======================================================================
VISUAL VERIFICATION CHECKLIST
======================================================================

[INSERT CHECKLIST]

======================================================================
PROHIBITED CHANGES
======================================================================

[INSERT NON-GOALS]

======================================================================
FINAL DELIVERABLES
======================================================================

Report:
- files changed
- architectural decisions
- tests added/updated
- tests run
- build/test results
- known deviations from mock

```
