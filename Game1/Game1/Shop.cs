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

        public static int Num2sell;
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
                              "\n\n5 - Sell" +
                              "\n6 - Go back");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    if (Player.Gold >= InstantHealthPotionBuyPrice)
                    {
                        Player.Gold -= InstantHealthPotionBuyPrice;
                        Player.InstantHealthPotions += 1;
                        Console.WriteLine("You purchase an instant health potion\n" +
                                          "You now have " + Player.InstantHealthPotions + " instant health potions\n");
                    } else { Console.WriteLine("Not enough Gold"); }
                    break;
                case "2":
                    if (Player.Gold >= HealingPotionBuyPrice)
                    {
                        Player.Gold -= HealingPotionBuyPrice;
                        Player.HealingPotions += 1;
                        Console.WriteLine("You purchase a healing potion\n" +
                                          "You now have " + Player.HealingPotions + " healing potions\n");
                    } else { Console.WriteLine("Not enough Gold"); }
                    break;
                case "3":
                    if (Player.Gold >= AttackPotionBuyPrice)
                    {
                        Player.Gold -= AttackPotionBuyPrice;
                        Player.SingleAttackPotions += 1;
                        Console.WriteLine("You purchase an attack potion\n" +
                                          "You now have " + Player.SingleAttackPotions + " attack potions\n");
                    } else { Console.WriteLine("Not enough Gold"); }
                    break;
                case "4":
                    if (Player.Gold >= MultiAttackPotionBuyPrice)
                    {
                        Player.Gold -= MultiAttackPotionBuyPrice;
                        Player.MultiAttackPotions += 1;
                        Console.WriteLine("You purchase a strength potion\n" +
                                          "You now have " + Player.MultiAttackPotions + " strength potions\n");
                    } else { Console.WriteLine("Not enough Gold"); }
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
                              "\n1 - Instant Health (" + InstantHealthPotionSellPrice + " Gold)" + "         "  + Player.InstantHealthPotions +
                              "\n2 - Healing        (" + HealingPotionSellPrice + " Gold)" + "         " + Player.HealingPotions +
                              "\n3 - Attack         (" + AttackPotionSellPrice + " Gold)" + "         " + Player.SingleAttackPotions +
                              "\n4 - Strength       (" + MultiAttackPotionSellPrice + " Gold)" + "         " + Player.MultiAttackPotions +
                              "\n5 - Monser meat    (0" + MeatSellPrice + " Gold)" + "         " + Player.MonsterMeat +
                              "\n\n6 - Buy" +
                              "\n7 - Go back");
            string choice = Console.ReadLine();
            bool notInt = true;

            switch (choice)
            {
                case "1":
                    if (Player.InstantHealthPotions > 0)
                    {
                        while (notInt)
                        {

                            Console.WriteLine("How many would you like to sell?");
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
                        if (Num2sell <= Player.InstantHealthPotions && Num2sell > 0)
                        {
                            Player.Gold += InstantHealthPotionSellPrice * Num2sell;
                            Player.InstantHealthPotions -= Num2sell;
                            Console.WriteLine("You sell an instant health potion\n" +
                                              "You now have " + Player.InstantHealthPotions + " instant health potions\n");
                            Console.WriteLine("\n\n\nPress any key to continue.");
                            Console.ReadKey();
                            Sell();
                        } else
                        {
                            Console.WriteLine("You don't have that many to sell.");
                            Console.WriteLine("\n\n\nPress any key to continue.");
                            Console.ReadKey();
                            Sell();
                        }
                    }
                    else { Console.WriteLine("No instant health potions to sell"); }
                    break;
                case "2":
                    if (Player.HealingPotions > 0)
                    {
                        Player.Gold += HealingPotionSellPrice;
                        Player.HealingPotions -= 1;
                        Console.WriteLine("You sell a healing potion\n" +
                                          "You now have " + Player.HealingPotions + " healing potions\n");
                    }
                    else { Console.WriteLine("No healing potions to sell"); }
                    break;
                case "3":
                    if (Player.SingleAttackPotions > 0)
                    {
                        Player.Gold += AttackPotionSellPrice;
                        Player.SingleAttackPotions -= 1;
                        Console.WriteLine("You sell an attack potion\n" +
                                          "You now have " + Player.SingleAttackPotions + " attack potions\n");
                    }
                    else { Console.WriteLine("No Attack potions available to sell"); }
                    break;
                case "4":
                    if (Player.MultiAttackPotions > 0)
                    {
                        Player.Gold += MultiAttackPotionSellPrice;
                        Player.MultiAttackPotions -= 1;
                        Console.WriteLine("You sell a strength potion\n" +
                                          "You now have " + Player.MultiAttackPotions + " strength potions\n");
                    }
                    else { Console.WriteLine("No strength potions available to sell"); }
                    break;
                case "5":
                    if (Player.MonsterMeat > 0)
                    {
                        Player.Gold += MeatSellPrice;
                        Player.MonsterMeat -= 1;
                        Console.WriteLine("You sell a piece of monester meat\n" +
                                          "You now have " + Player.MonsterMeat + " pieces of meat\n");
                    }
                    else { Console.WriteLine("No meat available to sell"); }
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
    }
}
