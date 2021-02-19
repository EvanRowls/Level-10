using System;

namespace Game1
{
    public class Monster
    {
        public static int EnemyAV = 5, EnemyHP = 50;

        public static int monsterLVL;
        public static int MonsterAttack;
        public static int MonsterHP;
        public static int monsterFleeATKChance = 0;

        public Monster()
        {
            Random randLVL = new Random();
            Random randATK = new Random();

            monsterLVL = randLVL.Next(1, Math.Min(Player.PlayerLVL + 2, 10));
            monsterFleeATKChance = randATK.Next(0, 4);
            MonsterAttack = EnemyAV * monsterLVL;
            MonsterHP = (monsterLVL * 5) + EnemyHP;
        }
    }
}