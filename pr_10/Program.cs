using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace pr_10
{

    [ExcludeFromCodeCoverage]
    class Program
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
        static void Main(string[] args)
        {
            Console.WriteLine("Задание №10.");
            Console.WriteLine("Написать метод удаления из графа всех вершин с заданным значением информационного поля.");
            InputNumberInt("Введите количество вершин графа:", out int n);
            Graph graph = new Graph(n);
            graph.ShowGraph();
            Console.WriteLine();
            InputNumberInt("Введите значение вершины для удаления:", out int k);
            graph.Delete(k);
            graph.ShowGraph(); 
            Console.WriteLine("Для продолжения нажмите любую клавишу, для выхода нажмите 0...");
            if (Console.ReadLine() != "0")
                Main(args);
        }
    }
}
