using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Task_3_b.Player
{
    public class Hero: Unit
    {
        public Hero(int health, Point position) : base(health, position)
        {
            this.Power = 0;
        }

        public int Power { get; set; }

        public override Point Move(Point move)
        {
            return Position = new Point { x = Position.x + move.x, y = Position.y + move.y };
        }
    }
}
