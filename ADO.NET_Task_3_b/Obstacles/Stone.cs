﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Task_3_b.Obstacles
{
    public class Stone : Obstacle
    {
        public Stone(Point position, int strength) : base(position, strength)
        {
        }
    }
}
