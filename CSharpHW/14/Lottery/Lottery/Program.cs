using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery
{
    class Program
    {
        static Combination LotteryCombination;
        static Combination UserCombination;
        static int Left = 6;

        static void Main(string[] args)
        {
            Console.WriteLine("Let's play the Lottery! Guess the winning combination of six number from 1 to 9");
            LotteryCombination = new Combination();
            LotteryCombination.Generate();
            UserCombination = new Combination();

            while (Left > 0)
            {
                Step();
            }

            Console.WriteLine("The winning combination is: " + LotteryCombination.PrintNumbers());
            Console.WriteLine("Have you won? " + HasUserWon());

            Console.ReadLine();
        }

        static void Step()
        {
            var userNumber = AskNumber();
            if (userNumber == -1)
            {
                Console.WriteLine("Number must be between 1 and 9");
                return;
            }
            else
            {
                UserCombination.AddNumber(userNumber);
                Left--;
                Console.WriteLine("Your combination is: " + UserCombination.PrintNumbers());
            }
        }

        static int AskNumber()
        {
            Console.WriteLine("{0} numbers left. Please enter the next number", Left);
            var input = Console.ReadLine();
            if (Validate(input))
            {
                return int.Parse(input);
            }
            else
            {
                return -1;
            }
        }

        static bool Validate(string input)
        {
            int parsed;
            if (!(int.TryParse(input, out parsed)))
                return false;
            else if ((parsed < 1) || (parsed > 9))
                return false;
            else
                return true;
        }

        static bool HasUserWon()
        {
            return UserCombination.Equals(LotteryCombination);
        }
    }
}
