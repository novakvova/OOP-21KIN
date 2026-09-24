// See https://aka.ms/new-console-template for more information
using ExampleProtected;
using System.Text;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("-- Працюємо із наслідуванням --");

Device iPhone18ProMax =
    new Smartphone(brand: "Apple", model: "18 Pro Max", price: 84999.50M,
    cpu: "A20 Pro", memory: "12Гб", storage: "256Гб", screenSize: 6.9F);

Console.WriteLine(iPhone18ProMax);

Device hp860g9 = new Laptop(brand: "HP", model: "EliteBook 860 g9", 
    price: 23400, cpu: "i5-1250P", memory: "16Гб", storage: "2 Тб.", display: "16\"");

Console.WriteLine(hp860g9);