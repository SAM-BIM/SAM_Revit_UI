# Project Progress - SAM_Revit_UI (2026-Q4)

## Branch

`sow/2026-Q4` - bootstrapped 2026-10-06 from `master` `64d6d9fc`. Frozen Q3 record: `sow/2026-Q3` @ `ccefe7da` (not modified).

## Last updated

2026-10-06 (Q4 operational cleanup).

## Current status

Q4 branch cut from `master` `64d6d9fc`, which is the exact commit pinned in SAM_Deploy's frozen Q3 baseline (`v20261006.1`). Bootstrap added only internal docs (this file, `AGENTS.md`). No product source changed. No Q4 product work has started.

## Q4 priorities

Not yet set by the owner. Record them here at the first Q4 planning pass. Known carry-over work is listed below.

## Known carry-over work

- None identified for this repository at bootstrap.

## Repository-specific next steps

- Await Q4 planning. Open PRs for Q4 work against `sow/2026-Q4`.
- Follow the continuity convention in `AGENTS.md` for every PR and closeout.

## Decisions / assumptions

- Q4 base is `master` `64d6d9fc`; the internal files were recovered from `sow/2026-Q3` into this branch only, never onto `master`.
- Q4 history intentionally does not contain the Q3 branch history (the maintained `master` is the promoted Q3 line, which is not a descendant of `sow/2026-Q3`); the frozen `sow/2026-Q3` branch is the permanent record.
- Historical Q2/Q3 content below is kept as evidence; its branch names, SHAs and next steps describe Q3 and are not current instructions.

## Validation

- Bootstrap verified 2026-10-06: `sow/2026-Q4` was created at exactly `64d6d9fc` and the push was a normal (non-forced) branch creation.

## Issues / blockers

- None at bootstrap.

## Next step

- Owner to set Q4 priorities; then start the first Q4 task from this branch.

## Q4 operational cleanup (2026-10-06)

- Reviewed every active Q2/Q3 reference in this repository on `sow/2026-Q4` (workflow branch filters, dependency-branch resolution, `.gitmodules`/validation, docs). Historical Q2/Q3 mentions (feature documentation records, the frozen Q3 section below) are intentionally unchanged.
- Changed (`8cbdac4`): removed the dead `$candidates += 'sow/2026-Q2'` fallback from the dependency-branch resolution in `.github/workflows/build.yml`. No dependency repository has a `sow/2026-Q2` branch, so the entry never matched and resolution already fell through to the default branch; behaviour is unchanged (PR head ref, current sow ref, then the dependency's default branch) and no per-quarter edit is needed.
- Checked, no action: the `github.repository_owner == 'SAM-BIM'` build guard (intentional; its comment names HoareLea only to explain why the guard exists), CODEOWNERS (SAM-BIM owners), and workflow secrets (no HoareLea-named secret). The local `upstream` (HoareLea) remote is preserved.
- Full cross-repository record, migration table and owner decisions: `SAM_Deploy:sow/2026-Q4` `PROJECT_PROGRESS.md`.

## Q4 runtime-URL cleanup (2026-10-06)

- **Status:** complete. SAM-BIM/SAM_Revit_UI#26 merged into `sow/2026-Q4` as merge commit `6983a2d94106c2468f84537eef69d35a198a09c9` (PR head `18312f136559a1607559321d06ce39cc958ae029`, Q4 base `4f15219`); merge method: merge commit (repository convention). Remote and local `fix/sam-bim-runtime-urls-q4` removed.
- **Work completed:** The Revit "Post on GitHub" command now opens `https://github.com/SAM-BIM/SAM/issues/new/choose` and the Wiki command `https://github.com/SAM-BIM/SAM/wiki/00-Home`, instead of the `HoareLea/SAM` equivalents (`00-Home` is not an existing page on either wiki; GitHub redirects both to the wiki front page, so only the owner changed). SAM-BIM is the authoritative ecosystem; HoareLea is no longer the synchronised operational source. Record: the PR's `SAM-BIM-RuntimeUrls-Q4.md` document.
- **Decisions / owner classifications:** `SAM.Analytical.Revit.UI/IExternalCommands/OpenViewers.cs` still opens `hoarelea.github.io/sam-viewer`: KEEP - intentional/deferred external runtime dependency (the page works today; `SAM-BIM/sam-viewer` has no working Pages site, so no replacement URL is invented). Assembly author/contact strings in `Kernel/AssemblyInfo.cs` (`Hoare Lea`, `@hoarelea.com`) are provenance/metadata: KEEP. These are owner decisions, not baseline blockers.
- **Files changed:** `SAM_Revit_UI/SAM.Core.Revit.UI/IExternalCommands/PostOnGithub.cs`, `Wiki.cs` (2 URL lines, plus the SPDX header the `spdx` check requires in each), `docs/SAM-BIM-RuntimeUrls-Q4.md`.
- **Validation:** `msbuild SAM_Revit_UI.sln -p:Configuration=Release2026` (the CI configuration; APPDATA/USERPROFILE redirected, CI ReferencePath): 0 errors; `SAM.Core.Revit.UI.dll` contains the new URLs and no `HoareLea/SAM/issues` or `HoareLea/SAM/wiki`. No test project. PR CI build (Revit 2025/2026/2027) and spdx green.
- **Unresolved issues, risks:** `OpenViewers.cs` depends on the HoareLea-hosted viewer (deferred, see decisions).
- **Next step:** Enable GitHub Pages on SAM-BIM/sam-viewer (owner decision) and then repoint OpenViewers; this repository has no icon PR.

---

# Historical record - 2026-Q3 (frozen)

Source: last revision of the file on `sow/2026-Q3`, commit `05fa2e7` (the file was removed from the Q3 tip by `ccefe7d`; `sow/2026-Q3` tip is `ccefe7da`). The Q3 file was an unpopulated template ("Not updated yet"); no Q3 work was recorded in this repository's progress file.
