using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace pr_7
{
    public class Program
    {
        public static int Functions(out ArrayList list)
        {
            list = new ArrayList();
            string bin; int count = 0;
            for (int i = 0; i < 256; i++)
            {
                bin = Convert.ToString(i, 2);
                if (bin.Length < 8)
                {
                    int length = bin.Length;
                    for (int j = 0; j < 8 - length; j++)
                        bin = bin.Insert(0, "0");
                }
                if (bin[0] == bin[7] || bin[1] == bin[6] || bin[2] == bin[5] || bin[3] == bin[4])
                {
                    list.Add(bin);
                    count++;
                }
            }
            return count;
        }
        [ExcludeFromCodeCoverage]
        static void Main(string[] args)
        {
            Console.WriteLine("Задание №7.");
            Console.WriteLine("Выписать все булевы функции от 3 аргументов, которые не самодвойственные.Выписать их вектора в лексикографическом порядке.");
            ArrayList list = new ArrayList();
            int count = Functions(out list);
            Console.Write("Всего не самодвойственных функций: " + count);
            Console.WriteLine();
            foreach (string s in list)
                Console.WriteLine(s);
            Console.ReadLine();
        }
    }
}
