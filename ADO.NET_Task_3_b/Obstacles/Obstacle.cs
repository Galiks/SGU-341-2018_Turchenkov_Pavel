using ADO.NET_Task_3_b.General_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Task_3_b.Obstacles
{
    class Obstacle: FixedObject
    {
        public Obstacle(Point position, int strength) : base(position)
        {
            this.Strength = strength;
        }

        public int Strength { get; set; }
    }
}
