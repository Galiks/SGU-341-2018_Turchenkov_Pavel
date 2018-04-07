using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Task_3_b.Monsters
{
    class Wolf : Monster
    {
        public Wolf(int health, Point position, int powerOfHit) 
            : base(health, position, powerOfHit)
        {
        }
    }
}
