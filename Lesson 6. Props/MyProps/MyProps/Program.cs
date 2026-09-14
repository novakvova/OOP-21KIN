using MyProps;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

Console.WriteLine("----Робота із властивостями-----");

People tolik = new People("Шмондер", "Анатолій", 
    "Володимирович", 20, true);
People oleg = new People(lastName: "Ковальчук", firstName: "Олег",
    middleName: "Михайлович", age: 15, gender: true);

Console.WriteLine(tolik);
tolik.SetLastName("Шкарпетка");
Console.WriteLine(tolik);
Console.WriteLine("Толік id = " + tolik.Id);
tolik.FirstName = "Ельцин"; //тут буде set
Console.WriteLine(tolik);
tolik.Age = -5; //тут буде set
Console.WriteLine(tolik);
Console.WriteLine(oleg);


