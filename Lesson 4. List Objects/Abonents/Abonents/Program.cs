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

//List<Abonent> items = new List<Abonent>();
//Console.WriteLine("Вкажіть ПІБ:");
//string pib = Console.ReadLine();
//Console.WriteLine("Вкажіть телефон:");
//string phone = Console.ReadLine();
//Console.WriteLine("Вкажіть адресу:");
//string address = Console.ReadLine();
//items.Add(new Abonent(pib, phone, address));

//foreach(var banan in items)
//{
//    Console.WriteLine(banan);
//}

//Тестую роботу з файлом
string fileName = "salo.txt";

//Abonent petro = new Abonent("Мельник Петро Васильови", 
//    "+380 96 78 78 475", "м.Рівне вул. Козаків 22");
//В даному випадку ми явно вказуємо до якого параметру,яке поле відноситься
//Abonent petro = new Abonent(
//    pib: "Мельник Петро Васильович",
//    phone: "+380 96 78 78 475", 
//    address: "м.Рівне вул. Козаків 22"
//    );

//Abonent vova = new Abonent(
//    pib: "Новак Володимир",
//    phone: "+380 96 78 67 475",
//    address: "м.Козаків вул. Набержна 23"
//    );

//// \n - перехід на новий рядок \r - на початок рядка
////string newLine = "\r\n";
//string strLine = vova.GetFileString() + Environment.NewLine; //Отримую інформацію про абонента

//File.AppendAllText(fileName, strLine, Encoding.UTF8);

string[] lines = File.ReadAllLines(fileName);
foreach (string line in lines)
{
    if(string.IsNullOrEmpty(line)) 
        continue; //пропускаємо пустий рядок
    Abonent item = Abonent.FromFileString(line);
    Console.WriteLine(item);
}




