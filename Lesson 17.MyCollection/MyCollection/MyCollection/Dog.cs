namespace MyCollection;

public class Dog
{
    private string _name;
    private int _age;

    public Dog()
    {
        _name = "No Name";
        _age = 0;
    }
    //ctor
    public Dog(string name, int age)
    {
        _name = name;
        _age = age;
    }

    public override string ToString()
    {
        string str = "-- Собака --\n";
        str += "Name: " + _name + "\n";
        str += $"Age: {_age}";
        return str;
    }
}
