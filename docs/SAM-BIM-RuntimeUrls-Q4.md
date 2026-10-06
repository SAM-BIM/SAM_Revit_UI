# SAM-BIM runtime URLs (Q4) - SAM_Revit_UI

PR: SAM-BIM/SAM_Revit_UI#26. Branch `fix/sam-bim-runtime-urls-q4` -> base `sow/2026-Q4` (Q4 base `4f15219`). Record date: 2026-10-06.

## Current status

PR open, **not merged**. Source-only, minimum change: two Revit ribbon commands that opened HoareLea pages now
open the SAM-BIM equivalents. No `.gitmodules`, gitlink, workflow, `master`, `sow/2026-Q3` or icon-redesign change.

## Work completed

| File | Old HoareLea destination | New SAM-BIM destination |
|---|---|---|
| `SAM_Revit_UI/SAM.Core.Revit.UI/IExternalCommands/PostOnGithub.cs` | `https://github.com/HoareLea/SAM/issues/new/choose` | `https://github.com/SAM-BIM/SAM/issues/new/choose` |
| `SAM_Revit_UI/SAM.Core.Revit.UI/IExternalCommands/Wiki.cs` | `https://github.com/HoareLea/SAM/wiki/00-Home` | `https://github.com/SAM-BIM/SAM/wiki/00-Home` |

A second commit adds the SPDX + copyright header the repository's `spdx` check requires in every changed `.cs` file (these two legacy files had none); header lines only.

## Why the change is required

SAM-BIM is now the authoritative development ecosystem and HoareLea is no longer the synchronised operational source. Bug reports
from Revit must reach the maintained repository (`SAM-BIM/SAM` has issues enabled), and the wiki command should open the maintained wiki.

## Decisions and assumptions

- `Wiki.cs`: `00-Home` is not an existing wiki page on either organisation (GitHub redirects it to the wiki front page on both), so only the owner was changed and behaviour is identical to before.
- **Kept unchanged (owner decision): `SAM.Analytical.Revit.UI/IExternalCommands/OpenViewers.cs`** still opens
  `https://hoarelea.github.io/sam-viewer/sam-viewer/v-2020-05-29/sam-viewer.html`. Classification: KEEP - intentional/deferred external runtime dependency.
  That page works today; no working SAM-BIM Pages equivalent exists (`SAM-BIM/sam-viewer` has no Pages site, `sambim.xyz/sam-viewer` is 404), so no replacement URL is invented.

## Files changed

`PostOnGithub.cs`, `Wiki.cs` (2 URL lines, plus the 3 header lines in each) and this record.

## Validation

- `git diff --check` clean; diff reviewed line by line.
- `msbuild SAM_Revit_UI.sln -p:Configuration=Release2026` (the CI configuration; plain `Release` fails at restore in this repository family) with `APPDATA`/`USERPROFILE` redirected and CI's `ReferencePath`: 0 errors.
  `SAM.Core.Revit.UI.dll` contains the new URLs and no `HoareLea/SAM/issues` or `HoareLea/SAM/wiki`.
- No test project. PR CI (`build` for Revit 2025/2026/2027, `spdx`) green; see the PR.

## Unresolved issues, risks

- `OpenViewers.cs` still depends on the HoareLea-hosted viewer (deferred; see above).

## Exact next step

Merge into `sow/2026-Q4` after green CI (maintainer-approved). After merge, the `PROJECT_PROGRESS.md` closeout is a direct docs commit on `sow/2026-Q4` (never on this branch).
