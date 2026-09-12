// See https://aka.ms/new-console-template for more information
using MyComposition;
using System.Text;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("--Привіт працюємо із композицією ООП--");

//створили двигуна
//Engine engine = new Engine();

//Console.WriteLine(engine);

Car car = new Car();
Console.WriteLine(car);
