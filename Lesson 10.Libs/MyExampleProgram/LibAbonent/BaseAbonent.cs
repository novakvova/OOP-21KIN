namespace LibAbonent;

/// <summary>
/// Батьківський клас для бібліотеки LibAbonent.
/// </summary>
public class BaseAbonent //
{
	private string _name = null!;
	private string _phone = null!;
	private double _latitude; //50.612878, 
    private double _longitude; //26.227860


    public double Latitude 
    {
        get { return _latitude; }
        set { _latitude = value; }
    }   // Широта
    public double Longitude 
    {
        get { return _longitude; }
        set { _longitude = value; }
    }  // Довгота

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public string Phone
	{
		get { return _phone; }
		set { _phone = value; }
	}

}
