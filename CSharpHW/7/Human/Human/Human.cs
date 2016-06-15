using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human
{
    public class Human
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; }
        public readonly int Age;

        public Human(string firstname, string lastname)
            : this(firstname, lastname, new DateTime(1971, 1, 1))
        { }

        public Human()
            : this("Victor", "Frankenstein")
        { }

        public Human(string firstname, string lastname, DateTime birthdate)
        {
            FirstName = firstname;
            LastName = lastname;
            BirthDate = birthdate;
            Age = DetermineAge(birthdate);
        }

        public bool CompareHuman(Human anotherhuman)
        {
            if ((FirstName == anotherhuman.GetFirstName()) && (LastName == anotherhuman.GetLastName())
                && (BirthDate == anotherhuman.GetBirthDate()))
            {
                return true;
            }
            else
                return false;
        }

        private int DetermineAge(DateTime birthdate)
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

        public string GetFirstName()
        {
            return FirstName;
        }

        public string GetLastName()
        {
            return LastName;
        }

        public DateTime GetBirthDate()
        {
            return BirthDate;
        }

        public int GetAge()
        {
            return Age;
        }

        public string WhoAmI()
        {
            return FirstName + " " + LastName + ", " + Age;
        }
    }
}
