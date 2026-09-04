using System.Collections.Specialized;

namespace Lesson2.Encapsulation;

class Car
{
    //Модель: Scenic
    private string _model = null!; //_ належить даному класу
    //Марка: Renault
    private string _mark = null!;
    //Колір: Коричневий, Синій
    private string _color = null!;
    //Ціна авто
    private decimal _price; //Ціна авто

    public void SetModel(string model) //Робимо спеціальну змінну, яка надає значення model
    {

        _model = model;
    }
    public void SetMark(string mark)
    {
        //Наш завод уміє виготовляти лише автомобілі марки Renault
        if(mark == "Renault")
            _mark = mark;
        else
        {
            Console.WriteLine("---Не допустима марка автомобіля!---");
        }
    }
    public void SetColor(string color)
    {
        _color = color;
    }
    
    public void SetPrice(decimal price)
    {
        if(price < 0)
        {
            Console.WriteLine("---Ціна авто не може бути меншою 0---");
            return;
        }
        _price = price; // Зберігаємо ціну
    }
    
    //Спеціальна функція, яка виводить дані про авто
    public void View() // Прийдумав таку функцію - метод
    {
        Console.WriteLine($"{_mark}\t{_model}\t{_color}\tЦіна: {_price}");
    }
}
