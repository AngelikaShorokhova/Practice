using System;
using System.IO;

namespace pr_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание №1." + Environment.NewLine + "Дан некоторый набор букв и словарь." + Environment.NewLine + "Ваша задача - подсчитать, сколько различных слов из словаря можно составить из этих букв." + Environment.NewLine + "В первой строке файла INPUT.TXT записано число N - количество слов в словаре." + Environment.NewLine + "В следующих N строках файла записано по одному слову из словаря." + Environment.NewLine + "Слова содержат от 1 до 10 маленьких английских букв. Все слова в словаре различны." + Environment.NewLine + "В последней строке файла записан набор букв (от 1 до 100 букв)." + Environment.NewLine + "Запишите в файл OUTPUT.TXT количество различных слов из словаря, которые можно составить из заданного набора букв."+ Environment.NewLine);
            int result = 0;
            bool ok;
            string file = @"C:\Users\qwlik\Desktop\практика\practice\pr_1\bin\Debug\INPUT.TXT";
            string s;
            try
            { 
                using (StreamReader sr = new StreamReader(file))
                {
                    s = sr.ReadToEnd();
                }
                string[] str = s.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                int n;
                int.TryParse(str[0], out n);
                int[] letters = new int[26];
                int[] letters2 = new int[26];
                string[] array = new string[n];
                for (int i = 1; i < str.Length - 1; i++)
                    array[i - 1] = str[i];
                for (int i = 0; i < str[str.Length - 1].Length; i++)
                    letters[(int)str[str.Length - 1][i] - 97]++;
                for (int i = 0; i < n; i++)
                {
                    ok = true;
                    for (int j = 0; j < letters.Length; j++) letters2[j] = letters[j];
                    for (int j = 0; j < array[i].Length - 1; j++)
                    {
                        if (letters2[array[i][j] - 97] == 0) ok = false;
                        else letters2[array[i][j] - 97]--;
                    }
                    if (ok) result++;
                }
                file = @"C:\Users\qwlik\Desktop\практика\practice\pr_1\bin\Debug\OUTPUT.TXT";
                using (StreamWriter sw = new StreamWriter(file))
                {
                    sw.Write(result); Console.WriteLine("Результат записан в файл!");
                }
            }
            catch { Console.WriteLine("Ошибка:файл не найден или пуст!"); }
        }
    }
}
