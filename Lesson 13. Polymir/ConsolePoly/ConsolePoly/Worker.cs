namespace ConsolePoly;

public class Worker
{
    private string _id;
    private string _name;
    private string _description;
    private ushort _age; //ціле додатнє число 2 байти

    public Worker() //Конструктор по замовчуванню
    {
        _id = Guid.NewGuid().ToString();
        _name = "No name";
        _description = "No description";
        _age = 0;
    }
    //Це означає, що метод можна перевантажити
    //Реалізувати по іншом у дочірньому клас
    public virtual void ViewInfo() //Показати інформацію
    {
        Console.WriteLine($"Id: {_id}");
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine($"Description: {_description}");
        Console.WriteLine($"Age: {_age}");
    }
}
