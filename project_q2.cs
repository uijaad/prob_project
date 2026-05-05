using System;

class SimpleOutlier
{
    static void Main()
    {
        int[] data = { 115, 182, 191, 31, 196, 1099, 5, 172, 10 };

        Array.Sort(data);

        int n = data.Length;

        double q1 = data[n / 4];
        double q3 = data[(3 * n) / 4];

        double iqr = q3 - q1;

        double lower = q1 - 1.5 * iqr;
        double upper = q3 + 1.5 * iqr;

        Console.WriteLine($"Q1 = {q1}");
        Console.WriteLine($"Q3 = {q3}");
        Console.WriteLine($"IQR = {iqr}\n");

        Console.WriteLine("Outliers:");

        foreach (int x in data)
        {
            if (x < lower || x > upper)
                Console.WriteLine(x);
        }
    }
}