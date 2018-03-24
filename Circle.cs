using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Task_2_b
{
    public class Circle
    {
        private double radius;

        public Circle(Point point, double radius)
        {
            Center = point;
            Radius = radius;
        }

        public Point Center { get; set; }

        public double Radius
        {
            get
            {
                return radius;
            }

            set
            {
                if (value > 0)
                {
                    radius = value;
                }
                else
                {
                    throw new ArgumentException("Radius is less then zero");
                }
            }
        }



        //r*2*pi
        public double GetCircumference
        {
            get
            {
                return Radius * 2 * Math.PI;
            }
        }
    }
}
