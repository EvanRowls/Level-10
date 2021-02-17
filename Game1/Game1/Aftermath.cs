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

        public static void Retreat() 
        {
            Player.PlayerEndHealth = Player.PlayerHealth;
            if (Monster.monsterFleeATKChance == 0)
            {
                if (Player.PlayerEndHealth == Player.PlayerStartHealth)
                {
                    Console.WriteLine("You escape succesfully.\n");
                    End();
                }
                else
                {
                    Console.WriteLine("You manage to escape without further injury.\n");
                    End();
                }
            }
            else
            {
                int FleeDamage = (Monster.MonsterAttack * Monster.monsterFleeATKChance)/10;
                if (FleeDamage == 0)
                {
                    Console.WriteLine("You escape succesfully.\n");
                    End();
                }
                else
                {
                    Console.WriteLine("As you flee, the monster gets in one more attack, dealing " + FleeDamage + " points of damage.\n");
                    Player.PlayerHealth -= FleeDamage;
                    End();
                }
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
            int chance = rnd.Next(4);
            if (chance == 1)
            {
                switch (rnd.Next(2))
                {
                    case 0:
                        Console.WriteLine("You found a health potion.\n");
                        Player.HealingPotions += 1;
                        break;
                    case 1:
                        Console.WriteLine("You found a damage boost potion.\n");
                        Player.AttackPotions += 1;
                        break;
                    case 2:
                        Console.WriteLine("You found a health potion and a damage boost potion.\n");
                        Player.HealingPotions += 1;
                        Player.AttackPotions += 1;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
