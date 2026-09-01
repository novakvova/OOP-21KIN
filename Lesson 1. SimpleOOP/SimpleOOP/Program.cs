// See https://aka.ms/new-console-template for more information
using System.Text;

//Прості імен до якого належить код
namespace SimpleOOP
{
    class Program //Це обготка для блоку коду
    {
        //C# - це повністю Об'єктно-орієнтована мова
        //Усі зміни знаходяться в класах
        public static void Main(string[] args) //то входу - 
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("---Вітаємо в ООП---");
            //зробимо студент
            //ПІБ, age, course
            //string pib;
            //int age;
            //short course;
            //На основі класу Student створили
            //об'єкт ivan
            Student ivan = new Student();
            ivan.pib = "Мельник Іван Петрович";
            ivan.course = 3;
            ivan.age = 20;

            Console.WriteLine(ivan.pib);
            Console.WriteLine(ivan.course);
            Console.WriteLine(ivan.age);
            //15 студентів
            Student[] list = new Student[15];
            list[0].pib = "Антонюк Аліса Андріївна";
            list[0].age = 17;
            list[0].course = 2;

            Console.WriteLine(list[0].pib);
            Console.WriteLine(list[0].age);
            Console.WriteLine(list[0].course);
            

        }
    }
}


