using System;

namespace Game1
{
	class Player
	{
        public static int PlayerEXP = 0, PlayerLVL = 1;
        public static int PlayerHP = 100, PlayerAV = 10;
        public static int LimitBreak = 0;
        public static int PlayerAttack = PlayerLVL * PlayerAV;

        public static int HealingPotions = 0;
        public static int AttackPotions = 0;

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
            Console.WriteLine("1 - Potions\n2 - Food\n3 - Items");
        }
	}
}

