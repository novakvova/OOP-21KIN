using System.Windows;
using WpfTest.Entities;

namespace WpfTest;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        MyDataContext fileData = new MyDataContext();
        fileData.Database.EnsureCreated();

        if(fileData.Tests.Any() == false)
        {
            TestEntity test = new TestEntity();
            test.Title = "Основи C#";
            test.Description = "Перевіряє знання по рівню C# - Змінні, Оператори умови, Цикли";
            test.TimeLimitMinutes = 15;
            fileData.Tests.Add(test);
            fileData.SaveChanges();
        }

        int countTest = fileData.Tests.Count();
        MessageBox.Show("Кількість тестів в БД: " + countTest);

        MainWindow window = new MainWindow();
        window.Show();
    }
}
