﻿using System;

namespace Game1
{
    class Shop
    {
        public static int HealingPotionSellPrice = 15;
        public static int InstantHealthPotionSellPrice = 20;
        public static int AttackPotionSellPrice = 15;
        public static int MultiAttackPotionSellPrice = 20;

        public static int HealingPotionBuyPrice = 20;
        public static int InstantHealthPotionBuyPrice = 30;
        public static int AttackPotionBuyPrice = 20;
        public static int MultiAttackPotionBuyPrice = 30;
        public static void Open()
        {
            Console.WriteLine("Gold available: " + Player.Gold + "\n");
            Console.WriteLine("1 - Buy\n2 - Sell\n3 - Leave\n");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Buy();
                    break;
                case "2":
                    Sell();
                    break;
                case "3":
                    break;
                default:
                    Console.WriteLine("Please select an action");
                    Open();
                    break;
            }
        }

        public static void Buy()
        {
            //Console.WriteLine("1 - Potions\n2 - Weapons\n3 - Food\n");

            Console.WriteLine("1 - Instant Health(" + InstantHealthPotionBuyPrice + " Gold)" +
                              "\n2 - Healing(" + HealingPotionBuyPrice + " Gold)" +
                              "\n3 - Attack(" + AttackPotionBuyPrice + " Gold)" +
                              "\n4 - Strength(" + MultiAttackPotionBuyPrice + " Gold)" +
                              "\n\n5 - Go back");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    if (Player.Gold >= InstantHealthPotionBuyPrice)
                    {
                        Player.Gold -= InstantHealthPotionBuyPrice;
                        Player.InstantHealthPotions += 1;
                    } else { Console.WriteLine("Not enough Gold"); }
                    break;
                case "2":
                    if (Player.Gold >= HealingPotionBuyPrice)
                    {
                        Player.Gold -= HealingPotionBuyPrice;
                        Player.HealingPotions += 1;
                    } else { Console.WriteLine("Not enough Gold"); }
                    break;
                case "3":
                    if (Player.Gold >= AttackPotionBuyPrice)
                    {
                        Player.Gold -= AttackPotionBuyPrice;
                        Player.SingleAttackPotions += 1;
                    } else { Console.WriteLine("Not enough Gold"); }
                    break;
                case "4":
                    if (Player.Gold >= MultiAttackPotionBuyPrice)
                    {
                        Player.Gold -= MultiAttackPotionBuyPrice;
                        Player.MultiAttackPotions += 1;
                    } else { Console.WriteLine("Not enough Gold"); }
                    break;
                case "5":
                    break;
                default:
                    Console.WriteLine();
                    break;
            }
        }

        public static void Sell()
        {
            Console.WriteLine("1 - Instant Health(" + InstantHealthPotionSellPrice + " Gold)" +
                              "\n2 - Healing(" + HealingPotionSellPrice + " Gold)" +
                              "\n3 - Attack(" + AttackPotionSellPrice + " Gold)" +
                              "\n4 - Strength(" + MultiAttackPotionSellPrice + " Gold)" +
                              "\n\n5 - Go back");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    if (Player.InstantHealthPotions > 0)
                    {
                        Player.Gold += InstantHealthPotionSellPrice;
                        Player.InstantHealthPotions -= 1;
                    }
                    else { Console.WriteLine("No instant health potions to sell"); }
                    break;
                case "2":
                    if (Player.HealingPotions > 0)
                    {
                        Player.Gold += HealingPotionSellPrice;
                        Player.HealingPotions -= 1;
                    }
                    else { Console.WriteLine("No healing potions to sell"); }
                    break;
                case "3":
                    if (Player.SingleAttackPotions > 0)
                    {
                        Player.Gold += AttackPotionSellPrice;
                        Player.SingleAttackPotions -= 1;
                    }
                    else { Console.WriteLine("No Attack potions available to sell"); }
                    break;
                case "4":
                    if (Player.MultiAttackPotions > 0)
                    {
                        Player.Gold += MultiAttackPotionSellPrice;
                        Player.MultiAttackPotions -= 1;
                    }
                    else { Console.WriteLine("No strength potions available to sell"); }
                    break;
                case "5":
                    break;
                default:
                    Console.WriteLine();
                    break;
            }
        }
    }
}