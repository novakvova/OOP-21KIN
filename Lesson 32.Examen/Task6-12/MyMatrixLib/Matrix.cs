using System.Text;

namespace MyMatrixLib;

/// <summary>
/// Матриця дійсних чисел розміром Rows x Columns.
/// Обчислення виконує клас <see cref="MatrixOperations"/>.
/// </summary>
public class Matrix
{
    private readonly double[,] _data;

    /// <summary>Кількість рядків.</summary>
    public int Rows { get; }

    /// <summary>Кількість стовпців.</summary>
    public int Columns { get; }

    /// <summary>Створює нульову матрицю заданого розміру.</summary>
    public Matrix(int rows, int columns)
    {
        if (rows <= 0 || columns <= 0)
            throw new ArgumentException("Розмір матриці має бути більшим за 0");

        Rows = rows;
        Columns = columns;
        _data = new double[rows, columns];
    }

    /// <summary>Створює матрицю з двовимірного масиву.</summary>
    public Matrix(double[,] data)
        : this(data.GetLength(0), data.GetLength(1))
    {
        Array.Copy(data, _data, data.Length);
    }

    /// <summary>Доступ до елемента матриці: m[рядок, стовпець].</summary>
    public double this[int row, int column]
    {
        get { return _data[row, column]; }
        set { _data[row, column] = value; }
    }

    // Оператори викликають методи MatrixOperations
    public static Matrix operator +(Matrix a, Matrix b) => MatrixOperations.Add(a, b);
    public static Matrix operator -(Matrix a, Matrix b) => MatrixOperations.Subtract(a, b);
    public static Matrix operator *(Matrix a, Matrix b) => MatrixOperations.Multiply(a, b);
    public static Matrix operator *(Matrix a, double k) => MatrixOperations.Multiply(a, k);
    public static Matrix operator *(double k, Matrix a) => MatrixOperations.Multiply(a, k);

    /// <summary>Виводить матрицю у вигляді таблиці.</summary>
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
                sb.Append($"{_data[i, j],6}");
            sb.AppendLine();
        }
        return sb.ToString();
    }
}
