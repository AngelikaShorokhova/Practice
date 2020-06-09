using System;

namespace pr_3
{
    class Program
    {
        public static void InputNumberDouble(string s, out double n)
        {
            bool ok;
            do
            {
                Console.WriteLine("Введите координату х:");
                string stroka = Console.ReadLine();
                ok = double.TryParse(stroka, out n);
                if (!ok)
                    Console.WriteLine("Введено не число");
            } while (!ok);
        }
        public static bool Area(double x, double y)
        {
            bool ok;
            if ((x >= -1 && x <= 1 && y <= 0 && y >= -3) || (x >= -1 && x <= 1 && y <= x))
                ok = true;
            else ok = false;
            return ok;
        }
        protected static void Main(string[] args)
        {
            Console.WriteLine("Задание №3."+Environment.NewLine+"Даны действительные числа х, у. Определить, принадлежит ли точка с координатами х, у заштрихованной части плоскости.");
            double x, y;
            bool ok;
            do
            {
                Console.WriteLine("Введите координату х:");
                string stroka = Console.ReadLine();
                ok = double.TryParse(stroka, out x);
                if (!ok)
                    Console.WriteLine("Введено не число");
            } while (!ok);
            do
            {
                Console.WriteLine("Введите координату y:");
                string stroka = Console.ReadLine();
                ok = double.TryParse(stroka, out y);
                if (!ok)
                    Console.WriteLine("Введено не число");
            } while (!ok);

            if (Area(x, y) == true)
                Console.WriteLine("Точка принадлежит области");
            else Console.WriteLine("Точка не принадлежит области");
            Console.ReadLine();
        }
    }
}
