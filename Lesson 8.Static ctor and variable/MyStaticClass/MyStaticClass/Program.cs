// See https://aka.ms/new-console-template for more information
using MyStaticClass;
using System.Text;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("-- Привіт командос --");

Avatar semen = new Avatar();
Console.WriteLine("Semen default: "+ semen.ToString());

Avatar slavik = new Avatar("Славік", 4, 4);
Console.WriteLine(slavik);

Avatar oleg = new Avatar();
oleg.Name = "Олег Васильович";
oleg.Age = 5;
oleg.Height = 5;

Console.WriteLine("Get Count Avatar = "+Avatar.GetCountItems());





