using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTemplates;

// <summary>
/// Represents an animal with a generic type.
/// </summary>
/// <typeparam name="T">The type of the animal.</typeparam>
public class MyAnimal<T>
{
    private T _data;

    public MyAnimal(T data)
    {
        _data = data;
    }

    public void ViewData()
    {
        Console.WriteLine($"Animal Data: {_data}");
    }
}
