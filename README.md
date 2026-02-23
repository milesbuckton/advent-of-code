# Advent of Code

Solutions for [Advent of Code](https://adventofcode.com/) puzzles.

## Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download)

## Projects

### 2025 - Day 1: Secret Entrance

Calculates a password based on a series of rotation instructions.

- **App:** `2025/Day 1/SecretEntrance`
- **Tests:** `2025/Day 1/SecretEntrance.UnitTests`

## Build

```bash
dotnet build
```

## Run Tests

```bash
dotnet test
```

## Session Cookie (Optional)

By default, each project reads its puzzle input from an embedded resource. To
fetch your personalised input from the Advent of Code website instead, store
your session cookie using [.NET User Secrets](https://learn.microsoft.com/aspnet/core/security/app-secrets):

```bash
cd "2025/Day 1/SecretEntrance"
dotnet user-secrets set "AdventOfCode:Session" "<your-session-cookie>"
```

To find your session cookie: open DevTools in your browser on
<https://adventofcode.com> → **Application** → **Cookies** → copy the `session`
value.

The secret is stored outside the repository and is never committed.

To remove a stored secret:

```bash
cd "2025/Day 1/SecretEntrance"
dotnet user-secrets remove "AdventOfCode:Session"
```

## Publish

```bash
dotnet publish -c Release -r win-x64
```

Produces a single-file executable with embedded PDBs.
