using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Task_3_a
{
    class Line : IDrawable
    {
        public Line(Point point1, Point point2)
        {
            this.Point1 = point1;
            this.Point2 = point2;
        }

        double LineLenght
        {
            get
            {
                return Point.GetLength(Point1, Point2);
            }
        }

        Point Point1 { get; set; }
        Point Point2 { get; set; }

        public void Draw()
        {
            Console.WriteLine("Draw Line");
        }

        public string Information()
        {
            return $"Начало: {Point1.x}:{Point1.y}{Environment.NewLine}Конец: {Point2.x}:{Point2.y}{Environment.NewLine}Длина: {LineLenght}{Environment.NewLine}";
        }
    }
}
