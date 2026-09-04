namespace MyObject;

class Animal : System.Object
{
    private string _name; // Назва тварини
    private byte _age; // Вік тваринки
    private string _description; // Опис тварини
    //Зберігає дробові числа
    private float _weight; //вага

    //set - надає значення
    //get - повертає значення
    public void SetName(string name) => _name = name;
    public string GetName() => _name;

    public void SetAge(byte age)
    {
        if(age<0)
        {
            Console.WriteLine("----Дане значення не можливе---");
            return;
        }
        _age = age;
    }
    public byte GetAge() => _age;

    public void SetDescription(string description) => _description = description;
    public string GetDescription() => _description;

    public void SetWeight(float weight)
    {
        if(weight<0.15)
        {
            Console.WriteLine("Мінамальна Вага тварини 0.15");
            return;
        }
        _weight = weight; 
    }
    public float GetWeight() => _weight;
    //через метод ovveride - перевизначаємо
    //робимо, як ми хочемо він повертає рядок, який буде передаватися ToString()
    public override string ToString()
    {
        string strInfo = 
            $"Назва: {_name}\nВік: {_age}\nОпис: {_description}\nВага: {_weight}";
        return strInfo;
    }
    //Цей метод для порівняння двох об'єктів між собою
    public override bool Equals(object? obj) //у дужкає у нас передається object
    {
        Animal animal = obj as Animal; //Ми перетворюємо в об'єкти типу Animal
        if (animal == null)
            return false;
        return animal._weight == _weight;
    }
}
