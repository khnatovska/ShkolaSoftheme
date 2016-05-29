using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculate here");
            RunCalculator();
        }

        static void RunCalculator()
        {
            var firstOperand = GetOperand();
            var selectedOperator = GetOperator();
            var secondOperand = GetOperand();
            CalculateResult(firstOperand, selectedOperator, secondOperand);
            AskForAnotherRound();
        }

        static void AskForAnotherRound()
        {
            Console.WriteLine("Another round? (y/n)");
            var answer = Console.ReadLine();
            if (answer.ToLower() == "y")
                RunCalculator();
            else
                return;
        }

        static double GetOperand()
        {
            double parsedInput;
            Console.WriteLine("Enter a double:");
            var userInput = Console.ReadLine();
            if (double.TryParse(userInput, out parsedInput))
            {
                return parsedInput;
            }
            else
            {
                Console.WriteLine("Incorrect format. Only double are accepted");
                return GetOperand();
            }
                
        }

        static string GetOperator()
        {
            Console.WriteLine("Select operation: \n 1 - addition; \n 2 - subtraction; \n 3 - multiplication; \n 4 - division");
            var userInput = Console.ReadLine();
            if (userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4")
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Incorrect selection.");
                return GetOperator();
            }
        }

        static void CalculateResult(double firstOperand, string selectedOperator, double secondOperand)
        {
            double result = 0;
            string displayedOperator = "";
            switch (selectedOperator)
            {
                case "1":
                    result = firstOperand + secondOperand;
                    displayedOperator = "plus";
                    break;
                case "2":
                    result = firstOperand - secondOperand;
                    displayedOperator = "minus";
                    break;
                case "3":
                    result = firstOperand * secondOperand;
                    displayedOperator = "times";
                    break;
                case "4":
                    if (secondOperand == 0)
                        {
                            Console.WriteLine("Division by zero is not allowed");
                            return;
                        }
                    else
                    {
                        result = firstOperand / secondOperand;
                        displayedOperator = "divided by";
                        break;
                    }    
                    
                    
            }
            Console.WriteLine("{0} {1} {2} is {3}", firstOperand, displayedOperator, secondOperand, Math.Round(result, 2));
        }
    }
}
