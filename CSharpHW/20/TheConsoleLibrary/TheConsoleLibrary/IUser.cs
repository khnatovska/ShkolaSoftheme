using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheConsoleLibrary
{
    public interface IUser
    {
        string Name { get; }
        string Email { get; }
        string Password { get; }
        string GetFullInfo();
        bool IsAuthorized { get; }
        void TakeBook(Book book);
        void ReturnBook(Book book);
        List<Book> Books { get; }
        void ShowBooks();
    }
}
