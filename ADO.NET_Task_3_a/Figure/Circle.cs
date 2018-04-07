using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Task_3_a.Figure
{
    public class Circle : IDrawable
    {
        private double radius;

        public Circle(Point point, double radius)
        {
            this.Center = point;
            this.Radius = radius;
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

        public double GetCircumference
        {
            get
            {
                return Radius * 2 * Math.PI;
            }
        }

        public void Draw()
        {
            Console.WriteLine("Draw Circle");
        }

        public string Information()
        {
            return $"Радиус = {Radius}{Environment.NewLine}Центр: {Center.x}:{Center.y}{Environment.NewLine}Длина окружности: {GetCircumference}{Environment.NewLine}";
        }
    }
}
