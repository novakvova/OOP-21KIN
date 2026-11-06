// See https://aka.ms/new-console-template for more information
using System.Net.WebSockets;
using System.Reflection.Metadata.Ecma335;

Console.WriteLine("Hello, World!");

List<int> items = new List<int>
{ 23, 56, 4, 6, 10, 42 };

//Це готовий делегат, який вказує на фукнцію, яка вертає bool примає ціле число
//Predicate<int> predicate = isPeople;

var findItems = items.FindAll(x => x>25);

foreach(int item in findItems)
    Console.WriteLine(item);


//bool isPeople(int i)
//{
//    return i > 25;
//}