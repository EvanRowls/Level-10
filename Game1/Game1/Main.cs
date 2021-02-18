using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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