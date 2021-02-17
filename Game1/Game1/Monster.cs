using System;

namespace Game1
{
	public class Monster
	{

		public static int EnemyAV = 5, EnemyHP = 50;//Enemy Health and attack values

        public static Random randLVL = new Random();
        public static Random randATK = new Random();

        public static int monsterLVL = randLVL.Next(Player.PlayerLVL, Player.PlayerLVL + 3);
        public static int MonsterAttack = EnemyAV * monsterLVL;
        public static int MonsterHP = monsterLVL * EnemyHP;
        public static int monsterFleeATKChance = 0;


        public static void Create()
        {
            Random randLVL = new Random();
            Random randATK = new Random();

            monsterLVL = randLVL.Next( Math.Max(Player.PlayerLVL - 3, 1), Math.Min(Player.PlayerLVL + 3, 10));

            monsterFleeATKChance = randATK.Next(0, 5);

            MonsterAttack = EnemyAV * monsterLVL;

            MonsterHP = monsterLVL * EnemyHP;
        }
	}
}

