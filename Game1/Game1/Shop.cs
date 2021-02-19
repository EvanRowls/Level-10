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


        public static string input;
        public static int Num2sell, Num2buy;

        public static void Open()
        {
            bool inShop = true;

            while (inShop)
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
                        inShop = false;
                        break;
                    default:
                        Console.WriteLine("Please select an action");
                        break;
                }
            }
        }

        public static void Buy()
        {
            bool buying = true;
            while (buying)
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
                        break;
                    case "2":
                        Player.HealingPotions = TransactionBuy(Player.HealingPotions, HealingPotionBuyPrice, " healing potion");
                        break;
                    case "3":
                        Player.SingleAttackPotions = TransactionBuy(Player.SingleAttackPotions, AttackPotionBuyPrice, " attack potion");
                        break;
                    case "4":
                        Player.MultiAttackPotions = TransactionBuy(Player.MultiAttackPotions, MultiAttackPotionBuyPrice, " strength potion");
                        break;
                    case "5":
                        buying = false;
                        Sell();
                        break;
                    case "6":
                        Console.Clear();
                        buying = false;
                        break;
                    default:
                        break;
                }
            }
            Console.Clear();
        }

        public static void Sell()
        {
            bool selling = true;

            while (selling)
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
                        selling = false;
                        Buy();
                        break;
                    case "7":
                        Console.Clear();
                        selling = false;
                        break;
                    default:
                        Console.WriteLine();
                        break;
                }
            }
            Console.Clear();
        }

        public static int TransactionSale(int item, int itemPrice, string itemType)
        {
            if (item > 0)
            {
                bool notInt = true;
                while (notInt)
                {
                    Console.WriteLine("\nHow many would you like to sell?");
                    input = Console.ReadLine();
                    if (int.TryParse(input, out Num2sell))
                    {
                        notInt = false;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a whole number.");
                    }
                }

                if (input == "1")
                {
                    Console.WriteLine("Sell " + input + itemType + "? y/n");
                }
                else
                {
                    Console.WriteLine("Sell " + input + itemType + "s? y/n");
                }

                string confirm = Console.ReadLine();
                bool confirmed = false;
                switch (confirm.ToUpper())
                {
                    case "Y":
                        confirmed = true;
                        break;
                    case "N":
                        confirmed = false;
                        break;
                    default:
                        Console.WriteLine("Please make a valid choice.");
                        TransactionSale(item, itemPrice, itemType);
                        break;

                }

                if (confirmed)
                {
                    if (Num2sell <= item && Num2sell > 1)
                    {
                        Player.Gold += itemPrice * Num2sell;
                        item -= Num2sell;
                        Console.WriteLine("You sell " + Num2sell + itemType + "s\n" +
                                          "You now have " + item + itemType + "s\n");
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                    }
                    else if (Num2sell == 1)
                    {
                        Player.Gold += itemPrice;
                        item -= 1;
                        Console.WriteLine("You sell an" + itemType + "\n" +
                                          "You now have " + item + itemType + "s\n");
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                    }
                    else if (Num2sell > item)
                    {
                        Console.WriteLine("You don't have that many to sell.");
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                    }
                }
                else { Console.WriteLine("No " + itemType + "s to sell"); }
            }

            return item;
        }

        public static int TransactionBuy(int item, int itemPrice, string itemType)
        {
            bool notInt = true;
            while (notInt)
            {
                Console.WriteLine("\nHow many would you like to buy?");
                input = Console.ReadLine();
                if (int.TryParse(input, out Num2buy))
                {
                    notInt = false;
                }
                else
                {
                    Console.WriteLine("Please enter a whole number.");
                }
            }

            if (input == "1")
            {
                Console.WriteLine("Buy " + input + itemType + "? y/n");
            }
            else
            {
                Console.WriteLine("Buy " + input + itemType + "s? y/n");
            }
            string confirm = Console.ReadLine();
            bool confirmed = false;
            switch (confirm.ToUpper())
            {
                case "Y":
                    confirmed = true;
                    break;
                case "N":
                    confirmed = false;
                    break;
                default:
                    Console.WriteLine("Please make a valid choice.");
                    TransactionBuy(item, itemPrice, itemType);
                    break;

            }

            if (confirmed)
            {
                if (Player.Gold >= (itemPrice * Num2buy))
                {
                    if (Num2buy > 1)
                    {
                        Player.Gold -= itemPrice * Num2buy;
                        item += Num2buy;
                        Console.WriteLine("You buy " + Num2buy + itemType + "s\n" +
                                          "You now have " + item + itemType + "s\n");
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                    }
                    else if (Num2buy == 1)
                    {
                        Player.Gold -= itemPrice;
                        item += 1;
                        Console.WriteLine("You buy an" + itemType + "\n" +
                                          "You now have " + item + itemType + "s\n");
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("You buy nothing.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Not enough gold");
                    Console.ReadKey();
                }
            }

            return item;
        }
    }
}