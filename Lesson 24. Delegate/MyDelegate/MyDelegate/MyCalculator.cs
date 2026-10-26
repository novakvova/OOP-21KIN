namespace MyDelegate;

//Хочу зробити вказівник на метод, додавання або віднімання
public delegate int MyOperationDelegate(int a, int b);

public class MyCalculator
{
    //статичні методи класу 
    //Це методи, які можна виклати без потреби створення
    //самого об'єкта
    public static int Add(int x, int y)
    {
        return x + y;
    }
    //Новий спосіб запиму метода
    public static int Subtract(int x, int y) => x - y;

}
