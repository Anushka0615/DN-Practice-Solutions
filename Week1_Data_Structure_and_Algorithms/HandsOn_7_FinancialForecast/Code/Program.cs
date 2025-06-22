using System;

class Program
{
    // Recursive Method
    static double PredictFutureValueRecursive(double presentValue, double growthRate, int years)
    {
        if (years == 0)
            return presentValue;
        return PredictFutureValueRecursive(presentValue, growthRate, years - 1) * (1 + growthRate);
    }

    // Iterative Method (Optimized)
    static double PredictFutureValueIterative(double presentValue, double growthRate, int years)
    {
        double result = presentValue;
        for (int i = 0; i < years; i++)
        {
            result *= (1 + growthRate);
        }
        return result;
    }

    static void Main()
    {
        double presentValue = 1000.0;
        double growthRate = 0.05; // 5%
        int years = 10;

        Console.WriteLine("Recursive Forecast: Rs " +
            PredictFutureValueRecursive(presentValue, growthRate, years).ToString("F2"));

        Console.WriteLine("Iterative Forecast (Optimized): Rs " +
            PredictFutureValueIterative(presentValue, growthRate, years).ToString("F2"));
    }
}
