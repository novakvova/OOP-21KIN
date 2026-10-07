
using MyCollection;
using System.Text;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("-- Колекція об'єктів --");

//List<int> items = new List<int>();
//items.Add(23);
//items.Add(18);
/*
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
*/

int action = 0;
MyGeneric myList = new MyGeneric();
do
{
    Console.WriteLine("0. Вийти");
    Console.WriteLine("1. Додати тварину у притулок");
    Console.WriteLine("2. Показати усіх тварин притулку");
    Console.WriteLine("3. Пошук тварини");
    Console.Write("Виберіть дію: ");
    action = int.Parse(Console.ReadLine());
    switch(action)
    {
        case 1:
            AddAnimal();
            break;
        case 2:
            myList.ViewItems();
            break;
        case 3:
            FindAnimal();
            break;
        default:
            Console.WriteLine("Допобачення");
            return;
    }

} while (action != 0);


void AddAnimal()
{
    Console.Write("Введіть ім'я тварини: ");
    string name = Console.ReadLine();
    Console.Write("Введіть вік тварини: ");
    int age = int.Parse(Console.ReadLine());
    Animal dog = new Dog(name, age);
    myList.Add(dog);
}

void FindAnimal()
{
    Console.Write("Введіть ім'я тварини: ");
    string name = Console.ReadLine();
    Console.Write("Введіть вік тварини: ");
    int age = int.Parse(Console.ReadLine());
    Dog dog = new Dog(name, age);
    var foundDog = myList.Find(dog); //Це буде шукати нашого собаку у колекції
    if (foundDog != null)
    {
        Console.WriteLine("Тварина знайдена: " + foundDog);
    }
    else
    {
        Console.WriteLine("Тварина не знайдена");
    }
}