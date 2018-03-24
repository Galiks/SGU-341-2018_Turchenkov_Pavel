using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ADO.NET_Task_2_b
{
    class ReadFileAndBuildRing
    {

        private Point point;
        private double radius1;
        private double radius2;

        public void ReadFile(string fileName)
        {

            using (StreamReader file = new StreamReader(fileName + ".txt"))
            {
                string[] lines = file.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                double number;
                //текстовые данные
                if (Double.TryParse(lines[0], out number) && Double.TryParse(lines[1], out number) )
                {
                    point = new Point
                    {
                        x = double.Parse(lines[0]),
                        y = double.Parse(lines[1])
                    };
                }

                //данные с датой
                try
                {
                    radius1 = double.Parse(file.ReadLine());
                    radius2 = double.Parse(file.ReadLine());
                }
                catch (Exception)
                {
                    throw new Exception("Invalid text in file");
                }
            }
        }

        public void Write(string FileName)
        {
            Ring ring = new Ring(new Circle(point, radius1), radius2);
            using (StreamWriter fileOut = new StreamWriter(FileName + ".txt"))
            {
                fileOut.WriteLine("Площадь {0}", ring.GetArea);
                fileOut.WriteLine("Сумма длин окружностей {0}", ring.GetSumOfCircumference);
            }
        }
    }
}
