using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheConsoleLibrary
{
    public class User : IUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime LastLogin { get; set; }
        public bool IsAuthorized { get; set; } = true;
        public List<Book> Books { get; set; } = new List<Book>();

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

        public virtual string GetFullInfo()
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

        public void TakeBook(Book book)
        {
            if (!Books.Contains(book))
            {
                Books.Add(book);
                book.Take();
                Console.WriteLine("Taken.");
            }
            else
            {
                Console.WriteLine("You have this book already. Choose another one or return it.");
            }
        }

        public void ReturnBook(Book book)
        {
            Books.Remove(book);
        }

        public void ShowBooks()
        {
            if (Books.Count == 0)
            {
                Console.WriteLine("Nothing in you personal book shelf.");
            }
            var counter = 1;
            foreach (Book book in Books)
            {
                Console.WriteLine("{0} - {1}", counter, book.GetBookInfo());
                counter++;
            }
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
