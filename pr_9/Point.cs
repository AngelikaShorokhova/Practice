using System;
using System.Collections.Generic;
using System.Text;

namespace pr_9
{
    public class Point
    {
        public int data;
        public Point next;
        public Point pred;
        public Point()
        {
            data = 0;
            next = null;
            pred = null;
        }
        public Point(int d)
        {
            data = d;
            next = null;
            pred = null;
        }
        public override string ToString()
        {
            return data.ToString() + Environment.NewLine;
        }
    }
}
