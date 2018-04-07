using ADO.NET_Task_3_b.Battlefields;
using ADO.NET_Task_3_b.Bonuses;
using ADO.NET_Task_3_b.Monsters;
using ADO.NET_Task_3_b.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Task_3_b
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.StartGame();

            Console.ReadKey();
        }
    }
}
