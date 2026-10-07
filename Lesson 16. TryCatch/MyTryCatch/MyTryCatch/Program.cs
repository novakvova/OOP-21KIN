// See https://aka.ms/new-console-template for more information

using MyTryCatch;
using System.Text;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("-- Робота із виключеннями is as --");

List<Electronic> items = new List<Electronic>();

Random rand = new Random();
int n = 10;
for (int i = 0; i < n; i++)
{
    if(rand.Next(0,2) == 0)
    {
        items.Add(new Laptop());
    }
    else 
    {  
        items.Add(new PC()); 
    }
}
//Хочу підрахувати скільки Laptop і скільки PC
int countLaptop = 0;
int countPC = 0;
foreach (Electronic item in items)
{
    if (item is PC)
        countPC++;
    else if (item is Laptop)
        countLaptop++;
}
Console.WriteLine($"count PC:{countPC}");
Console.WriteLine($"count Laptop:{countLaptop}");

foreach (Electronic item in items)
{
    if(item is Laptop)
    {
        Laptop l = item as Laptop;
        Console.WriteLine($"Має Laptop із діагоналю: {l.Display}");
    }
}
try
{
    Electronic el = new Laptop();
    el.PrintInfo(); //тут буде помилка
}
catch(Exception ex)
{
    Console.WriteLine("Щось пішло не так: {0}", ex.Message);
}





