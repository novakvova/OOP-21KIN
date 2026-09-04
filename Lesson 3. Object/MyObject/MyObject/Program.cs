// See https://aka.ms/new-console-template for more information
using MyObject;
using System.Text;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("Базовий клас Object");


Animal dog = new Animal();
dog.SetName("Барсік");
dog.SetAge(3);
dog.SetDescription("Може вкусити людину. Кусав сусіда. Може зїсти кота :)");
dog.SetWeight(32);

//Кожен клас наслідує Object 
//Це означає, що класа має певні вбодовані властивості
//Одна із таких властивостей - ToString() - може повернути інформацію про обєкт
Console.WriteLine(dog); //не явний виклик - воно його саме напише dog.ToString();
//Console.WriteLine(dog.ToString());

Animal myCat = new Animal();
myCat.SetName("Валера");
myCat.SetAge(2);
myCat.SetDescription("Хороший кіт. Досить швидкий. Усі доставати із супа костомаху :)");
myCat.SetWeight(32); //Вага кота
Console.WriteLine(myCat);
bool isEqual = myCat.Equals(dog); //Метод, який уміє порівнювати два об'єкти
Console.WriteLine("myCat.Equals(dog) = "+ isEqual);

Animal myMinPig = new Animal();
myMinPig.SetName("Міні піг");
myMinPig.SetAge(6);
myMinPig.SetDescription("Любить морозиво");
myMinPig.SetWeight(70);
Console.WriteLine(myMinPig);

Console.WriteLine("myMinPig.Equals(dog) = " + myMinPig.Equals(dog));
