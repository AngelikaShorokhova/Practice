using System;
using System.Diagnostics.CodeAnalysis;

namespace pr_9
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
            Console.WriteLine("Задание №9.");
            Console.WriteLine("Напишите рекурсивный метод создания двунаправленного списка, в информационные поля элементов которого последовательно заносятся номера с 1 до N (N водится с клавиатуры). Первый включенный в список элемент, имеющий номер 1, оказывается в хвосте списка (последним). Разработайте рекурсивные методы поиска и удаления элементов списка.");
            InputNumberInt("Введите размер списка:", out int n);
            LinkedList list = new LinkedList(n);
            list.PrintList();
            list.Swap();
            list.PrintList();
            InputNumberInt("Введите номер элемента для поиска:", out int k);
            list.Search(list.Beg, 0, k);
            Console.ReadLine();
        }
    }
}
