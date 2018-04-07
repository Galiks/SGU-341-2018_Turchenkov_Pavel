using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Task_3_a.Figure
{
    class Rectangle : IDrawable
    {
        private double line1;
        private double line2;

        public Rectangle(double line1, double line2)
        {
            this.line1 = line1;
            this.line2 = line2;
        }

        double Line1
        {
            get
            {
                return line1;
            }
            set
            {
                if (value > 0)
                {
                    line1 = value;
                }
                else
                {
                    throw new Exception("Invalid value");
                }
            }
        }

        double Line2
        {
            get
            {
                return line2;
            }
            set
            {
                if (value > 0)
                {
                    line2 = value;
                }
                else
                {
                    throw new Exception("Invalid value");
                }
            }
        }

        public void Draw()
        {
            Console.WriteLine("Draw Rectangle");
        }

        public string Information()
        {
            return $"Сторона A: {Line1}{Environment.NewLine}Сторона B: {Line2}{Environment.NewLine}";
        }
    }
}
