namespace MyTryCatch;

public class Laptop : Electronic
{
    private float _display;
    //ctor
    public Laptop()
    {
        _display = 0;        
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Display: {_display}");
    }
    //Повертаємо дисплей
    public float Display { get { return _display; } }
}
