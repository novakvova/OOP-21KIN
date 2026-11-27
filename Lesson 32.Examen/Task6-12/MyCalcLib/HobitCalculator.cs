namespace MyCalcLib;

/// <summary>
/// Калькулятор - бібліотека основних математичних операцій.
/// </summary>
public static class HobitCalculator
{
    /// <summary>
    /// Додає два числа.
    /// </summary>
    /// <param name="a">Перший доданок.</param>
    /// <param name="b">Другий доданок.</param>
    /// <returns>Сума <paramref name="a"/> і <paramref name="b"/>.</returns>
    public static double Add(double a, double b)
    {
        return a + b;
    }

    /// <summary>
    /// Віднімає від першого числа друге.
    /// </summary>
    /// <param name="a">Зменшуване.</param>
    /// <param name="b">Від'ємник.</param>
    /// <returns>Різниця <paramref name="a"/> і <paramref name="b"/>.</returns>
    public static double Subtract(double a, double b)
    {
        return a - b;
    }

    /// <summary>
    /// Множить два числа.
    /// </summary>
    /// <param name="a">Перший множник.</param>
    /// <param name="b">Другий множник.</param>
    /// <returns>Добуток <paramref name="a"/> і <paramref name="b"/>.</returns>
    public static double Multiply(double a, double b)
    {
        return a * b;
    }

    /// <summary>
    /// Ділить перше число на друге.
    /// </summary>
    /// <param name="a">Ділене.</param>
    /// <param name="b">Дільник.</param>
    /// <returns>Частка від ділення <paramref name="a"/> на <paramref name="b"/>.</returns>
    /// <exception cref="DivideByZeroException">Якщо <paramref name="b"/> дорівнює нулю.</exception>
    public static double Divide(double a, double b)
    {
        if (b == 0)
            throw new DivideByZeroException("Ділення на нуль неможливе");
        return a / b;
    }

    /// <summary>
    /// Обчислює остачу від ділення першого числа на друге.
    /// </summary>
    /// <param name="a">Ділене.</param>
    /// <param name="b">Дільник.</param>
    /// <returns>Остача від ділення <paramref name="a"/> на <paramref name="b"/>.</returns>
    /// <exception cref="DivideByZeroException">Якщо <paramref name="b"/> дорівнює нулю.</exception>
    public static double Mod(double a, double b)
    {
        if (b == 0)
            throw new DivideByZeroException("Ділення на нуль неможливе");
        return a % b;
    }

    /// <summary>
    /// Підносить число до степеня.
    /// </summary>
    /// <param name="value">Основа степеня.</param>
    /// <param name="exponent">Показник степеня.</param>
    /// <returns><paramref name="value"/> у степені <paramref name="exponent"/>.</returns>
    public static double Power(double value, double exponent)
    {
        return Math.Pow(value, exponent);
    }

    /// <summary>
    /// Обчислює квадратний корінь числа.
    /// </summary>
    /// <param name="value">Невід'ємне число.</param>
    /// <returns>Квадратний корінь з <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentException">Якщо <paramref name="value"/> від'ємне.</exception>
    public static double Sqrt(double value)
    {
        if (value < 0)
            throw new ArgumentException("Не можна добути корінь з від'ємного числа");
        return Math.Sqrt(value);
    }

    /// <summary>
    /// Обчислює, скільки становить вказаний відсоток від числа.
    /// </summary>
    /// <param name="value">Число, від якого береться відсоток.</param>
    /// <param name="percent">Кількість відсотків.</param>
    /// <returns><paramref name="percent"/>% від <paramref name="value"/>.</returns>
    public static double Percent(double value, double percent)
    {
        return value * percent / 100;
    }

    /// <summary>
    /// Обчислює обернене число (1/x).
    /// </summary>
    /// <param name="value">Число, відмінне від нуля.</param>
    /// <returns>Значення 1 / <paramref name="value"/>.</returns>
    /// <exception cref="DivideByZeroException">Якщо <paramref name="value"/> дорівнює нулю.</exception>
    public static double Reciprocal(double value)
    {
        if (value == 0)
            throw new DivideByZeroException("Ділення на нуль неможливе");
        return 1 / value;
    }

    /// <summary>
    /// Змінює знак числа на протилежний.
    /// </summary>
    /// <param name="value">Вхідне число.</param>
    /// <returns>Число з протилежним знаком.</returns>
    public static double Negate(double value)
    {
        return -value;
    }
}
