using Bogus;

namespace MyAbstract;
//Абстрактний клас - це клас, якого не можна створити
//екземпляр - об'єкт даного класу.
//Даний клас потрібен для наслідування
public abstract class People
{
    private string _id = null!;
    private string _name = null!;
    private string _phone = null!;
    //Конструктора робимо, щоб можна було використати
    //у дочірньому класі
    protected People()
    {
        _id = Guid.NewGuid().ToString();
        _name = "No name";
        _phone = "+38(000) 00 00 000";
    }

    protected People(bool isRandom = false)
    {
        Faker faker = new Faker("uk"); 
        if(isRandom)
        {
            _id = Guid.NewGuid().ToString();
            _name = faker.Person.FullName;
            _phone = faker.Person.Phone;
        }
    }
    //Абстрактний метод
    //Це метод, який має бути описаний у дочірньому
    //класі
    public abstract void Hello();
    public virtual void ViewInfo()
    {
        Console.WriteLine("Id: " + _id);
        Console.WriteLine("Name: " + _name);
        Console.WriteLine("Phone: " + _phone);
    }
}
