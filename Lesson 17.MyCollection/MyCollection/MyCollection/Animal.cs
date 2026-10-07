namespace MyCollection;

//Не можна роботи об'єкти абстрактного класу,
//але можна створювати об'єкти похідних класів
public abstract class Animal
{
    protected string _name;
    protected int _age;

    public Animal()
    {
        _name = "No Name";
        _age = 0;
    }
    //ctor
    public Animal(string name, int age)
    {
        _name = name;
        _age = age;
    }
    public override string ToString()
    {
        string str = "Name: " + _name + "\n";
        str += $"Age: {_age}";
        return str;
    }
}
