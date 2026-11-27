namespace Task1;

public class Cat
{
    private string _petName;
    private int _age;
    private bool _sex;

    public Cat(string petName, int age, bool sex)
    {
        _petName = petName;
        _age = age;
        _sex = sex;
    }
    //public override string ToString()
    //{
    //    string text = $"Кличка: {_petName}\n";
    //    text += $"Вік: {_age}\n";
    //    string sex = _sex ? "хлопчик" : "двічинка";
    //    text += $"Стать: { sex }\n";
    //    return text;
    //}

    public override string ToString() =>
        $"Кличка: {_petName}\nВік: {_age}\nСтать: {(_sex ? "хлопчик" : "двічинка")}\n";
    //Метод для порівнянн довох котів
    public override bool Equals(object? obj)
    {
        //для цього виконуємо unboxing
        if (obj is Cat)
        {
            var cat = (Cat)obj;
            if (cat._age == _age && cat._sex == _sex)
                return true;
        }
        return false;
    }
}
