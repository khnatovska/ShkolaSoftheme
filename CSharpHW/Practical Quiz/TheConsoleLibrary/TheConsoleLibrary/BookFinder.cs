using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheConsoleLibrary
{
    public class BookFinder
    {
        public List<Book> BooksFound = new List<Book>();
        public Library Library;
        
        public BookFinder(Library library)
        {
            Library = library;
        }

        public void Find(string input)
        {
            var target = input.Split(';');
            if (target.Length == 1)
            {
                foreach (Book book in Library.Shelf)
                {
                    if (book.Title.Contains(target[0].Trim()) || book.Author.Contains(target[0].Trim()))
                    {
                        BooksFound.Add(book);
                    }
                }
            }
            else if (target.Length == 2)
            {
                foreach (Book book in Library.Shelf)
                {
                    if (book.Title.Contains(target[0].Trim()) && book.Author.Contains(target[1].Trim()))
                    {
                        BooksFound.Add(book);
                    }
                }
            }
            
        }
        
        public void ShowBooksFound()
        {
            if (BooksFound.Count == 0)
            {
                Console.WriteLine("Nothing found.");
            }
            var counter = 1;
            foreach (Book book in BooksFound)
            {
                Console.WriteLine("{0} - {1}", counter, book.GetBookInfo());
                counter++;
            }
        }
    }
}
