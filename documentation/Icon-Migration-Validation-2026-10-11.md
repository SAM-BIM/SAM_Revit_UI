# Icon migration validation — 2026-10-11

Base: `sow/2026-Q4`. Scope: SAM-BIM only. Reference: [SAM#179](https://github.com/SAM-BIM/SAM/pull/179); [SAM#166](https://github.com/SAM-BIM/SAM/pull/166) is the closed historical design source.

## Changes and decisions

- Grasshopper manifest coverage: 0 concrete objects. GUIDs, APIs, namespaces, component metadata and behavior are preserved.
- Reuse the frozen SAM glyph/palette/badge grammar and frozen SAM-BIM extension v1. Preserve plugin identity, external integration logos, severity symbols and historical attribution.
- Source comparison against current base: 33 icon resource token swaps; 0 other production C# changes, apart from standard SPDX headers and additive resource properties.
- Validated 33 manifest resource references; 0 errors.
- Replaces 33 Revit command icon assignments with 25 approved glyph/badge combinations; additive typed resources in both UI projects. Existing commands and handlers are unchanged.

## Fresh validation

- VS MSBuild Restore,Build, Release2026: **PASS**. Scratch APPDATA/USERPROFILE; current sibling SAM-BIM dependencies, OCCT native build skipped.
- Regression suites: No completed regression test result recorded yet; no pass claimed.

Next step: verify final-head GitHub checks and merge only if green and safe under the owner authorization. No force-push or branch deletion. Hosted Rhino smoke is tracked separately; prior historical results are not fresh runs.
