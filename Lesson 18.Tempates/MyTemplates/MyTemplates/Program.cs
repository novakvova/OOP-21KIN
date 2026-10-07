// See https://aka.ms/new-console-template for more information
using Bogus;
using MyTemplates;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;
Console.WriteLine("Робота із шаблонами");

//MyAnimal<int> age = new MyAnimal<int>(5);
//MyAnimal<string> name = new MyAnimal<string>("Лев");

//age.ViewData();
//name.ViewData();

MyDataContext context = new MyDataContext();
context.Database.EnsureCreated(); //Якщо бд із користувачами немає, то її створюємо

Console.WriteLine("Скільки треба додати користувачів?");
int count = int.Parse(Console.ReadLine());
Faker<UserEntity> userFaker = new Faker<UserEntity>("uk")
    .RuleFor(u => u.Name, f => f.Name.FullName())
    .RuleFor(u => u.Email, f => f.Internet.Email())
    .RuleFor(u => u.Phone, f => f.Phone.PhoneNumber());
var users = userFaker.Generate(count);

context.Users.AddRange(users);
context.SaveChanges();
///context.Users.Add(new UserEntity() 
///{ 
///    Email = "user@example.com",
///    Name = "John Doe",
///    Phone = "123-456-7890"
///});
///context.Users.Add(new UserEntity()
///{
///    Email = "jane@example.com",
///    Name = "Jane Smith",
///    Phone = "987-654-3210"
///});
///context.SaveChanges();

foreach (var user in context.Users)
{
    Console.WriteLine($"Id: {user.Id}, " +
        $"Email: {user.Email}, " +
        $"Name: {user.Name}, " +
        $"Phone: {user.Phone}");
}
