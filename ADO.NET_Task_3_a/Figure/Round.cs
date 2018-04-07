using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Task_3_a.Figure
{
    class Round: IDrawable
    {
        private double radius;

        public Round(Point point, double radius)
        {
            this.Center = point;
            this.Radius = radius;
        }

        private Point Center { get; set; }

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
                else
                {
                    throw new ArgumentException("Radius is less then zero");
                }
            }
        }

        private double GetArea
        {
            get
            {
                return Radius * Radius * Math.PI;
            }
        }

        public void Draw()
        {
            Console.WriteLine("Draw Round");
        }

        public string Information()
        {
            return $"Радиус = {Radius}{Environment.NewLine}Центр: {Center.x}:{Center.y}{Environment.NewLine}Площадь: {GetArea}{Environment.NewLine}";
        }

    }
}
