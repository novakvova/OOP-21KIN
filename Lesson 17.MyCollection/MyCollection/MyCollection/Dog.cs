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

    //Роблю перегрузку операторів == та != для класу Dog
    public static bool operator ==(Dog d1, Dog d2)
    {
        if (d1._name.Equals(d2._name) && d1._age == d2._age)
            return true;
        else
            return false;
    }

    public static bool operator !=(Dog d1, Dog d2)
    {
        return !(d1 == d2);
    }
}
