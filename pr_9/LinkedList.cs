using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace pr_9
{
    public class LinkedList
    {
        public Point beg = null;
        public Point end = null;

        public int Length
        {
            get
            {
                if (beg == null) return 0;
                int lenght = 0;
                Point p = beg;
                while (p != null)
                {
                    p = p.next;
                    lenght++;
                }
                return lenght;
            }
        }
        [ExcludeFromCodeCoverage]
        public Point End
        {
            get
            {
                if (beg == null) return beg;
                Point p = beg;
                while (p.next != null)
                {
                    p = p.next;

                }
                return p;
            }
        }
        [ExcludeFromCodeCoverage]
        public Point Beg
        {
            get { return beg; }
            set { beg = value; }
        }

        public LinkedList()
        {
            beg = null;
            end = null;
        }

        public LinkedList(int N)
        {
            beg = MakeList2(N);
        }
        [ExcludeFromCodeCoverage]
        public Point MakeList1(Point beg, int N, int size)
        {
            Point r = beg;
            N++;
            Point p = new Point(N);
            r.next = p;
            p.pred = r;
            r = p;

            if (N != size) { MakeList1(r, N, size); }
            return beg;
        }
        [ExcludeFromCodeCoverage]
        public Point MakeList2(int size)
        {
            int N = 1;
            Point beg = new Point(N);
            if (N != size) { beg = MakeList1(beg, N, size); }
            return beg;
        }
        public void Swap()
        {
            beg = SwapBeg(beg);
        }
        [ExcludeFromCodeCoverage]
        private Point SwapBeg(Point beg)
        {
            Point p = beg;
            Point temp = new Point(1);
            while (p.next != null) { p = p.next; }
            p.next = temp;
            beg = beg.next;
            return beg;
        }
        [ExcludeFromCodeCoverage]
        public void Search(Point beg, int N1, int number)
        {
            Point p = beg;
            N1++;
            if (N1 == number)
            {
                Console.WriteLine("Элемент с номером {0} найден: {1}", number, p);
                return;
            }
            if (p.next == null)
            {
                Console.WriteLine("Элемент не найден");
                return;
            }
            Search(p.next, N1, number);
        }
        [ExcludeFromCodeCoverage]
        public void PrintList()
        {
            if (beg == null)
            {
                Console.WriteLine("Список пуст");
                return;
            }
            Point p = beg;
            while (p != null)
            {
                Console.Write(p);
                p = p.next;
            }
            Console.WriteLine();
        }
    }
}
