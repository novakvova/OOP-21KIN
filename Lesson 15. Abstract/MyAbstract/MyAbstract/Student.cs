using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbstract;

public class Student : People
{
    //Дата вступу в університет
    //DateTime - Зберігає дані про дату і час
    private DateTime _entryDate;
    private string _group = null!; //Група

    public Student() //батьківський конструктор автоматично
    {
        _entryDate = DateTime.Now; //Дата вступу сьогодні
        _group = "No group";
    }
    public Student(bool isRandom = false)
        : base(isRandom) //Викликаємо батьківський конструктор із параметрами
    {
        Faker faker = new Faker();
        _entryDate = faker.Date.Past(18);
        _group = "Group " + faker.Random.Int(1, 5);
    }
    public override void Hello()
    {
        Console.WriteLine("Привіт від студента :)"); ;
    }
    public override void ViewInfo()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        base.ViewInfo();
        string strDate = _entryDate.ToString("dd.MM.yyyy");
        Console.WriteLine($"Дата вступу: {strDate}");
        Console.WriteLine($"Група: {_group}");
        Console.ForegroundColor = ConsoleColor.White;

    }
}
