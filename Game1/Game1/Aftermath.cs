using System;

namespace Game1
{
    class Aftermath
    {
        public static bool resume = false;
        public static void End()
        {
            if (Monster.MonsterHP <= 0)
            {
                Random randEXP = new Random();

                int ExpGain = randEXP.Next(Monster.monsterLVL * 50, Monster.monsterLVL * 101);

                Player.PlayerEXP += ExpGain;

                Console.WriteLine("\nCongratulations, you beat the monster.\n");
                Console.WriteLine("You gain " + ExpGain + " Experience points\n");
                Console.WriteLine("You now have " + Player.PlayerEXP + " experience points.\n\n");
                Console.WriteLine("You have " + Player.LimitBreak + "/100 tech points.\n");
                Console.WriteLine("\nPress Enter to Continue.\n");
                Console.ReadLine();

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
                        Console.WriteLine("Congratulations, you are now unstoppable.\nPress enter to continue fighting.");
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
            else if (Player.PlayerMaxHealth <= 0)
            {
                Console.WriteLine("Game Over\n");
            }
            else 
            {
                Console.WriteLine("\nPress Enter to Continue.\n");
                Console.ReadLine();
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
                    Console.WriteLine("You escape succesfully.");
                    End();
                }
                else
                {
                    Console.WriteLine("You manage to escape without further injury");
                    End();
                }
            }
            else
            {
                int FleeDamage = (Monster.MonsterAttack * Monster.monsterFleeATKChance)/10;
                if (FleeDamage == 0)
                {
                    Console.WriteLine("You escape succesfully.");
                    End();
                }
                else
                {
                    Console.WriteLine("As you flee, the monster gets in one more attack, dealing " + FleeDamage + " points of damage.");
                    Player.PlayerHealth -= FleeDamage;
                    End();
                }
            }
        }
    }
}
