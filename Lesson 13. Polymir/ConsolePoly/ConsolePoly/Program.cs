// See https://aka.ms/new-console-template for more information

using ConsolePoly;
using System.Text;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("-- Поліморфізм --");

//Teacher vova = new Teacher();
//vova.ViewInfo(); //Не отримали інформацію про Працівника

//Bomber bomber = new Bomber();
//bomber.ViewInfo(); //Виводимо дані про Bobmer

//Реалізуємо поліморфізм
//За допомогою virtual та override

//Worker ivan = new Teacher();
//ivan.ViewInfo();

//Worker semen = new Bomber();
//semen.ViewInfo();


Console.WriteLine("Вкажіть, який працівник Вам потрібен?");
int action = 0;
Console.WriteLine("1.Teacher");
Console.WriteLine("2.Bomber");
Console.Write("->_");
action = int.Parse(Console.ReadLine());

Worker worker;
if (action == 1)
    worker = new Teacher();
else
    worker = new Bomber();

worker.ViewInfo();
