namespace MyProps;

class People
{
    //Кожна людина є унікальна
    //Для цього ми для людини зробимо унікальний ідентифікатор (ID)
    //У С# для цього є тип Guid (Globally Unique Identifier)
    private string _id;
    private string _lastName;
    private string _firstName;
    private string _middleName;
    private short _age; //вік людини
    private bool _gender; //стать людини (true - чоловік, false - жінка)
    public People()
    {
        //N - 32 цифри без дефісів
        //Даний ідентифікатор не може повторитися у жодної іншої людини
        _id = Guid.NewGuid().ToString("N"); 
    }
    //конструктор з параметрами
    public People(string lastName, 
        string firstName, 
        string middleName, 
        short age, bool gender) : this()
    //this() - викликає конструктор без параметрів, який
    //створює унікальний ідентифікатор
    {
        _lastName = lastName;
        _firstName = firstName;
        _middleName = middleName;
        _age = age;
        _gender = gender;
    }

    public override string ToString()
    {
        return $"ID: {_id}, " +
            $"Last Name: {_lastName}, " +
            $"First Name: {_firstName}, " +
            $"Middle Name: {_middleName}, " +
            $"Age: {_age}, " +
            $"Gender: {(_gender ? "Хлопець" : "Дівчина" )}";
    }
    //Хочу зробити метод для зміни _lastName та отримання _lastName
    public void SetLastName(string lastName) //Надає значення
    {
        _lastName = lastName;
    }
    public string GetLastName() //Отримує значення
    {
        return _lastName;
    }

    //Влативість - це метод, який немає дужок у кінці
    //Пишеться завжди із великої літери
    //Властивість може виконувати 2 дії - get та set
    //або лише одну із них
    public string Id // Властивість лише для отримання значення
    { 
        get { return _id; }
    }

    public string FirstName
    {
        get { return _firstName; }
        set { _firstName = value; } //У людини може змінити ім'я
    }
    public short Age 
    { 
        get 
        { 
            return _age; 
        } 
        set
        { 
            if (value >= 0)
            {
                _age = value;
            }
            else
            {
                Console.WriteLine("Вік не може бути від'ємним числом");
            }
        } 
    }
}
