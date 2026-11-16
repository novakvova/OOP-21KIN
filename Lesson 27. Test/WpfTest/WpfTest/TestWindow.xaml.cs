using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;
using WpfTest.Entities;

namespace WpfTest;

public partial class TestWindow : Window
{
    private readonly int _testId; // ID обраного тесту
    private readonly string _lastName; // прізвище користувача
    private readonly string _firstName; // ім'я користувача
    private readonly string? _middleName; // по батькові користувача (може бути null)
    private readonly DateTime _startedAt; // точний час початку проходження тесту

    private readonly string _testTitle; // назва тесту
    private readonly List<QuestionEntity> _questions; // список усіх питань тесту
    private readonly List<TestResultAnswerEntity> _userAnswers = new(); // список вибраних відповідей для збереження в БД

    private readonly DispatcherTimer _timer = new(); // таймер, який оновлює час щосекунди
    private readonly bool _hasTimeLimit; // прапорець: чи встановлено обмеження часу для тесту
    private TimeSpan _remainingTime; // скільки часу залишилося до кінця (якщо є ліміт)
    private bool _isFinished; // прапорець, щоб тест не завершився двічі (наприклад, і по кнопці, і по таймеру)

    private int _index; // індекс поточного питання
    private int _correct; // кількість правильних відповідей
    private int _wrong; // кількість неправильних відповідей

    public TestWindow(int testId, string lastName, string firstName, string? middleName = null)
    {
        InitializeComponent(); // ініціалізація візуальних компонентів вікна

        // зберігаємо передані дані про тест та користувача
        _testId = testId;
        _lastName = lastName;
        _firstName = firstName;
        _middleName = middleName;
        _startedAt = DateTime.UtcNow; // фіксуємо час старту тесту

        using var db = new MyDataContext(); // відкриваємо підключення до бази даних
        // завантажуємо обраний тест разом із його питаннями та варіантами відповідей
        var test = db.Tests
            .Include(t => t.Questions) // підтягуємо питання
            .ThenInclude(q => q.Answers) // підтягуємо варіанти відповідей до кожного питання
            .First(t => t.Id == testId); // шукаємо саме той тест, який обрали у BeginWindow

        _testTitle = test.Title; // запам'ятовуємо назву тесту
        _questions = test.Questions.OrderBy(q => q.Id).ToList(); // сортуємо питання за Id та зберігаємо у список
        Title = _testTitle; // встановлюємо заголовок вікна

        // перевіряємо, чи має тест обмеження у часі
        if (test.TimeLimitMinutes.HasValue && test.TimeLimitMinutes.Value > 0)
        {
            _hasTimeLimit = true; // вмикаємо режим зворотного відліку
            _remainingTime = TimeSpan.FromMinutes(test.TimeLimitMinutes.Value); // переводимо хвилини у формат часу
        }

        _timer.Interval = TimeSpan.FromSeconds(1); // задаємо інтервал спрацьовування таймера — 1 секунда
        _timer.Tick += Timer_Tick; // підписуємо метод Timer_Tick на кожну секунду таймера
        UpdateTimerText(); // одразу виводимо початковий час на екран
        _timer.Start(); // запускаємо таймер

        ShowQuestion(); // відображаємо перше питання
    }

    // Метод, який викликається таймером кожну секунду
    private void Timer_Tick(object? sender, EventArgs e)
    {
        if (_hasTimeLimit) // якщо тест на час
        {
            _remainingTime = _remainingTime.Subtract(TimeSpan.FromSeconds(1)); // віднімаємо 1 секунду
            if (_remainingTime <= TimeSpan.Zero) // якщо час вийшов
            {
                _remainingTime = TimeSpan.Zero; // обнуляємо залишок, щоб не пішло в мінус
                UpdateTimerText(); // оновлюємо текст на 00:00
                MessageBox.Show("Час на проходження тесту вичерпано!", "Час вийшов",
                    MessageBoxButton.OK, MessageBoxImage.Information); // повідомляємо користувача
                ShowResult(); // примусово завершуємо тест і зберігаємо результат
                return;
            }
        }

        UpdateTimerText(); // оновлюємо відображення часу на екрані
    }

    // Оновлення тексту таймера у правому верхньому куті
    private void UpdateTimerText()
    {
        if (_hasTimeLimit) // якщо є ліміт часу — показуємо зворотний відлік
        {
            TimerText.Text = $"Залишилось: {(int)_remainingTime.TotalMinutes:D2}:{_remainingTime.Seconds:D2}";
        }
        else // якщо ліміту немає — показуємо, скільки часу вже минуло від початку
        {
            var elapsed = DateTime.UtcNow - _startedAt;
            TimerText.Text = $"Час: {(int)elapsed.TotalMinutes:D2}:{elapsed.Seconds:D2}";
        }
    }

    // Відображення поточного питання та варіантів відповідей
    private void ShowQuestion()
    {
        var question = _questions[_index]; // беремо поточне питання за індексом

        ProgressBar.Maximum = _questions.Count; // задаємо максимум шкали прогресу
        ProgressBar.Value = _index; // оновлюємо заповнення шкали
        ProgressText.Text = $"Питання {_index + 1} з {_questions.Count}"; // виводимо номер поточного питання
        QuestionText.Text = question.Text; // виводимо текст питання

        AnswersPanel.Children.Clear(); // очищаємо панель від кнопок попереднього питання
        // якщо правильна відповідь одна — ставимо RadioButton, якщо кілька — CheckBox
        bool singleChoice = question.Answers.Count(a => a.IsCorrect) == 1;
        foreach (var answer in question.Answers.OrderBy(a => a.Id)) // перебираємо всі варіанти відповідей
        {
            ToggleButton option = singleChoice
                ? new RadioButton() // круглий перемикач (один варіант)
                : new CheckBox(); // прапорець (кілька варіантів)
            option.Content = answer.Text; // записуємо текст відповіді
            option.Tag = answer; // прив'язуємо сам об'єкт AnswerEntity до кнопки
            option.Margin = new Thickness(0, 4, 0, 4); // додаємо відступи зверху і знизу
            AnswersPanel.Children.Add(option); // додаємо кнопку на екран
        }

        // якщо питання останнє — змінюємо текст кнопки на "Завершити", інакше — "Далі"
        NextButton.Content = _index == _questions.Count - 1 ? "Завершити" : "Далі";
    }

    // Обробка натискання кнопки "Далі" / "Завершити"
    private void NextButton_Click(object sender, RoutedEventArgs e)
    {
        if (_isFinished) return; // якщо тест уже завершено — ігноруємо натискання

        var question = _questions[_index]; // отримуємо поточне питання

        // збираємо всі варіанти, які позначив користувач
        var selected = AnswersPanel.Children.OfType<ToggleButton>()
            .Where(c => c.IsChecked == true) // беремо тільки позначені кнопки
            .Select(c => (AnswerEntity)c.Tag) // дістаємо прив'язані до них сутності відповідей
            .ToList();

        // додаємо кожну обрану відповідь у загальний список для подальшого запису в БД
        foreach (var answer in selected)
        {
            _userAnswers.Add(new TestResultAnswerEntity
            {
                SelectedAnswerId = answer.Id,
                IsCorrect = answer.IsCorrect
            });
        }

        // перевіряємо правильність відповіді на питання:
        // вибрано хоч один варіант, усі вибрані правильні, і вибрано всі правильні варіанти
        var correctCount = question.Answers.Count(a => a.IsCorrect);
        bool isCorrect = selected.Count > 0
            && selected.All(a => a.IsCorrect)
            && selected.Count == correctCount;

        if (isCorrect) _correct++; // зараховуємо правильну відповідь
        else _wrong++; // зараховуємо помилку

        _index++; // переходимо до наступного питання
        if (_index < _questions.Count) // якщо питання ще не закінчилися
        {
            ShowQuestion(); // показуємо наступне питання
            return;
        }

        ShowResult(); // якщо це було останнє питання — підбиваємо підсумки
    }

    // Завершення тесту, виведення результатів та збереження в БД
    private void ShowResult()
    {
        if (_isFinished) return; // захист від повторного виклику
        _isFinished = true; // позначаємо, що тест завершено

        _timer.Stop(); // зупиняємо таймер

        // якщо тест завершився достроково через таймер, усі невідповідані питання рахуємо як неправильні
        _wrong = _questions.Count - _correct;

        // обчислюємо загальний витрачений час
        var spentTime = DateTime.UtcNow - _startedAt;
        string formattedSpentTime = $"{(int)spentTime.TotalMinutes:D2}:{spentTime.Seconds:D2}";

        // оновлюємо інтерфейс вікна під завершений стан
        ProgressBar.Value = _questions.Count;
        ProgressText.Text = $"Пройдено {_questions.Count} з {_questions.Count}";
        TimerText.Text = $"Час: {formattedSpentTime}";
        QuestionText.Text = string.Empty;
        AnswersPanel.Children.Clear();
        NextButton.IsEnabled = false;

        SaveResultToDatabase(); // зберігаємо результати у SQLite

        // показуємо вікно з підсумковою статистикою
        MessageBox.Show(
            $"Користувач: {_lastName} {_firstName}\n" +
            $"Тест: {_testTitle}\n" +
            $"Правильних відповідей: {_correct}\n" +
            $"Неправильних відповідей: {_wrong}\n" +
            $"Всього питань: {_questions.Count}\n" +
            $"Витрачений час: {formattedSpentTime}",
            "Результат");
    }

    // Запис загального результату та вибраних відповідей у базу даних
    private void SaveResultToDatabase()
    {
        using var db = new MyDataContext(); // відкриваємо контекст БД

        // формуємо запис про спробу проходження тесту
        var testResult = new TestResultEntity
        {
            TestId = _testId,
            LastName = _lastName,
            FirstName = _firstName,
            MiddleName = _middleName,
            CorrectAnswersCount = _correct,
            WrongAnswersCount = _wrong,
            StartedAt = _startedAt,
            FinisheddAt = DateTime.UtcNow // фіксуємо час завершення
        };

        db.TestResults.Add(testResult); // додаємо результат у таблицю TestResultEntity
        db.SaveChanges(); // зберігаємо, щоб БД згенерувала Id для testResult

        // прив'язуємо кожну відповідь користувача до згенерованого Id результату
        foreach (var userAnswer in _userAnswers)
        {
            userAnswer.TestResultId = testResult.Id;
        }

        db.TestResultAnswers.AddRange(_userAnswers); // додаємо всі відповіді користувача у таблицю tblTestResultAnswers
        db.SaveChanges(); // зберігаємо відповіді в БД
    }

    // Зупиняємо таймер, якщо користувач закрив вікно хрестиком під час тесту
    protected override void OnClosed(EventArgs e)
    {
        _timer.Stop();
        base.OnClosed(e);
    }
}