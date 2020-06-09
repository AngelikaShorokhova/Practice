using System;
using System.Collections.Generic;

namespace pr_10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание №10.");
            Graph graph = new Graph(10);
            graph.ShowGraph();
            Console.WriteLine();
            graph.Delete(2);
            graph.ShowGraph();
            if (Console.ReadLine() != "0")
                Main(args);
        }
    }
}
