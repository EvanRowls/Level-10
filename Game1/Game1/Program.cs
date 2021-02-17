using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class MainClass
    {

        //Player Variables

        static int PlayerEXP = 0, PlayerLVL = 1, PlayerHP = 100, PlayerAV = 10, LimitBreak = 0, PlayerAttack = PlayerLVL * PlayerAV;

        static double PlayerHealth = PlayerHP + (PlayerHP * PlayerLVL * .25);

        static string Player;

        //Monster Variables

        static int EnemyAV = 5, EnemyHP = 50;//Enemy Health and attack values

        static Random randLVL = new Random();

        static int monsterLVL = randLVL.Next(PlayerLVL, PlayerLVL + 3), MonsterAttack = EnemyAV * monsterLVL, MonsterHP = monsterLVL * EnemyHP;


        public static void Main(string[] args)
        {
            CreatePlayer ();

            Console.WriteLine();

            Battle();

            Console.ReadLine();
        }


        public static void Battle()
        {
            CreateMonster();
            
            if (PlayerLVL <= 1) 
            {
                PlayerHealth = 100;
            }
            else
            {
                PlayerHealth = PlayerHP + (PlayerHP * PlayerLVL * .25);
            }

            Console.WriteLine("You are level " + PlayerLVL + ".\n");
            Console.WriteLine("You have " + PlayerHealth + " HP.\n");

            Console.WriteLine("You have encoutered a Level " + monsterLVL + " monster.\n");

            //Battle
            
            while (PlayerHealth > 0 && MonsterHP > 0)
            {
                Console.WriteLine("1 - attack\n2 - defend\n3 - Limit break\n");

                string PlayerAction = Console.ReadLine();

                if (PlayerAction == "1")
                {
                    Attack();
                }
                else if (PlayerAction == "2")
                {
                    Defend();
                }
                else if (PlayerAction == "3")
                {
                    SuperAttack();
                }
                else
                {
                    Console.WriteLine("Please choose an action.\n");
                }
            }

        }

        public static void Attack()
        {
            MonsterHP -= PlayerAttack;

            Console.WriteLine("\nYou deal " + PlayerAttack + " points of damage to the monster.\n");

            if (MonsterHP <= 0 && PlayerHealth > 0)
            {
                Aftermath();
            }
            else if (MonsterHP > 0 && PlayerHealth > 0)
            {
                PlayerHealth -= MonsterAttack;

                LimitBreak += 5;

                Console.WriteLine("You receive " + MonsterAttack + " points of damage.\n");

                if (PlayerHealth > 0)
                {
                    Console.WriteLine("You have " + PlayerHealth + " HP left.\n");
                    Console.WriteLine("You have " + LimitBreak + "/100 tech points.\n");
                }
                else
                {
                    Aftermath();
                }
            }
        }

        public static void Defend()
        {
            Random DefenseChance = new Random();

            int ChanceToDefend = DefenseChance.Next(PlayerLVL, 11);

            if (ChanceToDefend % 2 == 1)
            {

                if (PlayerHealth < PlayerHP + (PlayerHP * PlayerLVL * .5))
                {
                    if (PlayerHealth > 0)
                    {
                        PlayerHealth += (MonsterAttack / 5);
                        Console.WriteLine("\nYou block the enemy and regain " + (MonsterAttack / 5) + " Health\n\nYou now have " + PlayerHealth + "HP left.\n");

                        LimitBreak += 3;

                        Console.WriteLine("You have " + LimitBreak + " tech points.\n");
                    }
                    else
                    {
                        Aftermath();
                    }

                }
                else
                {
                    Console.WriteLine("\nYou manage to block the attack.\n");
                }
            }
            else
            {
                PlayerHealth -= (MonsterAttack / 3);

                if (PlayerHealth > 0)
                {
                    Console.WriteLine("\nYou just manage to get up a defense, but it still hurts.\n");
                    Console.WriteLine("You have " + PlayerHealth + " HP left.\n");

                    LimitBreak += 3;

                    Console.WriteLine("You have " + LimitBreak + " tech points.\n");
                }
                else
                {
                    Console.WriteLine("You take more damage than you can stand.\n");
                    Aftermath();
                }

            }
        }

        public static void SuperAttack()
        {
            int PlayerSuper = PlayerAttack * 15;

            if (LimitBreak < 100)
            {
                Console.WriteLine("Not enough tech points.\n You only have " + LimitBreak + " tech points.");
            }
            else
            {
                Console.WriteLine("\n1 - Heal\n2 - Super Attack\n");

                string limitChoice = Console.ReadLine();

                if (limitChoice == "1")
                {
                    double regain = PlayerHP + (PlayerHP * PlayerLVL * .25) / 1.5;

                    PlayerHealth += Convert.ToInt32(regain);

                    Console.WriteLine("You regain " + Convert.ToInt32(regain) + " HP.");
                }
                else if (limitChoice == "2")
                {
                    MonsterHP -= PlayerSuper;

                    Console.WriteLine("\nYou deal " + PlayerSuper + " points of damage to the monster.\n");

                    LimitBreak -= 100;

                    if (MonsterHP <= 0)
                    {
                        Aftermath();
                    }
                    else
                    {
                        PlayerHealth -= MonsterAttack;

                        Console.WriteLine("You receive " + MonsterAttack + " points of damage.\n");
                    }
                }
                else
                {
                    Console.WriteLine("Please choose to heal or attack.");
                }
            }

            Console.WriteLine("You have " + PlayerHealth + " HP left.\n");

            Console.WriteLine("You have " + LimitBreak + " tech points.\n");

            Aftermath();

        }

        public static void Aftermath() 
            {
                //uses PlayerHealth, PlayerEXP, PlayerLVL, monsterLVL, MonsterHP

                if (MonsterHP <= 0)
                {
                    Leveling();

                    if (PlayerLVL < 10)
                    {
                        Battle();
                    }
                    else
                    {
                        Console.WriteLine("Congratulations, you are now unstoppable.");
                    }
                }
                else if (PlayerHealth <= 0)
                {
                    Console.WriteLine("Game Over\n");
                }
                
            }

        public static void CreatePlayer()
        {
            Console.Write("Please enter your name: ");

            Player = Console.ReadLine();//player name
        }

        public static void CreateMonster()
        {
            Random randLVL = new Random();

            monsterLVL = randLVL.Next(PlayerLVL, PlayerLVL + 3);

            MonsterAttack = EnemyAV * monsterLVL;

            MonsterHP = monsterLVL * EnemyHP;
        }

        public static void Leveling()
        {
            Random randEXP = new Random();

            int ExpGain = randEXP.Next(monsterLVL * 50, monsterLVL * 101);

            PlayerEXP += ExpGain;

            Console.WriteLine("\nCongratulations, you beat the monster.\n");
            Console.WriteLine("You gain " + ExpGain + " Experience points\n");
            Console.WriteLine("You now have " + PlayerEXP + " experience points.\n\n");
            Console.WriteLine("You have " + LimitBreak + "/100 tech points.\n");
            Console.ReadLine();

            if (PlayerEXP < 300)
            {
                PlayerLVL = 1;
            }
            else if (PlayerEXP >= 300 && PlayerEXP < 600)
            {
                PlayerLVL = 2;
            }
            else if (PlayerEXP >= 600 && PlayerEXP < 1100)
            {
                PlayerLVL = 3;
            }
            else if (PlayerEXP >= 1100 && PlayerEXP < 1700)
            {
                PlayerLVL = 4;
            }
            else if (PlayerEXP >= 1700 && PlayerEXP < 2300)
            {
                PlayerLVL = 5;
            }
            else if (PlayerEXP >= 2300 && PlayerEXP < 4200)
            {
                PlayerLVL = 6;
            }
            else if (PlayerEXP >= 4200 && PlayerEXP < 6000)
            {
                PlayerLVL = 7;
            }
            else if (PlayerEXP >= 6000 && PlayerEXP < 7350)
            {
                PlayerLVL = 8;
            }
            else if (PlayerEXP >= 7350 && PlayerEXP < 9930)
            {
                PlayerLVL = 9;
            }
            else if (PlayerEXP >= 9930)
            {
                PlayerLVL = 10;
            }
        }

        }
    }