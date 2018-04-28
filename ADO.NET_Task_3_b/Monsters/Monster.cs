using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Task_3_b.Monsters
{
    public class Monster : Unit
    {
        public Monster(int health, Point position, int powerOfHit) : base(health, position)
        {
            this.PowerOfHit = powerOfHit;
        }

        public override Point Move(Point move)
        {
            return Position = new Point { x = Position.x + move.x, y = Position.y + move.y }; 
        }

        public int PowerOfHit { get; set; }
    }
}
