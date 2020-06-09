using System;
using System.Collections.Generic;
using System.Text;

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
        public Point MakeList2(int size)
        {
            int N = 1;
            Point beg = new Point(N);
            if (N != size) { beg = MakeList1(beg, N, size); }
            return beg;
        }

        public void PrintList()
        {
            if (beg == null)
            {
                Console.WriteLine("Пустой список");
                return;
            }
            Point p = beg;
            while (p != null)
            {
                Console.Write(p);
                p = p.next;
            }
        }
    }
}
