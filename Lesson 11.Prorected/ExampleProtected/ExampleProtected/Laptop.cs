namespace ExampleProtected;

public class Laptop : Device
{
    private string _cpu;
    private string _memory;
    private string _storage;
    private string _display;
    public Laptop() : base() // викликаємо базовий конструктор
    {

    }

    public Laptop(string brand, string model, decimal price,
        string cpu, string memory, string storage, string display)
    {
        _brand = brand;
        _model = model;
        _price = price;
        _cpu = cpu;
        _memory = memory;
        _storage = storage;
        _display = display;
    }

    public override string ToString()
    {
        string str = base.ToString();
        return $"{str}\n CPU: {_cpu}\t Memory: {_memory}\t Storage: {_storage}\t Екран: {_display}";
    }

}
