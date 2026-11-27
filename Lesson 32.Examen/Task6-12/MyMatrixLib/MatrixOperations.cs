namespace MyMatrixLib;

/// <summary>
/// Операції над матрицями: додавання, віднімання, множення, транспонування.
/// </summary>
public static class MatrixOperations
{
    /// <summary>Додавання матриць: C = A + B.</summary>
    /// <exception cref="ArgumentException">Якщо розміри матриць не збігаються.</exception>
    public static Matrix Add(Matrix a, Matrix b)
    {
        if (a.Rows != b.Rows || a.Columns != b.Columns)
            throw new ArgumentException("Розміри матриць не збігаються");

        Matrix c = new Matrix(a.Rows, a.Columns);
        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < a.Columns; j++)
                c[i, j] = a[i, j] + b[i, j];
        return c;
    }

    /// <summary>Віднімання матриць: C = A - B.</summary>
    /// <exception cref="ArgumentException">Якщо розміри матриць не збігаються.</exception>
    public static Matrix Subtract(Matrix a, Matrix b)
    {
        if (a.Rows != b.Rows || a.Columns != b.Columns)
            throw new ArgumentException("Розміри матриць не збігаються");

        Matrix c = new Matrix(a.Rows, a.Columns);
        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < a.Columns; j++)
                c[i, j] = a[i, j] - b[i, j];
        return c;
    }

    /// <summary>Множення матриці на число: C = A * k.</summary>
    public static Matrix Multiply(Matrix a, double k)
    {
        Matrix c = new Matrix(a.Rows, a.Columns);
        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < a.Columns; j++)
                c[i, j] = a[i, j] * k;
        return c;
    }

    /// <summary>
    /// Множення матриць: C = A * B.
    /// Кількість стовпців A має дорівнювати кількості рядків B.
    /// </summary>
    /// <exception cref="ArgumentException">Якщо розміри несумісні.</exception>
    public static Matrix Multiply(Matrix a, Matrix b)
    {
        if (a.Columns != b.Rows)
            throw new ArgumentException("Кількість стовпців A має дорівнювати кількості рядків B");

        Matrix c = new Matrix(a.Rows, b.Columns);
        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < b.Columns; j++)
            {
                double sum = 0;
                for (int k = 0; k < a.Columns; k++)
                    sum += a[i, k] * b[k, j];
                c[i, j] = sum;
            }
        return c;
    }

    /// <summary>Транспонування: рядки стають стовпцями.</summary>
    public static Matrix Transpose(Matrix a)
    {
        Matrix t = new Matrix(a.Columns, a.Rows);
        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < a.Columns; j++)
                t[j, i] = a[i, j];
        return t;
    }
}
