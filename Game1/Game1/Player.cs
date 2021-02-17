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

        public static int TotalPotions;
        public static int InstantHealthPotions = 3;
        public static int HealingPotions = 1;
        public static int SingleAttackPotions = 3;
        public static int MultiAttackPotions = 1;

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
            TotalPotions = InstantHealthPotions + SingleAttackPotions;
            Console.WriteLine(PlayerName + "'s Inventory\n" + 
                              "-------------\n" + 
                              "1 - Potions\n" +
                              "2 - Food\n" +
                              "3 - Items\n" +
                              "C to continue\n");
            string choice = Console.ReadLine();
            choice = choice.ToUpper();

            switch (choice)
            {
                case "1":
                    if (TotalPotions == 0)
                    {
                        Console.WriteLine("Nothing Here");
                    }
                    else
                    {
                        Potions();
                    }
                    Inventory();
                    break;
                case "2":
                    Inventory();
                    break;
                case "3":
                    Inventory();
                    break;
                case "C":
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    Inventory();
                    break;
            }
        }

        public static void Potions()
        {
            Console.WriteLine("1 - Instant Health (" + InstantHealthPotions + ")\n" +
                              "2 - Healing (" + HealingPotions + ")\n" +
                              "3 - Attack (" + SingleAttackPotions + ")\n" +
                              "4 - Strength (" + MultiAttackPotions + ")\n");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    if (InstantHealthPotions == 0)
                    {
                        Console.WriteLine("You have no health potions\n");
                    }
                    else
                    {
                        InstantHealthPotions -= 1;
                        PlayerHealth += 100;
                        PlayerHealth = Math.Min(PlayerHealth, PlayerMaxHealth);
                        Console.WriteLine("You drink a health potion.\nHealth increased to " + PlayerHealth + "\n");
                    }
                    break;
                case "2":
                    if (HealingPotions == 0)
                    {
                        Console.WriteLine("You have no health potions\n");
                    }
                    else
                    {
                        HealingPotions -= 1;
                        HealingPotionDuration = 3;
                        HealingPotionActive = true;
                        Console.WriteLine("You drink a healing potion.\nHealth will be restored over the next three turns\n");
                    }
                    break;
                case "3":
                    if (SingleAttackPotions == 0)
                    {
                        Console.WriteLine("You have no attack boost potions\n");
                    }
                    else
                    {
                        SingleAttackPotions -= 1;
                        AttackPotionDamageBoostActive = true;
                        Console.WriteLine("You take an attack boost potion.\nYour next attack will deal more damage\n");
                    }
                    break;
                case "4":
                    if (MultiAttackPotions == 0)
                    {
                        Console.WriteLine("You have no strength potions\n");
                    }
                    else
                    {
                        MultiAttackPotions -= 1;
                        MultiAttackPotionDuration = 3;
                        MultiAttackPotionActive = true;
                        Console.WriteLine("You take a strength potion.\nYour next three attacks will deal slightly more damage\n");
                    }
                    break;
                default:
                    Console.WriteLine("Not recognized\n");
                    break;
            }
        }
    }
}

