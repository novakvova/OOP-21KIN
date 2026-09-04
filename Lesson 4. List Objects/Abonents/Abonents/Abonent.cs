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




}
