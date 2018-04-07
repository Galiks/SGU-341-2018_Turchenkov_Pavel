using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Task_3_a
{
    class Program
    {
        static void Main(string[] args)
        {
            IDrawable line = new Line(new Point { x = 3, y = 3 }, new Point { x = 5, y = 5 });

            line.Draw();
            Console.WriteLine(line.Information());

            Console.ReadKey();
        }
    }
}
