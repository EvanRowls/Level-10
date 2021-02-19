namespace Game1
{
    public class Level
    {
        public static void Check()
        {

            if (Player.PlayerEXP < 300)
            {
                Player.PlayerLVL = 1;
            }
            else if (Player.PlayerEXP >= 300 && Player.PlayerEXP < 600)
            {
                Player.PlayerLVL = 2;
            }
            else if (Player.PlayerEXP >= 600 && Player.PlayerEXP < 1100)
            {
                Player.PlayerLVL = 3;
            }
            else if (Player.PlayerEXP >= 1100 && Player.PlayerEXP < 1700)
            {
                Player.PlayerLVL = 4;
            }
            else if (Player.PlayerEXP >= 1700 && Player.PlayerEXP < 2300)
            {
                Player.PlayerLVL = 5;
            }
            else if (Player.PlayerEXP >= 2300 && Player.PlayerEXP < 4200)
            {
                Player.PlayerLVL = 6;
            }
            else if (Player.PlayerEXP >= 4200 && Player.PlayerEXP < 6000)
            {
                Player.PlayerLVL = 7;
            }
            else if (Player.PlayerEXP >= 6000 && Player.PlayerEXP < 7350)
            {
                Player.PlayerLVL = 8;
            }
            else if (Player.PlayerEXP >= 7350 && Player.PlayerEXP < 9930)
            {
                Player.PlayerLVL = 9;
            }
            else if (Player.PlayerEXP >= 9930)
            {
                Player.PlayerLVL = 10;
            }

            Player.PlayerMaxHealth = Player.PlayerHP + (Player.PlayerHP * (Player.PlayerLVL - 1) / 4);
            Player.PlayerAttack = Player.PlayerLVL * Player.PlayerAV;
        }

    }
}