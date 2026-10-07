
using MyCollection;
using System.Text;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("-- Колекція об'єктів --");

//List<int> items = new List<int>();
//items.Add(23);
//items.Add(18);

MyGeneric myList = new MyGeneric();

myList.Add(12);
myList.Add(23);
myList.Add(16);
myList.Add("Світлана");
myList.Add("Надія");
myList.Add(false);
if (1 == 1)
{
    Dog barbos = new Dog("Барбос", 3);
    myList.Add(barbos);
}

myList.ViewItems();

var item = myList.Find(12);
Console.WriteLine("Find 12 "+item);

item = myList.Find("Надія");


//item = myList.Find(barbos);
//Console.WriteLine("Find \"Надія\" " + item);
