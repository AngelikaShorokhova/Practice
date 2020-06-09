using System;

namespace pr_11
{
    class Program
    {
        static int[] EasyInsertSort(int[] mas)
        {
            int[] mas1 = new int[mas.Length];
            for (int i = 1; i < mas.Length; i++)
                mas1[i] = mas[i];
            for (int i = 1; i < mas1.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (mas1[j - 1] > mas1[j])
                    {
                        int temp = mas1[j];
                        mas1[j] = mas1[j - 1];
                        mas1[j - 1] = temp;
                    }
                }
            }
            return mas1;
        }
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
        static int[] InputNumbers(int l)
        {
            int[] mas = new int[l];
            for (int i = 0; i < l; i++)
                InputNumberInt($"Введите число №{i + 1} от 1 до {l}", out mas[i]);
            int[] mas1 = EasyInsertSort(mas);
            for (int i = 0; i < l - 1; i++)
            {
                if (mas1[i + 1] - mas1[i] != 1)
                {
                    Console.WriteLine("Неверные числа!");
                    InputNumbers(l);
                    break;
                }
            }
            return mas;
        }
        static string InputString(string s, int l)
        {
            string str;
            do
            {
                Console.WriteLine(s);
                str = Console.ReadLine();
                if (str.Length > l)
                    Console.WriteLine("Строка слишком длинная");

            } while (str.Length > l);
            return str;
        }
        static string Encrypting(int l, int[] numbers, string s)
        {
            if (s.Length < l)
            {
                for (int i = 0; i <= l - s.Length; i++)
                    s += " ";
            }
            char[] sDop = new char[s.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                sDop[i] = s[numbers[i] - 1];
            }
            return new string(sDop);
        }
        static string EncryptingBack(int[] numbers, string s)
        {
            char[] sDop = new char[s.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                sDop[numbers[i] - 1] = s[i];
            }
            return new string(sDop);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Задание №11.");
            int n;
            string s;
            InputNumberInt("Введите длину строки:", out n);
            int[] numbers = InputNumbers(n);
            s = InputString("Введите строку:", n);
            s = Encrypting(n, numbers, s);
            Console.WriteLine(s);
            s = EncryptingBack(numbers, s);
            Console.WriteLine(s);
        }
    }
}
