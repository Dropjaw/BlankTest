# Shared Skill — Coding-Agent Prompt Builder

## Purpose

Turn a WPF mock decomposition into a safe implementation prompt for an AI coding agent.

## Required Prompt Contents

1. Role
2. Repository
3. Branch
4. Target View
5. Source Images
6. Source Specifications
7. Objective
8. Constraints
9. Discovery Steps
10. Required Architecture
11. Required Components
12. Required ViewModel Contract
13. Required Commands
14. Required Styling
15. Required Tests
16. Required Build Validation
17. Non-Goals
18. PR Instructions
19. Final Checklist

## Prompt Rules

- Make the agent inspect before editing.
- Make the agent preserve existing architecture.
- Make the agent avoid broad rewrites.
- Make the agent run build/tests.
- Make the agent report changed files.
- Make the agent identify deviations from the mock.
- Make the agent not merge unless explicitly told.
- Make the agent avoid code-behind business logic.
- Make the agent reuse existing styles/resources before creating new ones.
