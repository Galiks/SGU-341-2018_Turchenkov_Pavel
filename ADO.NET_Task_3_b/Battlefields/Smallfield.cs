﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Task_3_b.Battlefields
{
    public class Smallfield : Battlefield
    {
        public Smallfield(int width, int height, int numbersOfMonsters, int numberOfObstacles, int numberOfBonuses)
            : base(width, height, numbersOfMonsters, numberOfObstacles, numberOfBonuses)
        {
        }
    }
}
