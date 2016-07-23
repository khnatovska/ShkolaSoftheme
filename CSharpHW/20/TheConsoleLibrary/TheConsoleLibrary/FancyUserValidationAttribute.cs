using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TheConsoleLibrary
{
    public class FancyUserValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var Users = new List<User>()
            {
                new User("theuser", "123asdQ", true),
                new User("thereader", "123asdQ", true),
            };

            var user = value as User;
            if (user.NameGiven)
            {
                if (string.IsNullOrWhiteSpace(user.Name))
                {
                    ErrorMessage = "Login is empty";
                    return false;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(user.Email))
                {
                    ErrorMessage = "Login is empty";
                    return false;
                }
            }
            
            foreach (var registeredUser in Users)
            {
                if (user.CompareLogin(registeredUser))
                {
                    if (user.ComparePassword(registeredUser))
                    {
                        user.SetLastLogin(registeredUser.LastLogin);
                        return true;
                    }
                    else
                    {
                        ErrorMessage = "Incorrect password";
                        return false;
                    }
                }
            }
            ErrorMessage = "User with this login not found";
            return false;
        }
    }
}
