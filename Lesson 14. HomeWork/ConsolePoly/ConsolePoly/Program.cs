using System.Text;  
using System.IO;
using System.Collections.Generic;
using Bogus;
using ConsolePoly;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;
string file = "data.txt"; // Наша БД

var studentFaker = new Faker<Student>("uk") // 
    //Налаштовуємо генератора для студентів
    .CustomInstantiator(f => new Student( //Буде створюватися новий студент
        f.Name.FullName(), // Генеруємо випадкове ім'я
        (ushort)f.Random.Number(17, 25), // Вік від 17 до 25 років
        Math.Round(f.Random.Double(60, 100), 1) //оціна буде від 60 до 100 балів
    ));

var teacherFaker = new Faker<Teacher>("uk")
    .CustomInstantiator(f => new Teacher(
        f.Name.FullName(),  // Генеруємо випадкове ім'я
        (ushort)f.Random.Number(30, 65), // Вік від 30 до 65 років
        f.Random.Decimal(18000, 45000) // Зарплата від 18000 до 45000 в грн.
    ));

List<People> original = new();
Random rnd = new();

for (int i = 0; i < 10; i++)
{
    People p = rnd.Next(2) == 0 ? studentFaker.Generate() : teacherFaker.Generate();
    original.Add(p);
}

using (StreamWriter w = new(file))
{
    // У пеший рядок файлу ми записуємо кількість об'єктів
    // Це у нас Teacher або Student, які ми зберігаємо у файл
    w.WriteLine(original.Count);
    foreach (var p in original) p.Save(w);
} //після цих дужок буде видалятися об'єкт StreamWriter і закриватися файл


List<People> loaded = new();
using (StreamReader r = new(file))
{

    int count = int.Parse(r.ReadLine()!);
    //Тут ми згідно кількості перебираємо наші елементи
    for (int i = 0; i < count; i++)
    {
        //Ми проводили запис - назви типу
        string type = r.ReadLine()!;
        //Створюємо тип. який було записано у файл
        People p = type == nameof(Student) ? new Student() : new Teacher();
        //Дочірній клас читає про себе інформацію з файлу
        p.Load(r);
        //Зберігаємо прочитаний об'єкт у наш список
        loaded.Add(p);
    }
}
// Виводимо на екран прочитані дані
Console.WriteLine("==== Зчитані дані з файлу ====");
// LINQ
//loaded.ForEach(p => p.ViewInfo());
foreach(People p in loaded)
{
    p.ViewInfo();
}