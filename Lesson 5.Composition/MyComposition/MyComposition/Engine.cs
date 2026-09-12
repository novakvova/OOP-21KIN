namespace MyComposition;

/// <summary>
/// Двигун автомобіля
/// </summary>
class Engine
{
    /// <summary>
    /// Модель двигуна - M274 
    /// </summary>
    private string _model;
    /// <summary>
    /// Об'єм двигуна
    /// </summary>
    private double _volume;
    /// <summary>
    /// Кількість конячих сил
    /// </summary>
    private int _horsePoser;
    /// <summary>
    /// Крутий момент - тяга
    /// </summary>
    private int _torque;
    /// <summary>
    /// Тип пального
    /// </summary>
    private string _fuilType;
    /// <summary>
    /// Кількість циліндрів
    /// </summary>
    private int _cylinders;

    //починамо з конструктора по замовчуванню ctor
    public Engine()
    {
        _model = "OM654";
        _volume = 2.0; //об'єм двигуна
        _horsePoser = 194;
        _torque = 400;
        _fuilType = "Disel";
        _cylinders = 4;
    }

    //Констурктор з параметрами
    public Engine(string model, 
        double volume, 
        int horsePower, 
        int torque, 
        string fuelType, 
        int cylinders)
    {
        _model = model;
        _volume = volume;
        _horsePoser = horsePower;
        _torque = torque;
        _fuilType = fuelType;
        _cylinders = cylinders;
    }

    public override string ToString()
    {
        return $"Engine: {_model}, " +
            $"Volume: {_volume}, " +
            $"Horsepower: {_horsePoser}, " +
            $"Torque: {_torque}, " +
            $"Fuel Type: {_fuilType}, " +
            $"Cylinders: {_cylinders}";
    }
}
