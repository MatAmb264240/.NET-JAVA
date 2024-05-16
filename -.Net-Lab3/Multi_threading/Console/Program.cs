using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using Matrix_namespace;

class Program
{
    static void Main(string[] args)
    {
        int[] matrixSizes = { 50, 100, 150, 200, 250 };
        int[] threadCounts = { 1, 2, 3, 4, 5 };
        int iterations = 10;

        CultureInfo culture = CultureInfo.InvariantCulture; // Ustawienie kultury dla zapisu pliku CSV

        using (StreamWriter writer = new StreamWriter("Results.csv"))
        {
            // Nagłówki kolumn
            writer.WriteLine("Matrix Size,Thread Count,Average Time (Multiplication),Average Time (Parallel Multiplication)");

            foreach (int size in matrixSizes)
            {
                foreach (int threads in threadCounts)
                {
                    long multiplicationTotalTime = 0;
                    long parallelMultiplicationTotalTime = 0;

                    for (int i = 0; i < iterations; i++)
                    {
                        Matrix matrix1 = new Matrix(size, size);
                        Matrix matrix2 = new Matrix(size, size);

                        matrix1.FillMatrix();
                        matrix2.FillMatrix();

                        Stopwatch stopwatch = Stopwatch.StartNew();
                        Matrix result = Matrix.multiplication(matrix1, matrix2, threads);
                        stopwatch.Stop();
                        multiplicationTotalTime += stopwatch.ElapsedMilliseconds;

                        stopwatch.Restart();
                        Matrix result2 = Matrix.paralell_multiplication(matrix1, matrix2, threads);
                        stopwatch.Stop();
                        parallelMultiplicationTotalTime += stopwatch.ElapsedMilliseconds;
                    }

                    double avgMultiplicationTime = multiplicationTotalTime / (double)iterations;
                    double avgParallelMultiplicationTime = parallelMultiplicationTotalTime / (double)iterations;

                    // Zapisz wyniki do pliku CSV z użyciem kropki jako separatora dziesiętnego
                    writer.WriteLine($"{size},{threads},{avgMultiplicationTime.ToString(culture)},{avgParallelMultiplicationTime.ToString(culture)}");
                }
            }
        }

        Console.WriteLine("Results saved to Results.csv");
    }
}
