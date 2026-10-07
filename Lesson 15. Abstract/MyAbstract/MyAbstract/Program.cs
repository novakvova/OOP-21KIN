// See https://aka.ms/new-console-template for more information

using MyAbstract;
using System.Text;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("-- Абстрактні класи --");

//Не можна створювати екземпляри даного класу
//People vlad = new People();

//People semen = new Student();
//semen.ViewInfo();
People peter = new Student(true);
peter.ViewInfo();