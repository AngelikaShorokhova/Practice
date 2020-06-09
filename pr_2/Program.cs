using System;
using System.IO;

namespace pr_2
{
    class Program
    {
        static int[] BubbleSort(int[] mas)
        {
            int temp;
            for (int i = 0; i < mas.Length - 1; i++)
            {
                for (int j = 0; j < mas.Length - i - 1; j++)
                {
                    if (mas[j + 1] > mas[j])
                    {
                        temp = mas[j + 1];
                        mas[j + 1] = mas[j];
                        mas[j] = temp;
                    }
                }
            }
            return mas;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Задание №2. Имеется 5 целых чисел. Среди них:" +
            "\n-если одинаковы 5, то вывести Impossible, иначе" +
            "\n-если одинаковы 4, то вывести Four of a Kind, иначе" +
            "\n-если одинаковы 3 и 2, то вывести Full House, иначе" +
            "\n-если есть 5 последовательных, то вывести Straight, иначе" +
            "\n-если одинаковы 3, то вывести Three of a Kind, иначе" +
            "\n-если одинаковы 2 и 2, то вывести Two Pairs, иначе" +
            "\n-если одинаковы 2, то вывести One Pair, иначе вывести Nothing");
            string file = @"C:\Users\qwlik\Desktop\практика\practice\pr_2\bin\Debug\INPUT.TXT";
            string s;
            using (StreamReader sr = new StreamReader(file))
            {
                s = sr.ReadToEnd();
            }
            string[] str = s.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            int[] mas = new int[str.Length];
            for (int i = 0; i < mas.Length; i++)
                mas[i] = Convert.ToInt32(str[i]);
            mas = BubbleSort(mas);
            int k = 0;
            string result = default;

            if (mas[0] == mas[4]) k = 7;
            if ((mas[0] == mas[3] || mas[1] == mas[4]) && k == 0) k = 6;
            if ((mas[0] == mas[1] && mas[2] == mas[4] && k == 0) || (mas[0] == mas[2] && mas[3] == mas[4] && k == 0)) k = 5;
            if (((mas[4] - mas[3] == mas[3] - mas[2]) && (mas[3] - mas[2] == mas[2] - mas[1]) && (mas[2] - mas[1] == mas[1] - mas[0])) && k == 0) k = 4;
            if ((mas[0] == mas[2] || mas[1] == mas[3] || mas[2] == mas[4]) && k == 0) k = 3;
            if (mas[0] == mas[1] && (mas[2] == mas[3] || mas[3] == mas[4]) && k == 0) k = 2;
            if ((mas[0] == mas[1] || mas[1] == mas[2] || mas[2] == mas[3] || mas[3] == mas[4]) && k == 0) k = 1;
            switch (k)
            {
                case 0:
                    result = "Nothing";
                    break;
                case 1:
                    result = "One Pair";
                    break;
                case 2:
                    result = "Two Pairs";
                    break;
                case 3:
                    result = "Three of a Kind";
                    break;
                case 4:
                    result = "Straight";
                    break;
                case 5:
                    result = "Full House";
                    break;
                case 6:
                    result = "Four of a Kind";
                    break;
                case 7:
                    result = "Impossible";
                    break;
            }
            file = @"C:\Users\qwlik\Desktop\практика\practice\pr_2\bin\Debug\OUTPUT.TXT";
            using (StreamWriter sw = new StreamWriter(file))
            {
                sw.Write(result);
            }
        }
    }
}
