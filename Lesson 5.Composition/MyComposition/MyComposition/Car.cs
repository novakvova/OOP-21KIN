namespace MyComposition;

/// <summary>
/// АВТОМОБІЛЬ
/// </summary>
class Car
{
    /// <summary>
    /// Двигун автомобіля
    /// </summary>
    private Engine _engine; //композиція - автомобіль має двигун
    private string _mark;  // марка автомобіля - BMW, Mercedes, Audi
    private string _model; // модель автомобіля - X5, C-Class, A4

    public Car()
    {
        _engine = new Engine();
        _mark = "Wolksvagen";
        _model = "Golf";
    }

    public override string ToString()
    {
        return $"Марка автомобіля: {_mark}\n" +
               $"Модель автомобіля: {_model}\n" +
               $"Двигун автомобіля:\n{_engine}";
    }
}
