# Shared Skill — Visual Token Extractor

## Purpose

Extract reusable design tokens from a mock UI image for WPF `ResourceDictionary` implementation.

## Output

1. Colour Tokens
2. Typography Tokens
3. Spacing Tokens
4. Shape Tokens
5. Border and Elevation Tokens
6. State Tokens
7. WPF ResourceDictionary Recommendations

## Colour Tokens

Use a table:

| Token | Approx Value | Usage |
|---|---:|---|
| PrimaryAccent | #... | primary buttons, selected nav, links, icons |
| PrimaryAccentHover | #... | hover state |
| PrimaryAccentPressed | #... | pressed state |
| PageBackground | #... | main page background |
| ShellBackground | #... | navigation/top shell |
| CardBackground | #... | cards and panels |
| BorderSubtle | #... | card borders |
| BorderStrong | #... | focused/active borders |
| TextPrimary | #... | headings and primary text |
| TextSecondary | #... | body text |
| TextMuted | #... | metadata/captions |
| Success | #... | active/success text |
| SuccessBackground | #... | active/success badge background |
| Danger | #... | inactive/error text |
| DangerBackground | #... | inactive/error badge background |
| Warning | #... | warning text |
| WarningBackground | #... | warning badge background |
| Info | #... | informational icons |
| InfoBackground | #... | informational icon backgrounds |

Never claim exactness unless sampled.

## Typography Tokens

| Token | Approx Size | Weight | Usage |
|---|---:|---:|---|
| PageTitleFontSize | 28-32 | SemiBold/Bold | page title |
| SectionTitleFontSize | 18-22 | SemiBold | card headers |
| BodyFontSize | 12-14 | Regular | table/body |
| CaptionFontSize | 10-12 | Regular | helper text |
| MetricValueFontSize | 26-34 | Bold | summary cards |
| ButtonFontSize | 13-15 | SemiBold | command buttons |
| TableHeaderFontSize | 11-13 | SemiBold | table headers |
| DetailLabelFontSize | 12-14 | SemiBold | detail labels |

## Spacing Tokens

| Token | Approx Value | Usage |
|---|---:|---|
| PagePadding | 24 | outer page |
| ShellPadding | 16-24 | shell regions |
| CardPadding | 16-20 | cards |
| SectionGap | 16-24 | vertical regions |
| ControlGap | 8-12 | toolbar controls |
| RowGap | 8-12 | form/detail rows |
| TableRowHeight | 40-48 | data rows |
| NavItemHeight | 44-52 | sidebar items |
| ButtonHeight | 36-44 | command buttons |

## Shape Tokens

| Token | Approx Value | Usage |
|---|---:|---|
| CardRadius | 8-12 | panels/cards |
| ButtonRadius | 6-8 | buttons |
| BadgeRadius | 4-6 | status badges |
| NavItemRadius | 6-10 | sidebar items |
| IconCircleSize | 44-64 | metric/action icons |
| BorderThickness | 1 | most containers |

## State Tokens

Include:
- hover background
- selected background
- disabled opacity
- focus border
- pressed state
- validation error border
- table row selected background
- table row hover background
