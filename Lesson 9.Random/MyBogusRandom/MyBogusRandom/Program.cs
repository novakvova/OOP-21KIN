// See https://aka.ms/new-console-template for more information
using Bogus;
using MyBogusRandom;
using System.Text;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

//
Console.WriteLine("-- Геренрація випадкових величин --");

List<People> list = new List<People>();

var facker = new Faker("uk");
for (int i = 0; i < 10; i++)
{
    var name = facker.Name.FullName();
    //Console.WriteLine("Full name " + name);
    People item = new People
    {
        Age = facker.Random.Int(16, 45),
        FullName = facker.Name.FullName(),
        Phone = facker.Phone.PhoneNumber()
    };
    list.Add(item);
}

foreach (var item in list)
{
    Console.WriteLine(item);
}

//Laptop
Laptop hpBase = new Laptop
{
    CPU = "Intel Core Ultra 7 255H (1.5 - 5.1 ГГц)",
    RAM = 16,
    SSD = 512,
    ScreenSize = 16.0,
    Brand = "HP",
    Model = "HP ProBook 4 G1i ",
    Price = 70655
};

Console.WriteLine(hpBase);

Laptop baseDell = new Laptop
{
    CPU = "Intel Core Ultra 7 155H",
    RAM = 16,
    SSD = 512,
    ScreenSize = 15.6,
    Brand = "Dell",
    Model = "Precision 3590",
    Price = 74999
};
Console.WriteLine(baseDell);

//facker.
