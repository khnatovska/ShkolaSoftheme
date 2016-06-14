using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresToConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n Printing a triangle \n");
            var triangleSize = ValidateSize();
            PrintTriangle(triangleSize);
            Console.WriteLine("\n Printing a square \n");
            var squareSize = ValidateSize();
            PrintSquare(squareSize);
            Console.WriteLine("\n Printing a romb \n");
            var rombSize = ValidateSize();
            PrintRomb(rombSize);
            Console.ReadLine();
        }

        static int ValidateSize()
        {
            Console.WriteLine("Please specify what size should be your figure: \n 1 - small \n 2 - medium \n 3 - large");
            int size = 3;
            var userSize = Console.ReadLine();
            switch (userSize)
            {
                case "1":
                    break;
                case "2":
                    size = 9;
                    break;
                case "3":
                    size = 13;
                    break;
                default:
                    Console.WriteLine("Incorrect size value.");
                    return ValidateSize();
            }
            return size;
        }

        static void PrintTriangle(int size)
        {
            var star = "* ";
            var starsInRow = 1;
            for (var i = 0; i < size; i++)
            {
                var line = string.Empty;
                for (var j = 0; j < starsInRow; j++)
                {
                    line += star;
                }
                Console.WriteLine(line);
                starsInRow += 1;
            }
        }

        static void PrintSquare(int size)
        {
            var star = "* ";
            var line = string.Empty;
            for (var i = 0; i < size; i++)
            {
                line += star;
            }
            for (var j = 0; j < size; j++)
            {
                Console.WriteLine(line);
            }
        }

        static void PrintRomb(int size)
        {
            var star = "* ";
            var blank = "  ";
            var starsInRow = 1;
            var blanksInRow = (size - 1) / 2;
            for (var i = 0; i <= (size/2); i++)
            {
                var line = FormRombLine(blank, blanksInRow, star, starsInRow);
                Console.WriteLine(line);
                starsInRow += 2;
                blanksInRow -= 1;
            }
            starsInRow -= 2;
            blanksInRow += 1;
            for (var i = 0; i < (size / 2); i++)
            {
                starsInRow -= 2;
                blanksInRow += 1;
                var line = FormRombLine(blank, blanksInRow, star, starsInRow);
                Console.WriteLine(line);
                
            }
        }

        private static string FormRombLine(string blank, int blanksCount, string star, int starsCount)
        {
            var line = string.Concat(Enumerable.Repeat(blank, blanksCount)) + string.Concat(Enumerable.Repeat(star, starsCount));
            return line;    
        }
    }
}
