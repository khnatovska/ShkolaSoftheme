using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zodiac_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var signs = ConstructSignsDict();
            RunZodiacConsole(signs);
            Console.ReadLine();
        }

        static Dictionary<int, SignPair> ConstructSignsDict()
        {
        var signs = new Dictionary<int, SignPair> {
            { 1, new SignPair("Capricorn", "Aquarius", 19) },
            { 2, new SignPair("Aquarius", "Pisces", 18) },
            { 3, new SignPair("Pisces", "Aries", 20) },
            { 4, new SignPair("Aries", "Taurus", 19) },
            { 5, new SignPair("Taurus", "Gemini", 20) },
            { 6, new SignPair("Gemini", "Cancer", 20) },
            { 7, new SignPair("Cancer", "Leo", 22) },
            { 8, new SignPair("Leo", "Virgo", 22) },
            { 9, new SignPair("Virgo", "Libra", 22) },
            { 10, new SignPair("Libra", "Scorpio", 22) },
            { 11, new SignPair("Scorpio", "Sagittarius", 21) },
            { 12, new SignPair("Sagittarius", "Capriconr", 21) },
            };
            return signs;

        }

        static void RunZodiacConsole(Dictionary<int, SignPair> signsDict)
        {
            var birthdate = GetBirthDate();
            var age = DetermineAge(birthdate);
            Console.WriteLine("Your age is: {0}", age);
            var sign = DetermineZodiacSign(birthdate, signsDict);
            Console.WriteLine("Your zodiac sign is: {0}", sign);
        }

        static DateTime GetBirthDate()
        {
            DateTime birthdate;
            Console.WriteLine("Please enter your birthdate in format DD/MM/YYYY");
            var answer = Console.ReadLine();
            try {
                var day = int.Parse(answer.Substring(0, 2));
                var month = int.Parse(answer.Substring(3, 2));
                var year = int.Parse(answer.Substring(6, 4));
                birthdate = new DateTime(year, month, day);
            }
            catch (ArgumentException)
            {
               Console.WriteLine("Incorrect date");
               return GetBirthDate();
            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrect date format");
                return GetBirthDate();
            }
            if ((DateTime.Today.CompareTo(birthdate) < 0))
            {
                Console.WriteLine("Not an valid birthdate");
                return GetBirthDate();
            }
            return birthdate;
        }

        static int DetermineAge(DateTime birthdate)
        {
            var age = DateTime.Today.Year - birthdate.Year;
            var months = DateTime.Today.Month - birthdate.Month;
                if (months == 0)
                {
                    var days = DateTime.Today.Day - birthdate.Day;
                    if (days < 0)
                    {
                        return age -= 1;
                    }
                }
                else if (months < 0)
                {
                    return age -= 1;
                }
            
            return age;
        }

        static string DetermineZodiacSign(DateTime birthdate, Dictionary<int, SignPair> signsDict)
        {
            string zodiacSign;
            var signsPair = signsDict[birthdate.Month];
            zodiacSign = birthdate.Day <= signsPair.lastDayOfFirstSign ? signsPair.firstSign : signsPair.secondSign;
            return zodiacSign;
        }
    }
}
