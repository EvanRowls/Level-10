using System;

namespace Game1
{
    class Aftermath
    {
        public static bool resume = false;
        public static void End()
        {
            if (Monster.MonsterHP <= 0 && Player.PlayerHealth > 0)
            {
                Random randEXP = new Random();

                int ExpGain = randEXP.Next(Monster.monsterLVL * 50, Monster.monsterLVL * 101);

                Player.PlayerEXP += ExpGain;

                Console.WriteLine("\nCongratulations, you beat the monster.\n");
                Console.WriteLine("You gain " + ExpGain + " Experience points\n");
                Console.WriteLine("You now have " + Player.PlayerEXP + " experience points.\n\n");
                Console.WriteLine("You have " + Player.LimitBreak + "/100 tech points.\n");

                Loot();

                PostBattle();

                Level.Check();

                if (resume == false)
                {
                    if (Player.PlayerLVL < 10)
                    {
                        Console.Clear();

                        Battle.Start();
                    }
                    else
                    {
                        Console.WriteLine("Congratulations, you are now unstoppable.\nPress enter to continue fighting.\n");
                        Console.ReadLine();
                        resume = true;
                    }
                }
                else
                {
                    Console.Clear();

                    Battle.Start();
                }
            }
            else if (Player.PlayerHealth <= 0)
            {
                Console.WriteLine("Game Over\n");
            }
            else 
            {
                PostBattle();
                Console.Clear();
                Battle.Start();
            }
            
        }

        public static void PostBattle()
        {
            Console.WriteLine("Press Enter to Continue on or I to open your inventory.\n");
            string choice = Console.ReadLine();
            choice = choice.ToUpper();

            switch (choice)
            {
                case "I":
                    Player.Inventory();
                    PostBattle();
                    break;
                default:
                    break;
            }
        }
        
        public static void Loot()
        {
            Random rnd = new Random();
            int chance = rnd.Next(2);
            if (chance == 1) //did you find any items
            {
                switch (rnd.Next(4))  //What did you find
                {
                    case 0:
                        Console.WriteLine("You found an instant health potion.\n");
                        Player.InstantHealthPotions += 1;
                        break;
                    case 1:
                        Console.WriteLine("You found an attack potion.\n");
                        Player.SingleAttackPotions += 1;
                        break;
                    case 2:
                        Console.WriteLine("You found an instant health potion and an attack potion.\n");
                        Player.InstantHealthPotions += 1;
                        Player.SingleAttackPotions += 1;
                        break;
                    case 3:
                        Console.WriteLine("You found a strength potion");
                        Player.MultiAttackPotions += 1;
                        break;
                    case 4:
                        Console.WriteLine("You found a healing potion");
                        Player.HealingPotions += 1;
                        break;
                    default:
                        Console.WriteLine("If you're seeing this message, something very strange has happened.");
                        break;
                }
            }
        }
    }
}
