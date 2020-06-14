using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;

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
        [ExcludeFromCodeCoverage]
        public override string ToString()
        {
            return data.ToString() + " ";
        }
        public override bool Equals(object obj)
        {
            return this.data.Equals(((Point)obj).data);
        }
    }
}
