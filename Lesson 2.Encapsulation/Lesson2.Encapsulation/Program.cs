
using Lesson2.Encapsulation;
using System.Text;

class Program
{
    public static void Main(string[] args)
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("---Інкапсуляція С#---");
        Car car = new Car(); //Створили авто
                             //scenic.Mark = "Renault";
                             //scenic.Model = "Scenic";
                             //scenic.Color = "Синій";

        Console.WriteLine("Вкажіть марку:");
        string temp = Console.ReadLine();
        car.SetMark(temp);

        Console.WriteLine("Вкажіть модель:");
        temp = Console.ReadLine();
        //car.SetMark("Renault");
        car.SetModel(temp);

        Console.WriteLine("Вкажіть колір:");
        temp = Console.ReadLine();
        car.SetColor(temp);

        Console.WriteLine("Вкажіть ціну:");
        temp = Console.ReadLine();
        car.SetPrice(Decimal.Parse(temp));

        car.View();

        //Console.WriteLine($"{scenic.Mark}\t{scenic.Model}\t{scenic.Color}");

    }
}

