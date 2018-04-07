using ADO.NET_Task_3_b.General_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Task_3_b.Bonuses
{
    class Bonus: FixedObject
    {
        public Bonus(Point position, int power) : base(position)
        {
            this.Power = power;
        }

        public int Power { get; set; }

        public string Time(DateTime bonusTime)
        {
            return $"Time of bonus: {bonusTime}";
        }
    }
}
