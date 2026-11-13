using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.IO;
using System.Windows;
using WpfTest.Entities;
using WpfTest.Models;

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

        if (fileData.Tests.Any() == false)
        {
            var dir = Directory.GetCurrentDirectory();
            var path = System.IO.Path.Combine(dir, "SeedData", "users.json");

            if (!System.IO.File.Exists(path))
            {
                MessageBox.Show("Файл із даними не знайдено!");
                return;
            }
            var json = File.ReadAllText(path);

            var seedTests = JsonConvert.DeserializeObject<List<TestSeedModel>>(json)
                ?? new List<TestSeedModel>();

            foreach (var seed in seedTests)
            {

                var test = new TestEntity { Title = seed.Title, CreatedAt = DateTime.UtcNow };
                fileData.Tests.Add(test);

                test.Description = seed.Description;
                test.TimeLimitMinutes = seed.TimeLimitMinutes;
                for (var i = 0; i < seed.Questions.Count; i++)
                {
                    var q = seed.Questions[i];
                    test.Questions.Add(new QuestionEntity
                    {
                        Text = q.Text,
                        Answers = q.Answers
                            .Select(a => new AnswerEntity { Text = a.Text, IsCorrect = a.IsCorrect })
                            .ToList()
                    });
                }
            }

            fileData.SaveChanges();
        }

        //int countTest = fileData.Tests.Count();
        //MessageBox.Show("Кількість тестів в БД: " + countTest);

        MainWindow window = new MainWindow();
        window.Show();
    }
}
