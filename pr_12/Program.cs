using System;
using System.Diagnostics.CodeAnalysis;

namespace pr_12
{
    public class Program
    {
        public static int[] EasyInsert(int[] mas, out int countComp, out int countChang)
        {
            countComp = 0; countChang = 0;
            for (int i = 1; i < mas.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    countComp++;
                    if (mas[j - 1] > mas[j])
                    {
                        int temp = mas[j];
                        mas[j] = mas[j - 1];
                        mas[j - 1] = temp;
                        countChang++;
                    }
                }
            }
            return mas;
        }
        public static int[] EasyChoice(int[] mas, out int countComp, out int countChang)
        {
            countComp = 0; countChang = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < mas.Length; j++)
                {
                    countComp++;
                    if (mas[j] < mas[min])
                    {
                        min = j;
                    }
                }
                int temp = mas[i];
                mas[i] = mas[min];
                mas[min] = temp;
                countChang++;
            }
            return mas;
        }
        [ExcludeFromCodeCoverage]
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] mas = new int[100];
            for (int i = 0; i < mas.Length; i++)
                mas[i] = random.Next(0, 10);
            int[] mas2 = mas;
            int count1 = 0, count2 = 0;
            Console.WriteLine("Неупорядоченный массив: сортировка вставками.");
            EasyInsert(mas, out count1, out count2);
            Console.WriteLine(count1); Console.WriteLine(count2);

            Console.WriteLine("Неупорядоченный массив: сортировка выбором.");
            count1 = 0; count2 = 0;
            EasyChoice(mas2, out count1, out count2);
            Console.WriteLine(count1); Console.WriteLine(count2);

            Console.WriteLine("Возрастающий массив: сортировка вставками.");
            for (int i = 0; i < mas.Length; i++)
                mas[i] = i + 1;
            mas2 = mas;
            count1 = 0; count2 = 0;
            EasyInsert(mas, out count1, out count2);
            Console.WriteLine(count1); Console.WriteLine(count2);

            Console.WriteLine("Возрастающий массив: сортировка выбором.");
            count1 = 0; count2 = 0;
            EasyChoice(mas2, out count1, out count2);
            Console.WriteLine(count1); Console.WriteLine(count2);

            Console.WriteLine("Убывающий массив: сортировка вставками.");
            for (int i = 0; i < mas.Length; i++)
                mas[i] = mas.Length-i;
            mas2 = mas;
            count1 = 0; count2 = 0;
            EasyInsert(mas, out count1, out count2);
            Console.WriteLine(count1); Console.WriteLine(count2);

            Console.WriteLine("Убывающий массив: сортировка выбором.");
            count1 = 0; count2 = 0;
            EasyChoice(mas2, out count1, out count2);
            Console.WriteLine(count1); Console.WriteLine(count2);
            Console.ReadLine();
        }
    }
}
