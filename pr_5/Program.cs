using System;
using System.Diagnostics.CodeAnalysis;

namespace pr_5
{
    public class Program
    {
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
                else ok1 = n >= 1;
                if (!ok1)
                    Console.WriteLine("Введено не положительное число");
            } while (!ok || !ok1);
        }
        public static double[] Max(double[,] mas)
        {
            double[] max = new double[mas.GetLength(1)];
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                max[i] = mas[i, 0];
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    if (mas[i, j] > max[i])
                        max[i] = mas[i, j];
                }
            }
            return max;
        }
        public static double Sum(double[] max)
        {
            double sum = 0;
            for (int i = 0; i < max.Length; i++)
                sum += max[i] * max[max.Length - 1 - i];
            return sum;
        }
        [ExcludeFromCodeCoverage]
        static void Main(string[] args)
        {
            Console.WriteLine("Задание №5.");
            Console.WriteLine("Дана действительная квадратная матрица порядка m. Получить x1xn + x2xn-1 + … + xnx1, где xn наибольшее значение элементов k-й строки данной матрицы.");
            InputNumberInt("Введите размерность массива:", out int n);
            Random random = new Random();
            double[,] mas = new double[n, n];
            double sum = 0;
            double[] max = new double[mas.GetLength(1)];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    mas[i, j] = random.Next(10);
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(mas[i, j] + " ");
                Console.WriteLine();
            }
            max = Max(mas);
            Console.WriteLine();
            sum = Sum(max);
            Console.WriteLine(sum);
            Console.ReadLine();
        }
    }
}
