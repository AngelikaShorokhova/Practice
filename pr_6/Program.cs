using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace pr_6
{
    public class Program
    {
        [ExcludeFromCodeCoverage]
        static void InputNumberDouble(out double n)
        {
            bool ok;
            do
            {
                Console.WriteLine("Введите L:");
                string stroka = Console.ReadLine();
                ok = double.TryParse(stroka, out n);
                if (!ok)
                    Console.WriteLine("Введено не число");
            } while (!ok);
        }
        [ExcludeFromCodeCoverage]
        static void InputNumberInt(string s, out int n)
        {
            bool ok, ok1 = true;
            do
            {
                Console.WriteLine(s);
                string stroka = Console.ReadLine();
                ok = int.TryParse(stroka, out n);
                if (!ok)
                    Console.WriteLine("Введено не число");
                else ok1 = n >= 0;
                if (!ok1)
                    Console.WriteLine("Введено не положительное число");
            } while (!ok || !ok1);
        }
        public static double[] ByCount(double a1, double a2, double a3, int N, out TimeSpan time)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            double[] mas = new double[N];
            for (int i = 0; i < N; i++)
            {
                mas[i] = Poslodovatelnost(a1, a2, a3, i + 1);
            }
            stopwatch.Stop();
            time = stopwatch.Elapsed;
            return mas;
        }
        public static double[] ByValue(double a1, double a2, double a3, int M, double L, out TimeSpan time)
        {
            Stopwatch stopwatch = new Stopwatch();
            double[] mas = new double[M];
            int j = 0;
            int k = 1;
            stopwatch.Start();
            mas = new double[M];
            do
            {
                double temp = Poslodovatelnost(a1, a2, a3, k);
                if (temp > L)
                {
                    mas[j] = temp; j++;
                }
                k++;
            } while (j < M);
            stopwatch.Stop();
            time = stopwatch.Elapsed;
            return mas;
        }

        public static bool Fastest(double a1, double a2, double a3, int N, int M, double L)
        {
            TimeSpan time1, time2;
            double[] mas1 = ByCount(1, 1, 1, N, out time1);
            double[] mas2 = ByValue(1, 1, 1, M, L, out time2);
            if (time1 < time2)
            {
                Console.WriteLine("Причина остановки: 1");
                ShowMas(mas1);
            }
            else
            {
                Console.WriteLine("Причина остановки: 2");
                ShowMas(mas2);
            }
            return time1 < time2;
        }
        [ExcludeFromCodeCoverage]
        static void ShowMas(double[] mas)
        {
            if (mas.Length == 0)
                Console.WriteLine("Массив пустой");
            else
            {
                for (int i = 0; i < mas.Length; i++)
                    Console.Write(Math.Round(mas[i], 3) + " ");
            }
        }
        public static double Poslodovatelnost(double a1, double a2, double a3, int n)
        {
            if (n == 1) return a1;
            else if (n == 2) return a2;
            else if (n == 3) return a3;
            else return (double)(((double)7 / 3) * Poslodovatelnost(a1, a2, a3, n - 1) + Poslodovatelnost(a1, a2, a3, n - 2)) / (2 * Poslodovatelnost(a1, a2, a3, n - 3));
        }
        [ExcludeFromCodeCoverage]
        static void Main(string[] args)
        {
            Console.WriteLine("Задание №6.");
            Console.WriteLine("Ввести а1, а2, а3, М, N, L. Построить последовательность чисел an = (7/3* an-1 + + an-2)/2аk-3. Построить N элементов последовательности, либо найти первые M ее элементов, большие числа L (в зависимости от того, что выполнится раньше). Напечатать последовательность и причину остановки.");
            int N;
            int M;
            InputNumberInt("N", out N);
            InputNumberInt("M", out M);
            InputNumberDouble(out double L);
            Fastest(1, 1, 1, N, M, L);
            Console.ReadLine();
        }
    }
}
