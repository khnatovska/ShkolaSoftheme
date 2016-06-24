using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheConsoleLibrary
{
    public class Validator : IValidator
    {
        List<IUser> Users = new List<IUser>();

        public Validator()
        {
            Users = new List<IUser>()
            {
                new User("theuser", "123asdQ", true),
                new User("thereader", "123asdQ", true)
            };
        }

        public bool ValidateUser(IUser user)
        {
            foreach (User existingUser in Users)
            {
                if (existingUser.Equals(user))
                {
                    Console.WriteLine("Last time logged in: {0}", existingUser.GetLastLogin());
                    existingUser.SetLastLogin(DateTime.Now);
                    return true;
                }
            }
            return false;
        }

        public void AddUser(IUser user)
        {
            Users.Add(user);
            Console.WriteLine("New user created.");
        }

        public void PrintUsers()
        {
            Console.WriteLine("Available users");
            foreach (User user in Users)
            {
                Console.WriteLine(user.GetFullInfo());
            }
        }
    }
}
