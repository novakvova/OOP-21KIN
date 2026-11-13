# Специфікація проєкту WpfTest

## Призначення

Настільний застосунок для створення тестів (вікторин) та їх проходження. Користувач проходить тест, вказавши ПІБ, а результат (кількість правильних і неправильних відповідей, час початку і завершення) зберігається в базі даних.

Поточний стан: модель даних, ініціалізація БД і завантаження початкових тестів з JSON готові. Після запуску показується `BeginWindow` (поки порожнє). `TestWindow` уміє проводити користувача через перший тест з БД (питання по черзі; один правильний варіант → `RadioButton`, кілька → `CheckBox`; підсумок у `MessageBox`), але ще не відкривається з `BeginWindow`. Результат у БД не зберігається, ПІБ не запитується, ліміт часу не враховується.

## Технології та залежності

| Компонент | Версія / значення |
|---|---|
| Платформа | .NET 9 (`net9.0-windows`) |
| UI | WPF (`UseWPF`), тип виводу `WinExe` |
| ORM | Entity Framework Core 9 |
| База даних | SQLite (`Microsoft.EntityFrameworkCore.Sqlite` 9.0.22) |
| JSON | `Newtonsoft.Json` 13.0.4 (читання `SeedData/users.json`) |
| Файл рішення | `WpfTest.slnx` (новий XML-формат рішень) |
| Мовні опції | `Nullable` enabled, `ImplicitUsings` enabled |

Окрім `Microsoft.EntityFrameworkCore.Sqlite` і `Newtonsoft.Json`, NuGet-пакетів немає: немає DI-контейнера, MVVM-фреймворка, логування чи тестових бібліотек.

## Структура проєкту

```
WpfTest/
├── WpfTest.slnx              # рішення
├── CLAUDE.md, spec.md, README.md
└── WpfTest/                  # єдиний проєкт
    ├── WpfTest.csproj
    ├── App.xaml / App.xaml.cs        # точка входу, ініціалізація БД і seed
    ├── BeginWindow.xaml / .xaml.cs   # стартове вікно (поки порожнє)
    ├── TestWindow.xaml / .xaml.cs    # проходження тесту (питання по черзі, підсумок)
    ├── MyDataContext.cs              # EF Core DbContext
    ├── Entities/                     # сутності БД
    │   ├── TestEntity.cs
    │   ├── QuestionEntity.cs
    │   ├── AnswerEntity.cs
    │   ├── TestResultEntity.cs
    │   └── TestResultAnswerEntity.cs
    ├── Models/
    │   └── TestSeedModel.cs          # DTO для JSON (TestSeedModel, QuestionSeedModel, AnswerSeedModel)
    └── SeedData/
        └── users.json                # початкові тести (копіюється в output)
```

## Модель даних

```
TestEntity 1 ── * QuestionEntity 1 ── * AnswerEntity
    │
    1
    │
    * TestResultEntity 1 ── * TestResultAnswerEntity (SelectedAnswer)
```

| Сутність | Таблиця | Основні поля | Обмеження |
|---|---|---|---|
| `TestEntity` | `Tests` | `Title`, `Description`, `CreatedAt`, `TimeLimitMinutes` | `Title` ≤ 200, `Description` ≤ 1000, ліміт часу 1–60 хв (необов'язковий) |
| `QuestionEntity` | `Questions` (назва з `DbSet`) | `Text`, `TestId` | `Text` ≤ 1000 |
| `AnswerEntity` | `Answers` | `Text`, `IsCorrect`, `QuestionId` | `Text` ≤ 500 |
| `TestResultEntity` | `TestResultEntity` | `TestId`, `LastName`, `FirstName`, `MiddleName`, `CorrectAnswersCount`, `WrongAnswersCount`, `StartedAt`, `FinisheddAt` | імена ≤ 100, `MiddleName` необов'язкове |
| `TestResultAnswerEntity` | `tblTestResultAnswers` | `TestResultId`, `SelectedAnswerId`, `IsCorrect` | — (не зареєстрована в моделі, див. «Відомі проблеми») |

Питання може мати кілька правильних відповідей: правильність задається прапорцем `AnswerEntity.IsCorrect`, а не полем у питанні.

Початкові дані з JSON містять поле `points` у питаннях, але `QuestionEntity` його не має, тож значення ігнорується.

## Основні архітектурні рішення

1. **Code First + data annotations.** Схема БД описується атрибутами (`[Key]`, `[Required]`, `[StringLength]`, `[ForeignKey]`, `[Table]`) прямо в сутностях. Fluent API (`OnModelCreating`) не використовується.
2. **`EnsureCreated` замість міграцій.** У `App.OnStartup` викликається `Database.EnsureCreated()`, тому таблиці створюються при першому запуску. Наслідок: зміни в сутностях не застосовуються до вже існуючого `DotNetTest.db`, і файл треба видалити (або перейти на міграції).
3. **Початкові дані (seed) з JSON.** Якщо таблиця `Tests` порожня, `App.OnStartup` читає `SeedData/users.json` (шлях відносно робочої директорії), десеріалізує його в `TestSeedModel` через `Newtonsoft.Json` і додає тести з питаннями та відповідями. Файл копіюється в output (`CopyToOutputDirectory = Always`).
4. **Підключення до БД захардкоджене.** `OnConfiguring` використовує `Data Source=DotNetTest.db` (шлях відносно робочої директорії, зазвичай `bin/Debug/net9.0-windows/`). Немає `appsettings` і DI: контекст створюється через `new MyDataContext()`.
5. **Ручний запуск вікна.** В `App.xaml` немає `StartupUri`, тому `BeginWindow` створюється й показується в `OnStartup` після ініціалізації БД.
6. **Code-behind замість MVVM.** На даний момент логіка розміщується у code-behind файлах.

## Відомі проблеми

- `TestResultAnswerEntity` не зареєстрована як `DbSet` у `MyDataContext` і недосяжна через навігаційні властивості, тому її таблиця не створюється.
- `TestResultEntity` не має колекції відповідей (`TestResultAnswerEntity`), а `TestEntity` не має колекції результатів.
- Друкарська помилка в назві властивості `FinisheddAt` (стане назвою колонки в БД).
- Значення за замовчуванням `CreatedAt` / `FinisheddAt` у сутностях беруть локальний час (`DateTime.Now`), але позначають його як UTC (`DateTimeKind.Utc`). Правильніше використовувати `DateTime.UtcNow`. Seed уже використовує `DateTime.UtcNow` для `CreatedAt`.
- Непослідовні назви таблиць (`Tests`, `TestResultEntity`, `tblTestResultAnswers`).
- Для колекцій навігації `QuestionEntity`/`TestEntity` задано `= new List<...>()`, але навігації `Test`, `Question`, `TestResult`, `SelectedAnswer` мають `= null!`. Без `Include` звернення до них дасть `NullReferenceException`.
- Якщо `SeedData/users.json` не знайдено, показується `MessageBox` і `OnStartup` виходить раніше, без створення `BeginWindow`, тож застосунок завершується без вікна.
- `TestSeedModel.cs` у коментарі згадує `SeedData/tests.json`, але файл називається `users.json` (назва не відповідає вмісту: це тести, а не користувачі).
- `MyDataContext` не звільняється (`using`) в `App.OnStartup`.
- `TestWindow` сам робить запит до БД (`First()` без перевірки: порожня БД або тест без питань дасть виняток) і сам рахує правильні/неправильні відповіді. Це порушує правило «логіка в `Services/`»; переробити разом із появою `Services/`.
- `TestWindow` ще не відкривається з `BeginWindow`, тому наскрізний сценарій (запуск → тест) не працює.
- `BeginWindow.xaml.cs` містить невикористані `using` і блочний namespace.
