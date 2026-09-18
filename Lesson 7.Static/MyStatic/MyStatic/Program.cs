// See https://aka.ms/new-console-template for more information
using MyStatic;
using System.Text;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("-- Ключове слова static --");
//Статичні методи можна викликати без потреби створення екземпляку класу.
//Наприклад. Parse - це статичний метод, який перетворює рядок у число
int a = int.Parse("12");
Console.WriteLine("a = {0}", a); //замість {0} - буде підставлятися параметр після коми

//Змінити роботу метода ParseToInt, щоб міг числа s18-> 18,
//а число 23e45 -> 2345 = парс працював завжди

int s = MyParser.ParseToInt("23хряк9");
Console.WriteLine("My Parse result = "+ s);
