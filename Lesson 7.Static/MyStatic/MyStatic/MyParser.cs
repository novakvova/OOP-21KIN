using System.Reflection.Metadata.Ecma335;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyStatic;

/// <summary>
/// Клас, який уміє парсити дані
/// </summary>
class MyParser
{
    /// <summary>
    /// Цей метод буде вміти парсити рядок до int
    /// </summary>
    /// <param name="str">рядок, який ми парсимо</param>
    /// <returns>Повертаємо результат</returns>
    public static int ParseToInt(string str)
    {
        int result = -1;
        int len = str.Length; //Отримав довжину рядка
                              //s18 - 18
        for (int i = 0; i < len; i++)
        {
            char c = str[i]; // це є символ
                             //перевіряємо чи це є цифра
            if (c >= '0' && c <= '9') // перевіряємо, чи символ знаходиться в діапазоні 0–9
            {
                int digit = c - '0'; //це буде цифра
                if (result == -1)
                    result = digit;
                else
                {
                    result *= 10;
                    result += digit;
                }
            }
        }
        return result;
    }
}
