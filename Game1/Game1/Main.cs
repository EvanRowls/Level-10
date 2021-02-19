using System;

namespace Game1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Player.Create();

            Console.WriteLine();

            Battle.Start();

            Console.ReadLine();
        }
    }
}