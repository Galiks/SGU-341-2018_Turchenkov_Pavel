using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            PyramidBuilderFromFile fs = new PyramidBuilderFromFile();
            Pyramid pyramid = new Pyramid();

            fs.Read("text", pyramid);
            pyramid.ChangePointOfBase(new Point { x = 2.3, y = 3.3, z = 5.8 }, 0);
            fs.Write("OutPut", pyramid);

        }
    }
}
