using System;

namespace pr_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание №5.");
            int n = 3;
            Random random = new Random();
            double[,] mas = new double[n, n];
            double sum = 0;
            double[] max = new double[mas.GetLength(1)];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    mas[i, j] = random.Next(3);
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(mas[i, j] + " ");
                Console.WriteLine();
            }

            for (int i = 0; i < mas.GetLength(0); i++)
            {
                max[i] = mas[i, 0];
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    if (mas[i, j] > max[i])
                        max[i] = mas[i, j];
                }
            }
            Console.WriteLine();
            for (int i = 0; i < max.Length; i++)
                sum += max[i] * max[max.Length - 1 - i];
            Console.WriteLine(sum);
            Console.ReadLine();
        }
    }
}
