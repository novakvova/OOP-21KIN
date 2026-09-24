namespace ExampleProtected;

public class Smartphone : Device
{
    //унікальне для smartphone
    private string _cpu; // Центральний процесор
    private string _memory; //оперативка
    private string _storage; // розмір ssd
    private float _screenSize; // розмір екрану
    public Smartphone() : base() // викликаємо базовий конструктор
    {

    }

    public Smartphone(string brand, string model, decimal price,
        string cpu, string memory, string storage, float screenSize)
    {
        _brand = brand;
        _model = model;
        _price = price;
        _cpu = cpu;
        _memory = memory;
        _storage = storage;
        _screenSize = screenSize;
    }

    public override string ToString()
    {
        string str = base.ToString();
        return $"{str}\nCPU: {_cpu}\tMemory: {_memory}\tStorage: {_storage}\tЕкран:{_screenSize}";
    }
}
