namespace MyStaticClass;

class Avatar
{
	//private string _name; //Назва
	//private string _age; //Вік
	//private string _height; //Зріс аватара
	//Падразувати кількість створених об'єктів даного класу
	private static int _countItems = 0; //Дана змінна глобальна для усіх об'єктів
	private static int _maxHeight = 0; //Максимальний зріст Avatar - 4 метри
	//Роблю статичний метод, щоб отримати інфомрацію про кількість об'єктів
	public static int GetCountItems() { return _countItems; }

	//propfull
	private string _name;

	public string Name
	{
		get { return _name; }
		set { _name = value; }
	}
	private int _age;

	public int Age
	{
		get { return _age; }
		set { _age = value; }
	}

	private int _height;

	public int Height
	{
		get { return _height; }
		set 
		{
			if(value > _maxHeight)
			{
                Console.WriteLine("Даний зріст не допустий для Avatar");
				return;
			}
			_height = value; 
		}
	}

    public Avatar()
    {
		this.Age = 2;
		this.Height = 3;
		this.Name = "Без імені";
		_countItems++;
    }

    public Avatar(string name, int age, int height)
    {
        this.Name = name;
		this.Age = age;
		this.Height = height;
		_countItems++;
    }

	static Avatar() //Статичний констуктор - Для ініціалазції глобальних даних
	{
        //Дайте десь на сервері встановлюєть зріст макисальний для Avatar
		//Значення береться із файлу або БД або із сервера
        _maxHeight = 4; //Максимальний зріст Avatar - 4 метри
    }

    public override string ToString()
    {
        return $"{Name}\tВік: {Age}\tЗріст: {Height}";
    }

}
