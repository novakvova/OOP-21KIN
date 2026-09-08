namespace Abonents;

class Abonent
{
    private string _pib;
    private string _phone;
    private string _address;

    //Конструктор - ініціалізація об'єкта при створенні
    //Конструктор по замовчуванню
    public Abonent() //якщо конструкто буде private, то не можна створити
    {
        //Console.WriteLine("-----Конструктор по замовчуванню------");
        _pib = "Немає ПІБ";
        _address = "Відсутня";
        _phone = "----";
    }
    //Конструкто з параметорами
    //Він перевантажує звичайно конструктор
    public Abonent(string pib, string phone, string address)
    {
        _pib = pib;
        _phone = phone;
        _address = address;
    }

    public override string ToString()
    {
        string info = $"ПІБ: {_pib}\tТелефон: {_phone}\tАдреса: {_address}";
        return info;
    }

    //Метод для запису даних у файл. Формат даних ;
    public string GetFileString()
    {
        return $"{_pib};{_address};{_phone}";
    }
    //Метод для перетворення рядка у Abonent
    //static - це метод, який можна викликати без протреба
    //створення об'єкта (тобто змінної даного класу)
    public static Abonent FromFileString(string line)
    {
        //Split - ділить рядок на підрядки робить масив string []
        var items = line.Split(';'); //'' - це 1 символ
        if (items.Length == 3)
        {
            return new Abonent(items[0], items[2], items[1]);
        }
        return new Abonent();
    }
}
