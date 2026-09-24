using Bogus;

namespace LibAbonent;

/// <summary>
/// Клас, що представляє абонента мобільного оператора Київстар.
/// </summary>
public class Kyivstar : BaseAbonent
{
    private string _tariffPlan = null!;

    public Kyivstar()
    {
        Faker faker = new Faker("uk");
        this.Name = faker.Name.FullName();
        this.Phone = faker.Phone.PhoneNumber("+380 67 ### ## ##");
        this.Longitude = faker.Address.Longitude();
        this.Latitude = faker.Address.Latitude();
        this.TariffPlan = faker.PickRandom(new[] { "Smart", "Smart Top", "Smart 3G", "Smart 4G", "Smart 5G" });
    }

    public string TariffPlan 
    { 
        get {  return _tariffPlan; }
        set { _tariffPlan = value; }
    }

    public override string ToString()
    {
        
        return $"Name: {Name}\t Phone: {Phone} \t {Latitude};{Longitude};" +
            $"\nKyivstar - Tariff Plan: {_tariffPlan}";
    }
}
