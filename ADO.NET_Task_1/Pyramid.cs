using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ADO.NET_Task_1
{
    public class Pyramid
    {
        // 4 точки основания
        public const int BASE_NUMBER = 4;

        // массив точек основания пирамиды
        public Point[] rectangleOfPyramid;
        // точка вершины
        public Point top;
        // высота пирамиды
        public double height;

        // индексатор для изменения точки
        private int helperNumOfPoint;

        public Pyramid()
        {
            this.rectangleOfPyramid = new Point[BASE_NUMBER];  
        }

        public double RectangleArea
        {
            get
            {
                return GetRectangleArea();
            }
        }

        public double Volume
        {
            get
            {
                return height * GetRectangleArea() / 3;
            }
        }

        //изменение вершины пирамиды
        public void ChangeTop(Point top)
        {
            this.top = top;
        }

        //изменение точки основания
        public void ChangePointOfBase(Point point, int numOfPoint)
        {
            helperNumOfPoint = numOfPoint;
            if (numOfPoint < 0 || numOfPoint > 4)
            {
                throw new ArgumentException("Invalid argument");
            }
            rectangleOfPyramid[numOfPoint] = point;
        }

        #region Private Method

        private bool IsExistBase(double a, double b, double c, double d)
        {
            return (a < b + c + d) && (b < a + c + d) && (c < b + a + d) && (d < b + c + a);
        }


        private double GetRectangleArea()
        {
            double a = Point.GetLength(rectangleOfPyramid[0], rectangleOfPyramid[1]);
            double b = Point.GetLength(rectangleOfPyramid[0], rectangleOfPyramid[3]);
            double c = Point.GetLength(rectangleOfPyramid[1], rectangleOfPyramid[2]);
            double d = Point.GetLength(rectangleOfPyramid[2], rectangleOfPyramid[3]);

            if (!IsExistBase(a, b, c, d))
            {
                throw new ArgumentException("Invalid base");
            }

            return ((a + b) / 2) 
                * Math.Sqrt((c * c) - Math.Pow((Math.Pow((a - b), 2) + (c * c) - (d * d)) / (2 * (a - b)), 2));
        }
        #endregion
    }
}