using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Task_3_b.Battlefields
{
    public abstract class Battlefield
    {
        public Battlefield(int width, int height, int numbersOfMonsters, int numberOfObstacles, int numberOfBonuses)
        {
            this.Width = width;
            this.Height = height;
            this.NumberOfMonsters = numbersOfMonsters;
            this.NumberOfObstacles = numberOfObstacles;
            this.NumberOfBonuses = numberOfBonuses;
        }

        public int Width { get; set; }
        public int Height { get; set; }
        public int NumberOfMonsters { get; set; }
        public int NumberOfObstacles { get; set; }
        public int NumberOfBonuses { get; set; }
    }
}
