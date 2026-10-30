// See https://aka.ms/new-console-template for more information

using System.Text;

namespace ExampleLambda;

class Program
{
    public delegate void MessageDelegate(string text); //Наш делегат
    //Делегати призначені для створення подій
    //Ми можемо створити вказівник на метод, при цьому потрібно, даний метод
    //Реєструватися, а потім викликати
    //private static MessageDelegate displayInfo; //Делегат виводу повідомлень
    private static event MessageDelegate myDisplayDelegate;

    public static void Main()
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("Працюємо із Подіями та Лямбда виразами!");
        //displayInfo = MyDispalyOled; //Вказує на статичний метод
        //displayInfo("-Потрібно заправити бака-");
        myDisplayDelegate += MyViewInfoConsole;
        myDisplayDelegate += MyViewMessageBox;
        myDisplayDelegate -= MyViewInfoConsole; //відвязав вказівник від 1 методу
        myDisplayDelegate("Вибухнув двигун :)");
    }

    private static void MyViewInfoConsole(string text)
    {
        Console.WriteLine("-------Console info-----");
        Console.WriteLine(text);
        Console.WriteLine("-------------------------");
    }

    private static void MyViewMessageBox(string text)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" -- " + text + " -- ");
        Console.ForegroundColor = ConsoleColor.White;
    }

    //public static void MyDispalyOled(string msg)
    //{
    //    Console.WriteLine("----------");
    //    Console.WriteLine(msg);
    //    Console.WriteLine("----------");
    //}
}




