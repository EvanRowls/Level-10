using System;

namespace Game1
{
    class Player
    {
        //Initial player values
        public static int PlayerEXP = 0, PlayerLVL = 1;
        public static int PlayerHP = 100, PlayerAV = 10;
        public static int LimitBreak = 0;
        public static string PlayerName = "default";

        //Inventory
        public static int Gold = 100;
        public static int TotalPotions;
        public static int InstantHealthPotions = 3;
        public static int HealingPotions = 1;
        public static int SingleAttackPotions = 3;
        public static int MultiAttackPotions = 1;
        public static int MonsterMeat = 0;

        public static int HealingPotionDuration;
        public static bool HealingPotionActive = false;
        public static int MultiAttackPotionDuration;
        public static bool MultiAttackPotionActive = false;
        public static int MultiAttackPotionBoost = Math.Max(PlayerLVL, 2);
        public static int AttackPotionDamageBoost = PlayerLVL + 2;
        public static bool AttackPotionDamageBoostActive = false;

        //Player stats
        public static int PlayerStartHealth, PlayerEndHealth;
        public static int PlayerMaxHealth = PlayerHP + (PlayerHP * (PlayerLVL - 1) / 4);
        public static int PlayerHealth = PlayerHP;
        public static int PlayerAttack = PlayerLVL * PlayerAV;

        public static void Create()
        {
            Console.Write("Please enter your name: ");

            PlayerName = Console.ReadLine();//player name

        }

        public static void Inventory()
        {
            Console.Clear();
            TotalPotions = InstantHealthPotions + SingleAttackPotions + HealingPotions + MultiAttackPotions;
            Console.WriteLine(PlayerName + "'s Inventory\n" +
                              "-------------\n" +
                              "1 - Potions\n" +
                              "2 - Food\n" +
                              "3 - Items\n" +
                              "C - continue\n");
            string choice = Console.ReadLine();
            choice = choice.ToUpper();

            switch (choice)
            {
                case "1":
                    if (TotalPotions == 0)
                    {
                        Console.WriteLine("Nothing Here");
                        Console.ReadKey();
                    }
                    else
                    {
                        Potions();
                    }
                    Inventory();
                    break;
                case "2":
                    if (MonsterMeat == 0)
                    {
                        Console.WriteLine("Nothing Here");
                        Console.ReadKey();
                    }
                    else
                    {
                        Food();
                    }
                    Inventory();
                    break;
                case "3":
                    Inventory();
                    break;
                case "C":
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    Console.ReadKey();
                    Inventory();
                    break;
            }
        }

        public static void Potions()
        {
            Console.WriteLine("1 - Instant Health (" + InstantHealthPotions + ")\n" +
                              "2 - Healing (" + HealingPotions + ")\n" +
                              "3 - Attack (" + SingleAttackPotions + ")\n" +
                              "4 - Strength (" + MultiAttackPotions + ")\n" +
                              "5 - Go back");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    if (InstantHealthPotions == 0)
                    {
                        Console.WriteLine("You have no health potions\n");
                        Console.ReadKey();
                    }
                    else
                    {
                        InstantHealthPotions -= 1;
                        PlayerHealth += 100;
                        PlayerHealth = Math.Min(PlayerHealth, PlayerMaxHealth);
                        Console.WriteLine("You drink a health potion.\nHealth increased to " + PlayerHealth + "\n");
                        Console.ReadKey();
                    }
                    break;
                case "2":
                    if (HealingPotions == 0)
                    {
                        Console.WriteLine("You have no health potions\n");
                        Console.ReadKey();
                    }
                    else
                    {
                        HealingPotions -= 1;
                        HealingPotionDuration = 3;
                        HealingPotionActive = true;
                        Console.WriteLine("You drink a healing potion.\nHealth will be restored over the next three turns\n");
                        Console.ReadKey();
                    }
                    break;
                case "3":
                    if (SingleAttackPotions == 0)
                    {
                        Console.WriteLine("You have no attack boost potions\n");
                        Console.ReadKey();
                    }
                    else
                    {
                        SingleAttackPotions -= 1;
                        AttackPotionDamageBoostActive = true;
                        Console.WriteLine("You take an attack boost potion.\nYour next attack will deal more damage\n");
                        Console.ReadKey();
                    }
                    break;
                case "4":
                    if (MultiAttackPotions == 0)
                    {
                        Console.WriteLine("You have no strength potions\n");
                        Console.ReadKey();
                    }
                    else
                    {
                        MultiAttackPotions -= 1;
                        MultiAttackPotionDuration = 3;
                        MultiAttackPotionActive = true;
                        Console.WriteLine("You take a strength potion.\nYour next three attacks will deal slightly more damage\n");
                        Console.ReadKey();
                    }
                    break;
                case "5":
                    break;
                default:
                    Console.WriteLine("Not recognized\n");
                    Console.ReadKey();
                    break;
            }
        }
        public static void Food()
        {
            Console.WriteLine("You have " + MonsterMeat + " pieces of meat." +
                              "\n1 - Eat a piece of meat" +
                              "\n2 - Go back");
            string choice = Console.ReadLine();
            switch (choice.ToUpper())
            {
                case "1":
                    Console.WriteLine("You eat a piece of meat.\nYour regain five points of health");
                    MonsterMeat -= 1;
                    PlayerHealth += 5;
                    break;
                case "2":
                    break;
                default:
                    Console.WriteLine("Please choose a valid option.");
                    Food();
                    break;
            }
            Console.ReadKey();
        }
    }
}