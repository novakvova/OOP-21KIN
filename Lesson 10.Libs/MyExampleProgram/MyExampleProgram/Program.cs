// See https://aka.ms/new-console-template for more information

using LibAbonent;
using System.Text;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("-- Розробка проекту з декількома бібліотеками --");

var list = new List<Kyivstar>();
for (int i = 0; i < 5; i++)
{
    list.Add(new Kyivstar());
}

foreach (var phone in list)
{
    Console.WriteLine(phone);
}