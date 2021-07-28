using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadsTailsGame
{
    class HeadsTails
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            bool isHeads = false;
            bool isOver = false;

            while (!isOver)
            {
                int number = rand.Next(2);
                switch (number)
                {
                    case 0:
                        isHeads = true;
                        break;
                    case 1:
                        isHeads = false;
                        break;
                }

                Console.WriteLine("Heads or tails? (write h or t)");
                string answer = Console.ReadLine().ToLower();

                if (answer == "h" && isHeads == true)
                {
                    Console.WriteLine("You guessed CORRECT!");
                    isOver = true;
                }
                else if (answer == "t" && isHeads == false)
                {
                    Console.WriteLine("You guessed CORRECT!");
                    isOver = true;
                }
                else
                {
                    Console.WriteLine("Sorry! You guessed WRONG!");
                    Console.WriteLine("Answer was {0}. Press ENTER to play again.", isHeads ? "Heads" : "Tails");
                    isOver = false;
                    answer = Console.ReadLine().ToLower();
                }
            }
            Console.ReadLine();
        }
    }
}
