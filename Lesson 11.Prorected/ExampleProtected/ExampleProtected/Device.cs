namespace ExampleProtected;

public class Device
{
    protected string _brand = null!;
    protected string _model = null!;
    protected decimal _price;

    public Device()
    {
        _brand = "Unknown";
        _model = "Unknown"; 
        _price = 0.0M; // 0.0M - decimal literal - фінанси
    }

    public override string ToString()
    {
        return $"Brand: {_brand}\tModel: {_model}\t Price: {_price}";
    }

}
