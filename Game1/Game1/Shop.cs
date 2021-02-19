using System;

namespace Game1
{
    class Shop
    {
        public static int HealingPotionSellPrice = 15;
        public static int InstantHealthPotionSellPrice = 20;
        public static int AttackPotionSellPrice = 15;
        public static int MultiAttackPotionSellPrice = 20;
        public static int MeatSellPrice = 5;

        public static int HealingPotionBuyPrice = 20;
        public static int InstantHealthPotionBuyPrice = 30;
        public static int AttackPotionBuyPrice = 20;
        public static int MultiAttackPotionBuyPrice = 30;

        public static int Num2sell, Num2buy;

        public static void Open()
        {
            Console.WriteLine("Gold available: " + Player.Gold + "\n");
            Console.WriteLine("1 - Buy\n2 - Sell\n3 - Leave\n");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Buy();
                    break;
                case "2":
                    Console.Clear();
                    Sell();
                    break;
                case "3":
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Please select an action");
                    Open();
                    break;
            }
        }

        public static void Buy()
        {
            Console.Clear();
            //Console.WriteLine("1 - Potions\n2 - Weapons\n3 - Food\n");

            Console.WriteLine("        Item         Price      In Inventory" +
                              "\n---------------------------------------------" +
                              //     Instant Health (xx Gold)    -    X
                              "\n1 - Instant Health (" + InstantHealthPotionBuyPrice + " Gold)" + "         " + Player.InstantHealthPotions +
                              "\n2 - Healing        (" + HealingPotionBuyPrice + " Gold)" + "         " + Player.HealingPotions +
                              "\n3 - Attack         (" + AttackPotionBuyPrice + " Gold)" + "         " + Player.SingleAttackPotions +
                              "\n4 - Strength       (" + MultiAttackPotionBuyPrice + " Gold)" + "         " + Player.MultiAttackPotions +
                              "\n                                       Gold: " + Player.Gold +
                              "\n\n5 - Sell" +
                              "\n6 - Go back\n");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Player.InstantHealthPotions = TransactionBuy(Player.InstantHealthPotions, InstantHealthPotionBuyPrice, " instant health potion");
                    Buy();
                    break;
                case "2":
                    Player.HealingPotions = TransactionBuy(Player.HealingPotions, HealingPotionBuyPrice, " healing potion");
                    Buy();
                    break;
                case "3":
                    Player.SingleAttackPotions = TransactionBuy(Player.SingleAttackPotions, AttackPotionBuyPrice, " attack potion");
                    Buy();
                    break;
                case "4":
                    Player.MultiAttackPotions = TransactionBuy(Player.MultiAttackPotions, MultiAttackPotionBuyPrice, " strength potion");
                    Buy();
                    break;
                case "5":
                    Sell();
                    break;
                case "6":
                    break;
                default:
                    Console.WriteLine();
                    break;
            }
            Console.WriteLine("\n\n\nPress any key to continue.");
            Console.ReadKey();
            Console.Clear();
            Open();
        }

        public static void Sell()
        {
            Console.Clear();
            Console.WriteLine("        Item       Sell Price   In Inventory" +
                              "\n---------------------------------------------" +
                              //     Instant Health (xx Gold)    -    X
                              "\n1 - Instant Health (" + InstantHealthPotionSellPrice + " Gold)" + "         " + Player.InstantHealthPotions +
                              "\n2 - Healing        (" + HealingPotionSellPrice + " Gold)" + "         " + Player.HealingPotions +
                              "\n3 - Attack         (" + AttackPotionSellPrice + " Gold)" + "         " + Player.SingleAttackPotions +
                              "\n4 - Strength       (" + MultiAttackPotionSellPrice + " Gold)" + "         " + Player.MultiAttackPotions +
                              "\n5 - Monser meat    (0" + MeatSellPrice + " Gold)" + "         " + Player.MonsterMeat +
                              "\n                                       Gold: " + Player.Gold +
                              "\n\n6 - Buy" +
                              "\n7 - Go back");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Player.InstantHealthPotions = TransactionSale(Player.InstantHealthPotions, InstantHealthPotionSellPrice, " instant health potion");
                    Sell();
                    break;
                case "2":
                    Player.HealingPotions = TransactionSale(Player.HealingPotions, HealingPotionSellPrice, " healing potion");
                    break;
                case "3":
                    Player.SingleAttackPotions = TransactionSale(Player.SingleAttackPotions, AttackPotionSellPrice, " attack potion");
                    break;
                case "4":
                    Player.MultiAttackPotions = TransactionSale(Player.MultiAttackPotions, MultiAttackPotionSellPrice, " strength potion");
                    break;
                case "5":
                    Player.MonsterMeat = TransactionSale(Player.MonsterMeat, MeatSellPrice, " monster meat");
                    break;
                case "6":
                    Buy();
                    break;
                case "7":
                    break;
                default:
                    Console.WriteLine();
                    break;
            }
            Console.WriteLine("\n\n\nPress any key to continue.");
            Console.ReadKey();
            Console.Clear();
            Open();
        }

        public static int TransactionSale(int item, int itemPrice, string itemType)
        {
            if (item > 0)
            {

                bool notInt = true;
                while (notInt)
                {
                    Console.WriteLine("\nHow many would you like to sell?");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out Num2sell))
                    {
                        notInt = false;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a whole number.");
                    }
                }
                if (Num2sell <= item && Num2sell > 1)
                {
                    Player.Gold += itemPrice * Num2sell;
                    item -= Num2sell;
                    Console.WriteLine("You sell " + Num2sell + itemType + "s\n" +
                                      "You now have " + item + itemType + "s\n");
                    Console.WriteLine("\n\nPress any key to continue.");
                    Console.ReadKey();
                }
                else if (Num2sell == 1)
                {
                    Player.Gold += itemPrice;
                    item -= 1;
                    Console.WriteLine("You sell an" + itemType + "\n" +
                                      "You now have " + item + itemType + "s\n");
                    Console.WriteLine("\n\nPress any key to continue.");
                    Console.ReadKey();
                }
                else if (Num2sell > item)
                {
                    Console.WriteLine("You don't have that many to sell.");
                    Console.WriteLine("\n\nPress any key to continue.");
                    Console.ReadKey();
                }
            }
            else { Console.WriteLine("No " + itemType + "s to sell"); }

            return item;
        }

        public static int TransactionBuy(int item, int itemPrice, string itemType)
        {
            bool notInt = true;
            while (notInt)
            {
                Console.WriteLine("\nHow many would you like to buy?");
                string input = Console.ReadLine();
                if (int.TryParse(input, out Num2buy))
                {
                    notInt = false;
                }
                else
                {
                    Console.WriteLine("Please enter a whole number.");
                }
            }
            if (Num2buy > 1)
            {
                Player.Gold -= itemPrice * Num2buy;
                item += Num2buy;
                Console.WriteLine("You buy " + Num2buy + itemType + "s\n" +
                                  "You now have " + item + itemType + "s\n");
                Console.WriteLine("\n\nPress any key to continue.");
                Console.ReadKey();
            }
            else if (Num2buy == 1)
            {
                Player.Gold -= itemPrice;
                item += 1;
                Console.WriteLine("You buy an" + itemType + "\n" +
                                  "You now have " + item + itemType + "s\n");
                Console.WriteLine("\n\nPress any key to continue.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("You buy nothing.");
                Console.ReadKey();
            }

            return item;
        }
    }
}