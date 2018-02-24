using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ADO.NET_Task_1
{
    public class PyramidBuilderFromFile
    {
        public void Read(string FileName, Pyramid pyramid)
        {
            using (StreamReader file = new StreamReader(FileName + ".txt"))
            {
                double number;
                for (int i = 0; i < Pyramid.BASE_NUMBER; i++)
                {
                    string[] line = file.ReadLine().Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (Double.TryParse(line[0], out number) && 
                        Double.TryParse(line[1], out number) && 
                        Double.TryParse(line[2], out number))
                        pyramid.rectangleOfPyramid[i] = new Point
                        {
                            x = double.Parse(line[0]),
                            y = double.Parse(line[1]),
                            z = double.Parse(line[2])
                        };
                    else throw new ArgumentException("Invalid argument in file");
                }

                string[] lineApex = file.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (Double.TryParse(lineApex[0], out number) && 
                    Double.TryParse(lineApex[1], out number) && 
                    Double.TryParse(lineApex[2], out number))
                    pyramid.top = new Point
                {
                    x = double.Parse(lineApex[0]),
                    y = double.Parse(lineApex[1]),
                    z = double.Parse(lineApex[2])
                };

                pyramid.height = double.Parse(file.ReadLine());
            }
        }

        public void Write(string FileName, Pyramid pyramid)
        {
            using (StreamWriter fileOut = new StreamWriter(FileName + ".txt"))
            {
                fileOut.WriteLine("Площадь основания {0}", pyramid.RectangleArea);
                fileOut.WriteLine("Объём пирамиды {0}", pyramid.Volume);
                
            }
        }
    }
}
