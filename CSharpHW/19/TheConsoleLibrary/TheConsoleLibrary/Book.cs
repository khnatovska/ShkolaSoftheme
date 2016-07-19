using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheConsoleLibrary
{
    public class Book
    {
        public string Title { get; }
        public string Author { get; }
        public Genre Genre { get; }
        public int PublicationYear { get; }
        public int Pages { get; }
        public int PopularityIndex { get; set; }

        public Book(string title, string author, Genre genre, int year, int pages, int popularity=1)
        {
            Title = title;
            Author = author;
            Genre = genre;
            PublicationYear = year;
            Pages = pages;
            PopularityIndex = popularity;
        }

        public void Take()
        {
            PopularityIndex++;
        }

        public string GetBookInfo()
        {
            return Title + " by " + Author + ", " + Genre + ", published in " + PublicationYear + ", " + Pages + " pages, popularity: " + PopularityIndex;
        }
    }
}
