using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigherLowerGame
{
    class HigherLower
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            int number = rand.Next(101);
            int count = 0;

            Console.Write("Pick a number between 1-100: ");
            int guess = Convert.ToInt32(Console.ReadLine());

            while (number != guess)
            {
                if (number > guess)
                {
                    Console.Write("Higher.Try again: ");
                    count++;
                    guess = Convert.ToInt32(Console.ReadLine());
                }
                else if (number < guess)
                {
                    Console.Write("Lower.Try again: ");
                    count++;
                    guess = Convert.ToInt32(Console.ReadLine());
                }
            }
            if (number == guess)
            {
                Console.WriteLine("Correct! You guessed in your {0}. try.", count);
            }

            Console.ReadLine();
        }
    }
}
