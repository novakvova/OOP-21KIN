// See https://aka.ms/new-console-template for more information

using MyCalcLib;
using MyMatrixLib;
using System.Text;
using Task6_12;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

/*

Console.WriteLine("-- Привіт! Питання 7-12 --");

MiniPig sasha = new MiniPig(name: "Саша", age: 2, 
    color: "Білий", breed: "М'ясний");

MiniPig nura = new MiniPig(name: "Вдала", age: 2,
    color: "Чорна", breed: "Сальна");

//конструктор копіювання
MiniPig onuk = new MiniPig(sasha);

Console.WriteLine(onuk);

Console.WriteLine("Кількість створених об'єктів: " + MiniPig.Counter);
*/

double c = HobitCalculator.Add(23.6,67.9);

Console.WriteLine("С = " + c.ToString());

//Зробити окрему бібілотеку для роботи з матрицями
//+, -, *

Console.WriteLine("\n-- Матриці --");

Matrix a = new Matrix(new double[,]
{
    { 2, 1, 3 },
    { 0, 4, 1 },
    { 5, 2, 0 }
});
Matrix b = new Matrix(new double[,]
{
    { 1, 0, 2 },
    { 3, 1, 0 },
    { 0, 2, 1 }
});

Console.WriteLine("A =\n" + a);
Console.WriteLine("B =\n" + b);
Console.WriteLine("A + B =\n" + (a + b));
Console.WriteLine("A - B =\n" + (a - b));
Console.WriteLine("A * B =\n" + (a * b));
Console.WriteLine("A * 3 =\n" + (a * 3));
Console.WriteLine("Aᵀ =\n" + MatrixOperations.Transpose(a));