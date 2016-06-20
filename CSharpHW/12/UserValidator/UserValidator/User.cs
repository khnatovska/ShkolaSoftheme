using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserValidator
{
    public class User : IUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime LastLogin { get; set; }

        public User(string login, string password, bool nameGiven)
        {
            if (nameGiven == true)
            {
                Name = login;
            }
            else
            {
                Email = login;
            }
            Password = password;
            LastLogin = DateTime.Now;
        }

        public string GetFullInfo()
        {
            return "Name: " + Name + ", Email: " + Email + ", Password: " + Password + ", Last login: " + LastLogin;
        }

        public void SetLastLogin(DateTime loginTime)
        {
            LastLogin = loginTime;
        }

        public string GetLastLogin()
        {
            return LastLogin.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            User userObj = obj as User;
            if ((object)userObj == null)
            {
                return false;
            }
            return (Name == userObj.Name) && (Email == userObj.Email) && (Password == userObj.Password);
        }

        public bool Equals(User anotherUser)
        {
            if ((object)anotherUser == null)
            {
                return false;
            }
            return (Name == anotherUser.Name) && (Email == anotherUser.Email) && (Password == anotherUser.Password);
        }
    }
}
