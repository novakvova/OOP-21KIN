using System.Windows;
using WpfTest.Entities;
using WpfTest.Models;
using WpfTest.Services;

namespace WpfTest;

/// <summary>
/// Стартове вікно: ввід ПІБ, вибір тесту і запуск проходження.
/// </summary>
public partial class BeginWindow : Window
{
    public BeginWindow()
    {
        InitializeComponent();

        using var db = new MyDataContext();
        TestsListBox.ItemsSource = db
            .Tests
            .OrderBy(t => t.Title)
            .Select(x=> new TestItemModel
            {
                Title = x.Title,
                Description = x.Description,
                QuestionsCount = x.Questions.Count,
                TimeLimitMinutes = x.TimeLimitMinutes.Value
            })
            .ToList();
        if (TestsListBox.Items.Count > 0)
        {
            TestsListBox.SelectedIndex = 0;
        }
    }

    private void StartButton_Click(object sender, RoutedEventArgs e)
    {
        var lastName = txtLastName.Text.Trim();
        var firstName = txtFirstName.Text.Trim();
        var middleName = txtMiddleName.Text.Trim();

        if (lastName.Length == 0 || firstName.Length == 0)
        {
            MessageBox.Show("Введіть прізвище та ім'я.", "Увага",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        if (TestsListBox.SelectedItem is not TestItemModel selected)
        {
            MessageBox.Show("Оберіть тест зі списку.", "Увага",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }
        var testWindow = new TestWindow(
            1,
            lastName,
            firstName,
            middleName.Length == 0 ? null : middleName);

        //var testWindow = new TestWindow();
        testWindow.Show();
        Close();
    }
}
