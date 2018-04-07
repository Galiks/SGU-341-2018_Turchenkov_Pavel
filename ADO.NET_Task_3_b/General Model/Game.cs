using ADO.NET_Task_3_b.Battlefields;
using ADO.NET_Task_3_b.Bonuses;
using ADO.NET_Task_3_b.Monsters;
using ADO.NET_Task_3_b.Obstacles;
using ADO.NET_Task_3_b.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Task_3_b
{
    static class Game
    {
        static Battlefield PlayerField { get; set; }
        static Hero PlayerHero { get; set; }
        static Monster MyMonster { get; set; }
        static Bonus MyBonus { get; set; }
        static Obstacle MyObstacle { get; set; }

        public static void StartGame()
        {
            SelectField();

            PlacementObject();
        }

        static void SelectField()
        {
            Console.WriteLine($"Select the field{Environment.NewLine}1 - Small field (10x15){Environment.NewLine}2 - Medium field (30x35){Environment.NewLine}3 - Big field (50x55)");
            try
            {
                int selectField = int.Parse(Console.ReadLine());
                switch (selectField)
                {
                    case 1:
                        {
                            PlayerField = new Smallfield(10, 15, 2, 2, 3);
                            SelectHero();
                            break;
                        }
                    case 2:
                        {
                            PlayerField = new Mediumfield(30, 35, 5, 7, 6);
                            SelectHero();
                            break;
                        }
                    case 3:
                        {
                            PlayerField = new Bigfield(50, 55, 9, 15, 11);
                            SelectHero();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine($"Invalid number");
                            SelectField();
                            break;
                        }
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Invalid number");
                SelectField();
            }
        }

        static void SelectHero()
        {
            Console.WriteLine($"Select the hero{Environment.NewLine}1 - Hare{Environment.NewLine}2 - Snail{Environment.NewLine}3 - Snake");
            try
            {
                int selectHero = int.Parse(Console.ReadLine());
                switch (selectHero)
                {
                    case 1:
                        {
                            PlayerHero = new BattleHare(100, new Point { x = 1, y = 1 });
                            break;
                        }
                    case 2:
                        {
                            PlayerHero = new BattleSnail(150, new Point { x = 1, y = 1 });
                            break;
                        }
                    case 3:
                        {
                            PlayerHero = new BattleSnake(125, new Point { x = 1, y = 1 });
                            break;
                        }
                    default:
                        {
                            Console.WriteLine($"Invalid number");
                            SelectHero();
                            break;
                        }
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Invalid number");
                SelectHero();
            }
        }

        static void PlacementObject()
        {
            Random random = new Random();

            #region Monsters-2
            MyMonster = new Bear(300, new Point
            {
                x = random.Next(PlayerHero.Position.x + 2, PlayerField.Width),
                y = random.Next(PlayerHero.Position.y + 2, PlayerField.Height)
            },
            20);

            MyMonster = new Wolf(200, new Point
            {
                x = random.Next(PlayerHero.Position.x + 2, PlayerField.Width),
                y = random.Next(PlayerHero.Position.y + 2, PlayerField.Height)
            },
            15);
            #endregion

            #region Obstacles-2
            MyObstacle = new Tree(new Point
            {
                x = random.Next(PlayerHero.Position.x + 1, PlayerField.Width),
                y = random.Next(PlayerHero.Position.y + 3, PlayerField.Height)
            }, 
            100);

            MyObstacle = new Stone(new Point
            {
                x = random.Next(PlayerHero.Position.x + 1, PlayerField.Width),
                y = random.Next(PlayerHero.Position.y + 3, PlayerField.Height)
            },
            100);
            #endregion

            #region Bonus-3
            MyBonus = new Apple(new Point
            {
                x = random.Next(PlayerHero.Position.x + 1, PlayerField.Width),
                y = random.Next(PlayerHero.Position.y + 3, PlayerField.Height)
            },
            30);

            MyBonus = new Cherry(new Point
            {
                x = random.Next(PlayerHero.Position.x + 1, PlayerField.Width),
                y = random.Next(PlayerHero.Position.y + 3, PlayerField.Height)
            },
            20);

            MyBonus = new Shaurma(new Point
            {
                x = random.Next(PlayerHero.Position.x + 1, PlayerField.Width),
                y = random.Next(PlayerHero.Position.y + 3, PlayerField.Height)
            },
            50);

            #endregion
        }

        static void Gameplay()
        {
            if(PlayerHero.Power == 100)
            {
                Console.WriteLine("YOU WIN!");
            }
        }
    }
}
