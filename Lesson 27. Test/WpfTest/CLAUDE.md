# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.
Використовуй короткі відповіді, без зайвого коду, лише важлива інформація!

Перед рефакторингом і роботою з кодом завжди читай файл @spec.md
## Project

A WPF desktop app (.NET 9, `net9.0-windows`) for creating and taking knowledge tests (quizzes). It is a learning project for an OOP course; UI strings and code comments are in Ukrainian — keep new user-facing text in Ukrainian to match.

## Commands

Run from the repo root (where `WpfTest.slnx` lives):

```powershell
dotnet build WpfTest.slnx
dotnet run --project WpfTest/WpfTest.csproj
```

There is no linter configured. No test project exists yet — see "Testing rules" below for how to add one. Once it exists:

```powershell
dotnet test WpfTest.slnx
dotnet test WpfTest.slnx --filter "FullyQualifiedName~ClassName.MethodName"   # single test
```

See `spec.md` for the full project specification (data model, architectural decisions, known issues).

## Architecture

- **Data access**: EF Core with SQLite (`Microsoft.EntityFrameworkCore.Sqlite`). `MyDataContext` hardcodes `Data Source=DotNetTest.db` in `OnConfiguring`, so the database file is created relative to the working directory (normally `bin/Debug/net9.0-windows/`). No DI container — code instantiates `new MyDataContext()` directly.
- **Schema management**: there are no EF migrations. The schema is created by `Database.EnsureCreated()` in `App.OnStartup`. Because `EnsureCreated` never alters an existing database, after changing entities you must delete `DotNetTest.db` (or add migrations) for the schema change to take effect.
- **Seed data**: if the `Tests` table is empty, `App.OnStartup` loads `SeedData/users.json` (copied to output) into `TestSeedModel` (`Models/TestSeedModel.cs`) via `Newtonsoft.Json` and saves the tests with questions and answers.
- **Startup**: `App.xaml` has no `StartupUri`; `App.OnStartup` (in `App.xaml.cs`) does DB init/seed, then creates and shows `MainWindow` manually.
- **Entities** (`Entities/`, configured with data annotations, not Fluent API):
  - `TestEntity` → many `QuestionEntity` → many `AnswerEntity` (`IsCorrect` flag marks correct answers).
  - `TestResultEntity` records one attempt at a test (student name, correct/wrong counts, start/finish times).
  - `TestResultAnswerEntity` (per-answer record of an attempt) exists but is **not** registered as a `DbSet` and is not reachable via navigation, so it is currently not part of the EF model/database. Add a `DbSet` to `MyDataContext` if it is needed.
  - Table names are inconsistent (`Tests`, `Answers`, `TestResultEntity`, `tblTestResultAnswers`, and `QuestionEntity` falls back to its DbSet name `Questions`) — set via `[Table]` attributes.
- **UI**: `MainWindow` is currently an empty shell; no MVVM framework is in use (code-behind style).

## Coding rules

- Use file-scoped namespaces (`namespace WpfTest.Entities;`) matching the folder path. `MainWindow.xaml.cs` still uses a block namespace — convert it when touching that file.
- Entity classes live in `Entities/`, end with the `Entity` suffix, and are configured with data annotations (`[Key]`, `[Required]`, `[StringLength]`, `[ForeignKey(nameof(...))]`, `[Table]`), not Fluent API.
- Nullable reference types are enabled: required strings get `= null!` or `= string.Empty`, optional ones are `string?`. Initialize collection navigations with `= new List<T>()`, not `= null!`.
- Use `DateTime.UtcNow` for timestamps (existing `DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc)` is a known bug; don't copy it).
- Dispose contexts: `using var db = new MyDataContext();`. Use `Include(...)` when navigations are needed — lazy loading is not enabled.
- In UI event handlers prefer EF async APIs (`ToListAsync`, `SaveChangesAsync`) with `async void` handlers only at the event boundary.
- User-facing strings (UI, `MessageBox`) are in Ukrainian. Code identifiers are in English.
- Remove the unused `using` directives that Visual Studio templates generate.

## Architecture rules

- Every new entity must be registered as a `DbSet<T>` in `MyDataContext` (or be reachable through a navigation), otherwise its table is not created.
- Schema changes: until migrations are introduced, the schema comes only from `EnsureCreated()`, so delete `DotNetTest.db` from the output folder after changing entities. If you introduce migrations, replace `EnsureCreated()` with `Database.Migrate()` — the two must not be mixed.
- Seed data lives in `SeedData/*.json` (copied to output); DTOs for it live in `Models/`. Load it in `App.OnStartup` (or a dedicated seeding method it calls), guarded by an "is the table empty" check so it runs once. Don't hardcode seed tests in C#.
- Don't add `Newtonsoft.Json` usages beyond seed loading without asking; it is the only extra package besides EF Core SQLite.
- Keep database queries and test-scoring logic (counting correct/wrong answers, building `TestResultEntity`) out of window code-behind: put them in plain classes under `Services/` that take a `MyDataContext`, so they can be unit-tested without WPF.
- Windows stay thin: code-behind handles UI events and binding, calling into services.
- Don't add DI containers, MVVM frameworks or other NuGet packages without asking — this is a course project and keeps dependencies minimal.

## Testing rules

- Tests go in a separate project `WpfTest.Tests/` (xUnit, `net9.0-windows`) referencing `WpfTest`, added to `WpfTest.slnx` (`dotnet sln WpfTest.slnx add WpfTest.Tests/WpfTest.Tests.csproj`).
- To make the context testable, add a constructor `MyDataContext(DbContextOptions<MyDataContext> options)` and only apply `UseSqlite("Data Source=DotNetTest.db")` in `OnConfiguring` when `!optionsBuilder.IsConfigured`. (Not done yet — `MyDataContext` currently has only the parameterless constructor.)
- Use SQLite in-memory (`Data Source=:memory:` with an open `SqliteConnection` kept for the test's lifetime, then `EnsureCreated()`) rather than the EF InMemory provider, so constraints and foreign keys behave like the real database. Never touch `DotNetTest.db` from tests.
- Test services and scoring logic, not WPF windows. Name tests `Method_Scenario_ExpectedResult` and use Arrange/Act/Assert.
- Run `dotnet build` and `dotnet test` before reporting a change as done.
