﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Task_3_b.Monsters
{
    public class Dragon : Monster
    {
        public Dragon(int health, Point position, int powerOfHit) 
            : base(health, position, powerOfHit)
        {
        }
    }
}
