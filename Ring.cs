using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Task_2_b
{
    public class Ring
    {
        private double radius;

        //public Ring(Circle circle1, Circle circle2)
        //{
        //    this.Circle1 = circle1;
        //    this.Circle2 = circle2;
        //}

        public Ring(Circle circle1, double radius)
        {
            this.Circle1 = circle1;
            this.radius = radius;
        }

        #region Свойства

        private double Radius
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
                else throw new ArgumentException("Radius is less then zero");
            }
        }

        private Circle Circle1 { get; set; }

        public double GetArea
        {
            get
            {
                //return RingArea(Circle1.Radius, Circle2.Radius);
                return Math.PI * Math.Abs(Math.Pow(Circle1.Radius,2) - Math.Pow(Radius, 2));
            }
        }

        public double GetSumOfCircumference
        {
            get
            {
                return Circle1.GetCircumference + (Radius * 2 * Math.PI);
            }
        }
        #endregion


        #region Приватные методы
        private double RingArea(double x, double y)
        {
            if (x > y)
            {
                return FuncArea(x, y);
            }
            else
            {
                return FuncArea(y, x);
            }
        }

        private double FuncArea(double x, double y)
        {
            return Math.PI * (x * x - y * y);
        }
        #endregion
    }
}
