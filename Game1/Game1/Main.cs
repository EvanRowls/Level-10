using System;

namespace Game1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Shop.Open();
            Player.Create();

            Console.WriteLine();

            Battle.Start();

            Console.ReadLine();
        }
    }
}