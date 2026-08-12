# Review instructions

## Scope

- Only flag issues on lines modified in this PR.
- **Do not post any 🟣 Pre-existing findings under any circumstances.**
  Pre-existing bugs are out of scope for every review on this repository, even
  when the diff is adjacent to or reads from the affected code. If a bug is not
  introduced or made worse by this PR, do not report it — inline, in the
  summary, in the check run annotations, or anywhere else.
- Do not suggest refactors, renames, or structural changes to unchanged code.
- Ignore files that are not part of the PR diff.

## What counts as Important

Reserve 🔴 Important for findings that would break behavior at runtime, introduce
a security vulnerability, corrupt data, or cause a regression visible to users.

- Null/undefined dereferences on paths the diff introduces
- Incorrect logic in new or modified branches
- Resource leaks (undisposed streams, connections, handles) added by the diff
- Injection, deserialization, or auth flaws introduced by the diff

Style, naming, formatting, and refactor suggestions are 🟡 Nit at most.

## What not to report

- Anything already enforced by the build, linter, or analyzers
- Auto-generated files, designer files (`*.Designer.cs`), and bin/obj output
- Formatting, whitespace, and casing preferences
- Documentation or comment wording unless the diff changes behavior that
  contradicts nearby comments

## Summary shape

Open the review summary with a one-line tally in the form
`N important, M nit`. Lead with "No blocking issues." when the diff has no
Important findings.
