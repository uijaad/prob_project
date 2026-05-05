using System;
using System.Collections.Generic;
using System.Linq;

class Assignment1_Statistics
{
    static void Main(string[] args)
    {
        // Given data
        
        int[] data = { 115, 182, 191, 31, 196, 1099, 5, 172, 10, 179, 83, 21, 20, 21, 186, 177, 195, 193, 188, 199, 62, 109, 105, 183, 110 };
        int n = data.Length;

        Console.WriteLine("=== Probability and Statistical Distributions ===");
        Console.WriteLine("Faculty of Computers and Information - First Level");
        Console.WriteLine("Programming Assignment - Question 1");
        Console.WriteLine("=================================================\n");

        Console.Write("Data: ");
        Console.WriteLine(string.Join(", ", data));
        Console.WriteLine($"n = {n}\n");

        // Sort a copy for median/quartiles/percentiles
        int[] sorted = (int[])data.Clone();
        Array.Sort(sorted);

        // (i) Mean
        double mean = data.Average();
        Console.WriteLine($"(i)    Mean                  = {mean:F4}");

        // (ii) Mode
        int mode = GetMode(data);
        Console.WriteLine($"(ii)   Mode                  = {mode}");

        // (iii) Median
        double median = GetPercentile(sorted, 50);
        Console.WriteLine($"(iii)  Median                = {median:F4}");

        // (iv) Variance (population variance)
        double variance = data.Select(x => Math.Pow(x - mean, 2)).Sum() / n;
        Console.WriteLine($"(iv)   Variance              = {variance:F4}");

        // (v) P20
        double p20 = GetPercentile(sorted, 20);
        Console.WriteLine($"(v)    P20                   = {p20:F4}");

        // (vi) P50
        double p50 = GetPercentile(sorted, 50);
        Console.WriteLine($"(vi)   P50                   = {p50:F4}");

        // (vii) Third Quartile (Q3 = P75)
        double q3 = GetPercentile(sorted, 75);
        Console.WriteLine($"(vii)  Third Quartile (Q3)   = {q3:F4}");

        // (viii) Second Quartile (Q2 = P50 = Median)
        double q2 = GetPercentile(sorted, 50);
        Console.WriteLine($"(viii) Second Quartile (Q2)  = {q2:F4}");

        // (ix) Third Quartile again (as listed in assignment)
        Console.WriteLine($"(ix)   Third Quartile (Q3)   = {q3:F4}");

        // (x) Range
        double range = sorted[n - 1] - sorted[0];
        Console.WriteLine($"(x)    Range                 = {range:F4}");

        // (xi) Interquartile Range (IQR = Q3 - Q1)
        double q1 = GetPercentile(sorted, 25);
        double iqr = q3 - q1;
        Console.WriteLine($"(xi)   Interquartile Range   = {iqr:F4}");

        // (xii) Standard Deviation
        double stdDev = Math.Sqrt(variance);
        Console.WriteLine($"(xii)  Standard Deviation    = {stdDev:F4}");

        // (xiii) Summation of Deviations (sum of |xi - mean|)
        double sumDeviations = data.Select(x => Math.Abs(x - mean)).Sum();
        Console.WriteLine($"(xiii) Summation of Deviations = {sumDeviations:F4}");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    // Calculate percentile using the interpolation method
    static double GetPercentile(int[] sortedData, double percentile)
    {
        int n = sortedData.Length;
        double rank = (percentile / 100.0) * n;

        if (rank <= 0) return sortedData[0];
        if (rank >= n) return sortedData[n - 1];

        int lower = (int)Math.Floor(rank) - 1;
        int upper = lower + 1;

        if (lower < 0) return sortedData[0];
        if (upper >= n) return sortedData[n - 1];

        double fraction = rank - Math.Floor(rank);

        if (fraction == 0)
            return sortedData[lower];
        else
            return sortedData[lower] + fraction * (sortedData[upper] - sortedData[lower]);
    }

    // Calculate Mode 
    static int GetMode(int[] data)
    {
        Dictionary<int, int> freq = new Dictionary<int, int>();

        foreach (int x in data)
        {
            if (freq.ContainsKey(x))
                freq[x]++;
            else
                freq[x] = 1;
        }

        int maxFreq = freq.Values.Max();
        int mode = freq.First(kv => kv.Value == maxFreq).Key;

        return mode;
    }
}