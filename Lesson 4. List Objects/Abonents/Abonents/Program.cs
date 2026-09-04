using Abonents;
using System.ComponentModel.DataAnnotations;
using System.Text;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine("--Список абонентів--");

//Abonent abonent1 = new Abonent();

//Abonent abonent2 = new Abonent("Мельник Славік",
//    "+38096 45 78 457", 
//    "м.Рівне Соборна 22");

////Console.WriteLine(abonent1); //Виклик метода - неявно
//Console.WriteLine(abonent1.ToString());
//Console.WriteLine(abonent2);

//--------------------------
//List<Abonent> list = new List<Abonent>();

//list.Add(new Abonent()); //Закинув у список одного анонімного абонента
//list.Add(new Abonent("Мельник Марко", "+38096 78 45 125",
//    "м. Здолбунів вул. Хмельницього 8"));

//Console.WriteLine("==== Список абонентів ===");
//foreach(var item in list)
//{
//    Console.WriteLine(item);
//}

List<Abonent> items = new List<Abonent>();
Console.WriteLine("Вкажіть ПІБ:");
string pib = Console.ReadLine();
Console.WriteLine("Вкажіть телефон:");
string phone = Console.ReadLine();
Console.WriteLine("Вкажіть адресу:");
string address = Console.ReadLine();
items.Add(new Abonent(pib, phone, address));

foreach(var banan in items)
{
    Console.WriteLine(banan);
}




