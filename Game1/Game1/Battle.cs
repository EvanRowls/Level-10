using System;

namespace Game1
{
    class Battle
    {
        public static void Start()
        {
            Monster.Create();
            Player.PlayerStartHealth = Player.PlayerHealth;

            Console.WriteLine("You are level " + Player.PlayerLVL + ".\n");
            Console.WriteLine("You have " + Player.PlayerHealth + " HP.\n");
            Console.WriteLine("You have " + Player.LimitBreak + " Tech points.\n");

            Console.WriteLine("You have encoutered a Level " + Monster.monsterLVL + " monster.\n");

            //Battle
            while (Player.PlayerHealth > 0 && Monster.MonsterHP > 0)
            {
                Console.WriteLine("1 - attack\n" +
                                  "2 - defend\n" +
                                  "3 - Limit break\n" +
                                  "4 - Inventory\n" +
                                  "5 - Retreat");

                string PlayerAction = Console.ReadLine();

                switch (PlayerAction)
                {
                    case "1":
                        Attack();
                        PotionEffects();
                        break;
                    case "2":
                        Defend();
                        PotionEffects();
                        break;
                    case "3":
                        SuperAttack();
                        PotionEffects();
                        break;
                    case "4":
                        Player.Inventory();
                        break;
                    case "5":
                        Retreat();
                        PotionEffects();
                        break;
                    default:
                        Console.WriteLine("Please choose an action.\n");
                        break;
                }
            }

        }

        public static void Attack()
        {
            if (Player.AttackPotionDamageBoostActive)
            {
                int damage = Player.PlayerAttack * Player.AttackPotionDamageBoost;
                Monster.MonsterHP -= Player.PlayerAttack * Player.AttackPotionDamageBoost;

                Console.WriteLine("\nYou deal " + damage + " points of damage to the monster.\n");
                Player.AttackPotionDamageBoostActive = false;
            } else if (Player.MultiAttackPotionActive)
            {
                int damage = Player.PlayerAttack * Player.MultiAttackPotionBoost;
                Monster.MonsterHP -= Player.PlayerAttack * Player.MultiAttackPotionBoost;

                Console.WriteLine("\nYou deal " + damage + " points of damage to the monster.\n");
            }
            else
            {
                Monster.MonsterHP -= Player.PlayerAttack;

                Console.WriteLine("\nYou deal " + Player.PlayerAttack + " points of damage to the monster.\n");
            }

            if (Monster.MonsterHP <= 0 && Player.PlayerHealth > 0)
            {
                Aftermath.End();
            }
            else if (Monster.MonsterHP > 0 && Player.PlayerHealth > 0)
            {
                Player.PlayerHealth -= Monster.MonsterAttack;

                Player.LimitBreak += 5;

                Console.WriteLine("The monster attacks\n");

                Console.WriteLine("You receive " + Monster.MonsterAttack + " points of damage.\n");

                if (Player.PlayerHealth > 0)
                {
                    Console.WriteLine("You have " + Player.PlayerHealth + " HP left.\n");
                    Console.WriteLine("You have " + Player.LimitBreak + "/100 tech points.\n");
                }
                else
                {
                    Aftermath.End();
                }
            }
        }

        public static void Defend()
        {
            Random DefenseChance = new Random();

            int ChanceToDefend = DefenseChance.Next(Player.PlayerLVL, 11);

            if (ChanceToDefend % 2 == 1)
            {

                if (Player.PlayerHealth < Player.PlayerHP + (Player.PlayerHP * (Player.PlayerLVL - 1) / 2))
                {
                    if (Player.PlayerHealth > 0)
                    {
                        Player.PlayerHealth += (Monster.MonsterAttack / 5);
                        Console.WriteLine("\nYou block the enemy and regain " + (Monster.MonsterAttack / 5) + " Health\n\nYou now have " + Player.PlayerHealth + "HP left.\n");

                        Player.LimitBreak += 3;

                        Console.WriteLine("You have " + Player.LimitBreak + " tech points.\n");
                    }
                    else
                    {
                        Aftermath.End();
                    }

                }
                else
                {
                    Console.WriteLine("\nYou manage to block the attack.\n");
                }
            }
            else
            {
                Player.PlayerHealth -= (Monster.MonsterAttack / 3);

                if (Player.PlayerHealth > 0)
                {
                    Console.WriteLine("\nYou just manage to get up a defense, but it still hurts.\n");
                    Console.WriteLine("You have " + Player.PlayerHealth + " HP left.\n");

                    Player.LimitBreak += 3;

                    Console.WriteLine("You have " + Player.LimitBreak + " tech points.\n");
                }
                else
                {
                    Console.WriteLine("You take more damage than you can stand.\n");
                    Aftermath.End();
                }

            }
        }

        public static void SuperAttack()
        {
            if (Player.LimitBreak < 100)
            {
                Console.WriteLine("Not enough tech points.\nYou only have " + Player.LimitBreak + " tech points.");
            }
            else
            {
                Console.WriteLine("\n1 - Heal\n2 - Super Attack\n");

                string limitChoice = Console.ReadLine();

                switch (limitChoice)
                {
                    case "1":
                        int regain = Player.PlayerMaxHealth / 2;
                        Player.PlayerHealth += regain;
                        Console.WriteLine("You regain " + regain + " HP.");
                        break;
                    case "2":
                        int PlayerSuper = Player.PlayerAttack * 15;
                        Monster.MonsterHP -= PlayerSuper;
                        Console.WriteLine("\nYou deal " + PlayerSuper + " points of damage to the monster.\n");
                        Player.LimitBreak -= 100;
                        if (Monster.MonsterHP <= 0)
                        {
                            Aftermath.End();
                        }
                        else
                        {
                            Player.PlayerHealth -= Monster.MonsterAttack;
                            Console.WriteLine("You receive " + Monster.MonsterAttack + " points of damage.\n");
                            if (Player.PlayerHealth <= 0)
                            {
                                Aftermath.End();
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Please choose to heal or attack.");
                        break;
                }
            }
        }

        public static void Retreat() 
        {
            Console.WriteLine("You attempt to flee.");
            Player.PlayerEndHealth = Player.PlayerHealth;
            if (Monster.monsterFleeATKChance == 0)
            {
                if (Player.PlayerEndHealth == Player.PlayerStartHealth)
                {
                    Console.WriteLine("You escape succesfully.\n");
                    Aftermath.End();
                }
                else
                {
                    Console.WriteLine("You manage to escape without further injury.\n");
                    Aftermath.End(); 
                }
            }
            else
            {
                int FleeDamage = (Monster.MonsterAttack * Monster.monsterFleeATKChance) / 10;
                if (FleeDamage == 0)
                {
                    Console.WriteLine("You escape succesfully.\n");
                    Aftermath.End();
                }
                else
                {
                    Console.WriteLine("As you flee, the monster gets in one more attack, dealing " + FleeDamage + " points of damage.\n");
                    Player.PlayerHealth -= FleeDamage;
                    Aftermath.End();
                }
            }
        }

        public static void PotionEffects()
        {
            if (Player.HealingPotionActive)
            {
                Player.PlayerHealth += 20;
                Player.PlayerHealth = Math.Min(Player.PlayerHealth, Player.PlayerMaxHealth);
                Console.WriteLine("The effects of the healing poiton raise your health to " + Player.PlayerHealth);
                Player.HealingPotionDuration -= 1;
                if (Player.HealingPotionDuration <= 0)
                {
                    Player.HealingPotionActive = false;
                }
            }

            if (Player.MultiAttackPotionActive)
            {
                Player.MultiAttackPotionDuration -= 1;
                if (Player.MultiAttackPotionDuration <= 0)
                {
                    Player.MultiAttackPotionActive = false;
                }
            }
        }
    }
}
