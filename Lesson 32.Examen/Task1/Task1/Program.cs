// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Text;
using Task1;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;
Console.WriteLine("1.Які методи містяться у базовому класі System.Object?");

ArrayList list = new ArrayList();
list.Add(12);
list.Add("Сало");
list.Add(new Cat("Вова", 12, true));

List<Cat> items = new List<Cat>();
items.Add(new Cat("Рижий", 1, true));

Cat murchuk = new Cat("Мохнатий", 2, true);
Cat sveta = new Cat("Свєта", 2, true);

Console.WriteLine(sveta);
Console.WriteLine(murchuk);

if(sveta.Equals(murchuk))
{
    Console.WriteLine("sveta == murchuk");
}
else
{
    Console.WriteLine("sveta != murchuk");
}