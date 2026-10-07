using Microsoft.EntityFrameworkCore;

namespace MyTemplates;

public class MyDataContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Назвай файлу де зберігаються користувачів
        optionsBuilder.UseSqlite("Data Source=MyDatabase.db");
    }
}
