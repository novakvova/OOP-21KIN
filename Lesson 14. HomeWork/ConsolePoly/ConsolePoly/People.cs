namespace ConsolePoly;
public class People
    {
        public string Name { get; set; } = "No name";
        public ushort Age { get; set; }

    // По замовчуванню конструктор
    public People() { }
    // Конструктор з параметрами
    public People(string name, ushort age) => (Name, Age) = (name, age);

    // Віртуальний метод для виведення інформації про людину
    //Поліморфізм - це можливість об'єкта приймати різні форми.
    //У контексті об'єктно-орієнтованого програмування,
    //поліморфізм дозволяє методам з однаковим ім'ям виконувати різні дії залежно від типу об'єкта, який їх викликає. Це досягається через перевизначення методів у похідних класах.
    public virtual void ViewInfo() => Console.WriteLine($"[Людина] Ім'я: {Name}, Вік: {Age}");

        public virtual void Save(StreamWriter w)
        {
        // Тут буде об'єкт його назва
        // Student або Teacher, які ми зберігаємо у файл
        w.WriteLine(GetType().Name);
            w.WriteLine(Name);
            w.WriteLine(Age);
        }

        public virtual void Load(StreamReader r)
        {
            Name = r.ReadLine()!;
            Age = ushort.Parse(r.ReadLine()!);
        }
    }