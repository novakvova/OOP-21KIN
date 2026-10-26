// See https://aka.ms/new-console-template for more information

using MyDelegate;
using System.Text;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("-- Працюємо із делегатами :) --");

//Давайте зробити вказівника на фукнцію - вказівник на фукнцію - це делегат
//Делегат - це клаас, але пишеться як функція

//int result = MyCalculator.Add(2, 7);
//Console.WriteLine("a + b = " + result);

//Це делегат, який ні на кого не вказує
//MyOperationDelegate operation = null;

//string action = string.Empty;
//Console.Write("Вкажіть, яку операцію виконати(+,-)->_");
//action = Console.ReadLine();
//if(action.Equals("+"))
//    operation = MyCalculator.Add; //делегат вказує на даний метод
//else
//    operation = MyCalculator.Subtract;
//int a, b;
//Console.Write("Вкажіть a = ");
//a = int.Parse(Console.ReadLine());
//Console.Write("Вкажіть b = ");
//b = int.Parse(Console.ReadLine());
//Console.WriteLine("Результат = " + operation(a,b));

Car bmw = new Car(220);
bmw.setDispaly(DisplayColors); //Кольоровий телевізок поставили
bmw.Gas(20);
bmw.Gas(60);
bmw.Gas(120);
bmw.Gas(230);

Car lanos = new Car(120);
//lanos.setDispaly(DisplayMonoChrome); //Чорнобілий телевізок поставили
lanos.Gas(50);
lanos.Gas(110);
lanos.Gas(150);

//монохромний дисплей
void DisplayMonoChrome(string message)
{
    Console.WriteLine("-------Сповіщеня-------");
    Console.WriteLine(message);
    Console.WriteLine("-------Будьте-уважні--------");
}

void DisplayColors(string message)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("-------Сповіщеня-------");
    Console.WriteLine(message);
    Console.WriteLine("-------Будьте-уважні--------");
    Console.ForegroundColor = ConsoleColor.White;
}
