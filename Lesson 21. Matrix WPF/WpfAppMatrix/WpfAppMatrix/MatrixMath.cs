namespace WpfAppMatrix;

//Статичний клас - Це клас, методи якого можна викликати
//без потреби створення екземпляра класу
public static class MatrixMath
{
    public static double[,] Add(double[,]a, double[,]b)
    {
        //Для додавання двох матриць ми маємо знати, що вони
        //Щоб додати 2 матриці мають бути 2 однакові виміри
        int r = a.GetLength(0); //кількість рядків
        int c = a.GetLength(1); //кількість стоспчиків
        if (r != b.GetLength(0) || c != b.GetLength(1))
            throw new InvalidOperationException("Не спіпадають матриці по виміру");
        var res = new double[r, c];
        for(int i = 0; i < r; i++)
            for(int j = 0; j < c; j++)
                res[i,j] = a[i,j] + b[i,j];
        return res; //Вертаємо матрицю, яка додає 2 матриці
    }
}
