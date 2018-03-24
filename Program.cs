using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ADO.NET_Task_2_b
{
    class Program
    {
        static void Main(string[] args)
        {

            ReadFileAndBuildRing file = new ReadFileAndBuildRing();

            file.ReadFile("Ring");
            file.Write("OutFile");

            //Ring ring = new Ring(new Circle(new Point { x = 1, y = 2 }, 2), new Circle(new Point { x = 1, y = 2 }, 4));

            //Console.WriteLine(ring.GetArea);

            //Console.ReadKey();
        }
    }
}
