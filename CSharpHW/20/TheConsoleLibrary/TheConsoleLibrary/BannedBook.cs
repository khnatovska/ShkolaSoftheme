using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheConsoleLibrary
{
    [OnlyForViewing]
    public class BannedBook : Book
    {
        public BannedBook(string title, string author, Genre genre, int year, int pages, int popularity = 1)
            :base(title, author, genre, year, pages, popularity)
        {
        }
    }
}
