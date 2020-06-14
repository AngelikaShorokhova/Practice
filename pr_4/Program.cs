using System;
using System.Diagnostics.CodeAnalysis;

namespace pr_4
{
    public class Program
    {
        [ExcludeFromCodeCoverage]
        static void InputNumberDouble(string s, out double n)
        {
            bool ok;
            do
            {
                Console.WriteLine(s);
                string stroka = Console.ReadLine();
                ok = double.TryParse(stroka, out n);
                if (!ok)
                    Console.WriteLine("Введено не число");
            } while (!ok);
        }
        public static double Factorial(int x)
        {
            if (x == 0)
                return 1;
            else
                return x * Factorial(x - 1);
        }
        public static double Modul(double x)
        {
            if (x < 0)
                return -x;
            else
                return x;
        }

        public static double Stepen(int x)
        {
            if (x % 2 == 0)
                return 1;
            else
                return -1;
        }
        public static double Result(double e, int i)
        {
            double sum = 0;
            double x = Stepen(i) / Factorial(i);
            while (Modul(x) >= e)
            {
                sum += x;
                i++;
                x = Stepen(i) / Factorial(i);
            }
            return sum;
        }
        [ExcludeFromCodeCoverage]
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Задание №4."+Environment.NewLine+ "Вычислить бесконечную сумму с заданной точностью e (e>0)." + Environment.NewLine + "Считать, что требуемая точность достигнута, если вычислена сумма нескольких первых слагаемых" + Environment.NewLine + "и очередное слагаемое оказалось по модулю меньше, чем е, это и все последующие слагаемые можно уже не учитывать.");
            double e;
            InputNumberDouble("Введите е:", out e);
            int i = 0;
            Console.WriteLine(Result(e, i) + " ");
            Console.WriteLine("Для продолжения нажмите любую клавишу, для выхода нажмите 0...");
            if (Console.ReadLine() != "0")
                Main(args);
        }
    }
}
