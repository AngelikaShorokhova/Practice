using System;
using System.Collections.Generic;


namespace pr_8
{
    class Program
    {
        static int[,] FormTest(int count)
        {
            int[,] mas = new int[count, count];
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if (i == j)
                        mas[i, j] = 0;
                    else
                        mas[i, j] = mas[j, i] = random.Next(0, 2);
                }
            }
            return mas;
        }
        static void InputNumberInt(string str, int n, out int k)
        {
            bool ok;
            bool ok1 = false;
            do
            {
                Console.WriteLine(str);
                string s = Console.ReadLine();
                ok = int.TryParse(s, out k);
                if (!ok)
                    Console.WriteLine("Введено не число");
                else
                {
                    if (k > n)
                    {
                        ok1 = false;
                        Console.WriteLine("Число К больше количества вершин");
                    }
                    else ok1 = true;
                }
            } while (!ok || !ok1);
        }
        static List<List<int>> FindCountOfColors(int[,] mas)
        {
            bool[] check = new bool[mas.GetLength(0)];
            List<List<int>> colors = new List<List<int>>();
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    List<int> NewColor = new List<int>();
                    if (i != j && mas[i, j] == 0 && !check[i] && !check[j])
                    {
                        NewColor.Add(i);
                        NewColor.Add(j);
                        check[i] = true; check[j] = true;
                        colors.Add(NewColor);
                    }
                    if (j == mas.GetLength(1) - 1 && !check[i] && !check[j])
                    {
                        NewColor.Add(i);
                        check[i] = true;
                        colors.Add(NewColor);
                    }
                }
            }
            return colors;
        }
        static List<List<int>> MakeMoreColors(List<List<int>> c, int k)
        {
            int count = c.Count;
            List<List<int>> c1 = new List<List<int>>();
            foreach (List<int> a in c)
            {
                if (a.Count == 2 && count != k)
                {
                    List<int> new1 = new List<int>();
                    new1.Add(a[0]);
                    c1.Add(new1);
                    List<int> new2 = new List<int>();
                    new2.Add(a[1]);
                    c1.Add(new2);
                    count++;
                }
                else c1.Add(a);
            }
            return c1;
        }
        static void ShowList(List<List<int>> c)
        {
            Console.WriteLine(Environment.NewLine + "Цвета   Вершины");
            int i = 1;
            foreach (List<int> a in c)
            {
                Console.Write($"Цвет {i}: ");
                foreach (int b in a)
                {
                    Console.Write(b + " ");
                }
                i++;
                Console.WriteLine();
            }
        }
        static void ShowMas(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                    Console.Write(string.Format("{0,3}", arr[i, j]));
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void Main()
        {
            Console.Clear();
            Console.WriteLine("Задание №8.");
            Console.WriteLine("Граф задан матрицей смежности. Найти в нем какую-либо правильную раскраску с помощью K красок.");
            Console.WriteLine();
            int[,] matrix = FormTest(10);
            ShowMas(matrix);
            Console.WriteLine(" ");
            int k;
            InputNumberInt("K:", matrix.GetLength(0), out k);
            List<List<int>> colors = FindCountOfColors(matrix);


            if (k < colors.Count)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Не достаточно цветов, чтобы программа могла правильно раскрасить граф");
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (k == colors.Count) ShowList(colors);
            if (k > colors.Count)
            {
                int vertex = matrix.GetLength(0);
                colors = MakeMoreColors(colors, k);
                ShowList(colors);
            }
            if (Console.ReadLine() != "0")
                Main();
        }
    }
}
