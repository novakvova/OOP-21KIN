# Специфікація проєкту WpfTest

## Призначення

Настільний застосунок для створення тестів (вікторин) та їх проходження. Користувач проходить тест, вказавши ПІБ, а результат (кількість правильних і неправильних відповідей, час початку і завершення) зберігається в базі даних.

Поточний стан: модель даних і ініціалізація БД готові, інтерфейс (`MainWindow`) ще порожній.

## Технології та залежності

| Компонент | Версія / значення |
|---|---|
| Платформа | .NET 9 (`net9.0-windows`) |
| UI | WPF (`UseWPF`), тип виводу `WinExe` |
| ORM | Entity Framework Core 9 |
| База даних | SQLite (`Microsoft.EntityFrameworkCore.Sqlite` 9.0.22) |
| Файл рішення | `WpfTest.slnx` (новий XML-формат рішень) |
| Мовні опції | `Nullable` enabled, `ImplicitUsings` enabled |

Інших NuGet-пакетів немає: немає DI-контейнера, MVVM-фреймворка, логування чи тестових бібліотек.

## Структура проєкту

```
WpfTest/
├── WpfTest.slnx              # рішення
├── CLAUDE.md, spec.md, README.md
└── WpfTest/                  # єдиний проєкт
    ├── WpfTest.csproj
    ├── App.xaml / App.xaml.cs        # точка входу, ініціалізація БД
    ├── MainWindow.xaml / .xaml.cs    # головне вікно (поки порожнє)
    ├── MyDataContext.cs              # EF Core DbContext
    └── Entities/                     # сутності БД
        ├── TestEntity.cs
        ├── QuestionEntity.cs
        ├── AnswerEntity.cs
        ├── TestResultEntity.cs
        └── TestResultAnswerEntity.cs
```

## Модель даних

```
TestEntity 1 ── * QuestionEntity 1 ── * AnswerEntity
    │                                        │
    1                                        1
    │                                        │
    * TestResultEntity 1 ── * TestResultAnswerEntity (SelectedAnswer)
```

| Сутність | Таблиця | Основні поля | Обмеження |
|---|---|---|---|
| `TestEntity` | `Tests` | `Title`, `Description`, `CreatedAt`, `TimeLimitMinutes` | `Title` ≤ 200, `Description` ≤ 1000, ліміт часу 1–60 хв (необов'язковий) |
| `QuestionEntity` | `Questions` (назва з `DbSet`) | `Text`, `TestId` | `Text` ≤ 1000 |
| `AnswerEntity` | `Answers` | `Text`, `IsCorrect`, `QuestionId` | `Text` ≤ 500 |
| `TestResultEntity` | `TestResultEntity` | `TestId`, `LastName`, `FirstName`, `MiddleName`, `CorrectAnswersCount`, `WrongAnswersCount`, `StartedAt`, `FinisheddAt` | імена ≤ 100, `MiddleName` необов'язкове |
| `TestResultAnswerEntity` | `tblTestResultAnswers` | `TestResultId`, `SelectedAnswerId`, `IsCorrect` | — |

Питання може мати кілька правильних відповідей: правильність задається прапорцем `AnswerEntity.IsCorrect`, а не полем у питанні.

## Основні архітектурні рішення

1. **Code First + data annotations.** Схема БД описується атрибутами (`[Key]`, `[Required]`, `[StringLength]`, `[ForeignKey]`, `[Table]`) прямо в сутностях. Fluent API (`OnModelCreating`) не використовується.
2. **`EnsureCreated` замість міграцій.** У `App.OnStartup` викликається `Database.EnsureCreated()`, тому таблиці створюються при першому запуску. Наслідок: зміни в сутностях не застосовуються до вже існуючого `MyTest.db`, і файл треба видалити (або перейти на міграції).
3. **Початкові дані (seed) у коді.** Якщо таблиця `Tests` порожня, при старті додається тест «Основи C#».
4. **Підключення до БД захардкоджене.** `OnConfiguring` використовує `Data Source=MyTest.db` (шлях відносно робочої директорії, зазвичай `bin/Debug/net9.0-windows/`). Немає `appsettings` і DI: контекст створюється через `new MyDataContext()`.
5. **Ручний запуск вікна.** В `App.xaml` немає `StartupUri`, тому `MainWindow` створюється й показується в `OnStartup` після ініціалізації БД.
6. **Code-behind замість MVVM.** На даний момент логіка розміщується у code-behind файлах.

## Відомі проблеми

- `TestResultAnswerEntity` не зареєстрована як `DbSet` у `MyDataContext` і недосяжна через навігаційні властивості, тому її таблиця не створюється.
- `TestResultEntity` не має колекції відповідей (`TestResultAnswerEntity`), а `TestEntity` не має колекції результатів.
- Друкарська помилка в назві властивості `FinisheddAt` (стане назвою колонки в БД).
- `CreatedAt` / `FinisheddAt` беруть локальний час (`DateTime.Now`), але позначають його як UTC (`DateTimeKind.Utc`). Правильніше використовувати `DateTime.UtcNow`.
- Непослідовні назви таблиць (`Tests`, `TestResultEntity`, `tblTestResultAnswers`).
- Для колекцій навігації задано значення `= null!` замість `= new List<...>()`, тож без `Include` звернення до них дасть `NullReferenceException`.
- `App.OnStartup` при кожному запуску показує діагностичний `MessageBox` з кількістю тестів.
- `MyDataContext` не звільняється (`using`).
