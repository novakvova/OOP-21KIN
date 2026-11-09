using Microsoft.EntityFrameworkCore;
using WpfTest.Entities;

namespace WpfTest;

public class MyDataContext : DbContext
{
    public DbSet<TestEntity> Tests { get; set; }
    public DbSet<QuestionEntity> Questions { get; set; }
    public DbSet<AnswerEntity> Answers { get; set; }
    public DbSet<TestResultEntity> TestResults { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Назвай файлу де зберігаються користувачів
        optionsBuilder.UseSqlite("Data Source=MyTest.db");
    }
}
