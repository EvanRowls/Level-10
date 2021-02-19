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

                int ExpGain = randEXP.Next(Monster.monsterLVL * 50, Monster.monsterLVL * 75);

                Player.PlayerEXP += ExpGain;

                Console.WriteLine("\nCongratulations, you beat the monster.\n");
                Console.WriteLine("You gain " + ExpGain + " Experience points\n");
                Console.WriteLine("You now have " + Player.PlayerEXP + " experience points.\n\n");
                Console.WriteLine("You have " + Player.LimitBreak + "/100 tech points.\n");

                Loot();

                Butcher();

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
                    PostBattle();
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
            Console.Clear();
            Random rnd = new Random();
            int chance = rnd.Next(3);
            Console.WriteLine("");
            bool first = true;

            while (first)
            {
                if (chance == 1)
                {
                    Console.WriteLine("You come across a shop.\n\n" +
                                      "S - Enter shop\n" +
                                      "I - Open your inventory.\n" +
                                      "Enter - Continue on");
                    string choice = Console.ReadLine();
                    choice = choice.ToUpper();

                    switch (choice)
                    {
                        case "S":
                            Shop.Open();
                            Console.WriteLine("\nYou leave the shop.");
                            Console.ReadKey();
                            break;
                        case "I":
                            Player.Inventory();
                            break;
                        case "":
                            first = false;
                            break;
                        default:
                            Console.WriteLine("Please enter a valid option.");
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("I - Open your inventory\nEnter - Continue on");
                    string choice = Console.ReadLine();
                    Console.WriteLine(chance);
                    choice = choice.ToUpper();
                    switch (choice)
                    {
                        case "I":
                            Player.Inventory();
                            break;
                        case "":
                            first = false;
                            break;
                        default:
                            Console.WriteLine("Please enter a valid option.");
                            Console.ReadLine();
                            break;
                    }
                }
            }
        }
        public static void Loot()
        {
            Random rnd = new Random();
            int chance = rnd.Next(2);

            Random rndGold = new Random();
            int GoldMax = Monster.monsterLVL * 30;
            int GoldLoot = rndGold.Next(15, GoldMax);

            Player.Gold += GoldLoot;
            Console.WriteLine(GoldLoot + " Gold");

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
        public static void Butcher()
        {
            Console.WriteLine("Try to harvest some meat from the monster? y/n");
            string butcher = Console.ReadLine();
            butcher = butcher.ToUpper();
            switch (butcher)
            {
                case "Y":
                    int MaxMeat = Monster.monsterLVL * 2;
                    Random rndMeat = new Random();
                    int Meat = rndMeat.Next(MaxMeat);
                    Player.MonsterMeat += Meat;
                    if (Meat > 0)
                    { Console.WriteLine("You manage to cut " + Meat + " pieces of edible meat from the dead monster.\n"); }
                    else
                    { Console.WriteLine("You fail to salvage any edible meat.\n"); }
                    break;
                case "N":
                    break;
                default:
                    Butcher();
                    break;
            }
            Console.ReadKey();
        }
    }
}