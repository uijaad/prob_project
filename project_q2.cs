using System;
using System.Linq;
 
class Assignment2_OutlierDetection
{
    static void Main(string[] args)
    {
        // Given data
        int[] data = { 115, 182, 191, 31, 196, 1099, 5, 172, 10, 179, 83, 21, 20, 21, 186, 177, 195, 193, 188, 199, 62, 109, 105, 183, 110 };
        int n = data.Length;
 
        Console.WriteLine("=== Probability and Statistical Distributions ===");
        Console.WriteLine("Faculty of Computers and Information - First Level");
        Console.WriteLine("Programming Assignment - Question 2: Outlier Detection");
        Console.WriteLine("=======================================================\n");
 
        // Sort a copy for quartile calculations
        int[] sorted = (int[])data.Clone();
        Array.Sort(sorted);
 
        // Calculate Q1 and Q3 using percentile method
        double q1 = GetPercentile(sorted, 25);
        double q3 = GetPercentile(sorted, 75);
        double iqr = q3 - q1;
 
        // IQR method: outlier if below (Q1 - 1.5 * IQR) or above (Q3 + 1.5 * IQR)
        double lowerFence = q1 - 1.5 * iqr;
        double upperFence = q3 + 1.5 * iqr;
 
        Console.WriteLine($"Q1 (First Quartile)  = {q1:F4}");
        Console.WriteLine($"Q3 (Third Quartile)  = {q3:F4}");
        Console.WriteLine($"IQR                  = {iqr:F4}");
        Console.WriteLine($"Lower Fence (Q1 - 1.5 * IQR) = {lowerFence:F4}");
        Console.WriteLine($"Upper Fence (Q3 + 1.5 * IQR) = {upperFence:F4}");
        Console.WriteLine("\n--- Outlier Check for Each Value ---\n");
 
        int outlierCount = 0;
 
        for (int i = 0; i < n; i++)
        {
            bool isOutlier = data[i] < lowerFence || data[i] > upperFence;
 
            if (isOutlier)
            {
                Console.WriteLine($"data[{i,2}] = {data[i],5}  -->  OUTLIER");
                outlierCount++;
            }
            else
            {
                Console.WriteLine($"data[{i,2}] = {data[i],5}  -->  Not an outlier");
            }
        }
 
        Console.WriteLine($"\nTotal Outliers Found: {outlierCount}");
 
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
 
    // Calculate percentile using interpolation method
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
}