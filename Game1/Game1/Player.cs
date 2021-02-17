using System;

namespace Game1
{
	class Player
	{
        public static int PlayerEXP = 0, PlayerLVL = 1;
        public static int PlayerHP = 100, PlayerAV = 10;
        public static int LimitBreak = 0;
        public static int PlayerAttack = PlayerLVL * PlayerAV;

        public static int TotalPotions;
        public static int HealingPotions = 3;
        public static int AttackPotions = 3;
        public static int PotionDamageBoost = PlayerLVL * 3;

        public static int PlayerStartHealth, PlayerEndHealth;
        public static int PlayerMaxHealth = PlayerHP + (PlayerHP * (PlayerLVL - 1) / 4);
        public static int PlayerHealth = PlayerHP;

        public static string PlayerName = "default";

        public static void Create()
        {
            Console.Write("Please enter your name: ");

            Player.PlayerName = Console.ReadLine();//player name
        }

        public static void Inventory() 
        {
            TotalPotions = HealingPotions + AttackPotions;
            Console.WriteLine(PlayerName + "'s Inventory\n" + 
                              "-------------\n" + 
                              "1 - Potions\n" +
                              "2 - Food\n" +
                              "3 - Items\n" +
                              "C to continue");
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
            Console.WriteLine("1 - Health (" + HealingPotions + ")\n2 - Attack (" + AttackPotions + ")\n");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    if (HealingPotions == 0)
                    {
                        Console.WriteLine("You have no health potions\n");
                    }
                    else
                    {
                        HealingPotions -= 1;
                        PlayerHealth += 100;
                        PlayerHealth = Math.Min(PlayerHealth, PlayerMaxHealth);
                        Console.WriteLine("You drink a health potion.\nHealth increased to " + PlayerHealth + "\n");
                    }
                    break;
                case "2":
                    if (AttackPotions == 0)
                    {
                        Console.WriteLine("You have no attack boost potions\n");
                    }
                    else
                    {
                        AttackPotions -= 1;
                        Battle.PotionDamageBoostActive = true;
                        Console.WriteLine("You take an attack boost potion.\nYour next attack will deal more damage\n");
                    }
                    break;
                default:
                    Console.WriteLine("Not recognized\n");
                    break;
            }
        }
    }
}

