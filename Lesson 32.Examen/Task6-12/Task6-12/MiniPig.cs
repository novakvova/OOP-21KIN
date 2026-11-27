using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_12;


public class MiniPig
{
    //Для усіх об'єктів даного класу, ця змінна буде єдина
    private static int _counter; //лічильник кількості
    private string _name;
    private int _age;
    private string _color;
    private string _breed;

    //конструктор - це ініціалізація об'єктра при створені
    //по замовчуванню
    //з параметрами
    //статичний
    //копіювання
    public MiniPig()
    {
        _name = _breed = _color = "No data";
        _age = 1;
        _counter++; //збільшуємо чільник об'єктів на 1
    }
    public MiniPig(string name, int age, string color, string breed)
        : this() //викликаю конструкто по замовчуванню
    {
        _name = name;
        _age = age;
        _color = color;
        _breed = breed;
    }
    public MiniPig(MiniPig miniPig)
        : this() //викликаю конструкто по замовчуванню
                 //конструктор копіювання
    {
        _name = miniPig._name;
        _age = miniPig._age;
        _breed = miniPig._breed;
        _color = miniPig._color;
    }
    //її можна викликати без потреби створення екземпаляра класу
    public static int Counter //статична властивість
    {
        get { return _counter; }
    }
    

    public override string ToString()
    {
        return $"Назва: {_name}\tВік:{_age}\tПорода:{_breed}\tКолір:{_color}";
    }
}
