using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Task_3_a
{
    public struct Point
    {
        public double x, y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public static Point operator - (Point a, Point b)
        {
            return new Point { x = b.x - a.x, y = b.y - a.y};
        }

        public static double GetLength(Point a, Point b)
        {
            Point vector = b - a;
            return Math.Sqrt(Math.Pow(vector.x, 2) + Math.Pow(vector.y, 2));
        }
    }
}
