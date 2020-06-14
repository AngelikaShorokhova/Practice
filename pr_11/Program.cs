using System;
using System.Diagnostics.CodeAnalysis;

namespace pr_11
{
    public class Program
    {
        [ExcludeFromCodeCoverage]
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
        [ExcludeFromCodeCoverage]
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
        [ExcludeFromCodeCoverage]
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
        [ExcludeFromCodeCoverage]
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
        public static string Encrypting(int l, int[] numbers, string s)
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
        public static string EncryptingBack(int[] numbers, string s)
        {
            char[] sDop = new char[s.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                sDop[numbers[i] - 1] = s[i];
            }
            return new string(sDop);
        }
        [ExcludeFromCodeCoverage]
        static void Main(string[] args)
        {
            Console.WriteLine("Задание №11.");
            Console.WriteLine("Зафиксируем натуральное k и перестановку чисел 1, ..., k (ее можно задать с помощью последовательности натуральных чисел p1, p2, p3, … pk, в которую входит каждое из чисел 1, …, k). При шифровке в исходном тексте к каждой из последовательных групп по k символов применяется зафиксированная перестановка. Пусть k = 4 и перестановка есть 3, 2, 4, 1. Тогда группа символов s1, s2, s3, s4 заменяется на s3, s2, s4, s1. Если в последней группе меньше четырех символов, то к ней добавляются пробелы. Пользуясь изложенным способом:\nа) зашифровать данный текст;\nб) расшифровать данный текст.");
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
