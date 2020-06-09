using System;

namespace pr_12
{
    class Program
    {
        static int[] EasyInsert(int[] mas, out int countComp, out int countChang)
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
        static int[] EasyChoice(int[] mas, out int countComp, out int countChang)
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
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] mas = { 1, 2, 3, 4, 5 };
            //for (int i = 0; i < mas.Length; i++)
            //    mas[i] = random.Next(0, 10);
            int count1, count2;
            EasyChoice(mas, out count1, out count2);
            Console.WriteLine(count1); Console.WriteLine(count2);
            foreach (int i in mas)
                Console.Write(i + " ");
            Console.WriteLine();
            int[] mas1 = { 1, 2, 3, 4, 5 };
            //for (int i = 0; i < mas.Length; i++)
            //    mas1[i] = random.Next(0, 10);
            EasyInsert(mas1, out count1, out count2);
            Console.WriteLine(count1); Console.WriteLine(count2);
            foreach (int i in mas1)
                Console.Write(i + " ");
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
