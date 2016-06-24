using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheConsoleLibrary
{
    public class Library
    {
        public List<Book> Shelf = new List<Book>();
        Dictionary<string, int> GenreMatrix = new Dictionary<string, int>();
        Dictionary<string, Book> GenreSummary = new Dictionary<string, Book>();
        Dictionary<Book, IUser> UserJournal = new Dictionary<Book, IUser>();
        Book Oldest;
        Book Newest;
        Book MostPopular;
        

        public Library()
        {
            CreateGenreMatrix();
            CreateGenreSummary();
            FillLibrary();
        }

        public void ReturnBook(Book book, IUser user)
        {
            UserJournal[book] = user;
            UpdateLibrary(book);
            UpdateGenreSummary(book);
            Console.WriteLine("Returned.");
        }

        public void AddBook(Book book)
        {
            Shelf.Add(book);
            UpdateGenreMatrix(book);
            UpdateGenreSummary(book);
            UpdateLibrary(book);
        }

        void UpdateLibrary(Book book)
        {
            if (Oldest == null || Oldest.PublicationYear > book.PublicationYear)
            {
                Oldest = book;
            }
            if (Newest == null || Newest.PublicationYear < book.PublicationYear)
            {
                Newest = book;
            }
            if (MostPopular == null || MostPopular.PopularityIndex <= book.PopularityIndex)
            {
                MostPopular = book;
            }
        }

        public void ShowBooks(Genre genre)
        {
            foreach (Book book in Shelf)
            {
                if (book.Genre == genre)
                {
                    Console.WriteLine(book.GetBookInfo());
                }
            }
        }

        public void ShowBooks()
        {
            foreach (Book book in Shelf)
            {
                Console.WriteLine(book.GetBookInfo());
            }
        }

        public string Summary()
        {
            var summary = "Library Summary\n\nBooks in genre:\n";
            foreach(KeyValuePair<string, int> keyValue in GenreMatrix)
            {
                summary += keyValue.Key + ": " + keyValue.Value + " books\n";
            }
            summary += "\nThe oldest book: " + Oldest.GetBookInfo() + "\nThe newest book: " + Newest.GetBookInfo() + "\nMost popular book: " + MostPopular.GetBookInfo();
            return summary;
        }

        void CreateGenreMatrix()
        {
            foreach (string genre in Enum.GetNames(typeof(Genre)))
            {
                GenreMatrix.Add(genre, 0);
            }
        }

        void UpdateGenreMatrix(Book book)
        {
            GenreMatrix[book.Genre.ToString()] += 1;
        }

        void CreateGenreSummary()
        {
            foreach (string genre in Enum.GetNames(typeof(Genre)))
            {
                GenreSummary.Add(genre, null);
            }
        }

        void UpdateGenreSummary(Book book)
        {
            if (GenreSummary[book.Genre.ToString()] == null || GenreSummary[book.Genre.ToString()].PopularityIndex <= book.PopularityIndex)
            {
                GenreSummary[book.Genre.ToString()] = book;
            }
        }

        public string ShowGenreSummary(Genre genre)
        {
            var genreSummary = "Most popular book in " + genre.ToString() + ":\n";
            if (GenreSummary[genre.ToString()] != null)
            {
                return genreSummary + GenreSummary[genre.ToString()].GetBookInfo();
            }
            return genreSummary + "not yet available";
        }

        void FillLibrary()
        {
            var bookList = new List<Book>()
            {
                new Book("Sapiens. A brief history of humankind", "Yuval Noah Harari", Genre.Nonfiction, 2014, 450, 2),
                new Book("Moab is My Washpot", "Stephen Fry", Genre.Nonfiction, 1998, 387, 3),
                new Book("C# in Depth", "Jon Skeet", Genre.Nonfiction, 2013, 245, 1),
                new Book("La promesse de l'aube", "Romain Gary", Genre.Novel, 2001, 305, 7),
                new Book("Paul Bowles", "Let in come down", Genre.Novel, 2008, 223, 4),
                new Book("Scott Piligrim", "Bryan O'Malley", Genre.GraphicNovel, 2002, 64, 2),
                new Book("Deadpool", "Fabian Nicieza", Genre.GraphicNovel, 1992, 38, 8),
                new Book("Twenty Love Poems and a Song of Despair", "Pablo Neruda", Genre.Poetry, 2001, 180, 2),
                new Book("Leaves of Grass", "Walt Whitman", Genre.Poetry, 2008, 201, 1),
                new Book("The Sonnets", "William Shakespeare", Genre.Poetry, 2003, 12),
                new Book("The Divine Comedy", "Dante Alighieri ", Genre.Poetry, 2000, 730, 8),
                new Book("The Complete Sherlock Holmes", "Arthur Conan Doyle", Genre.Crime, 1969, 567, 11),
                new Book("The Name of the Rose", "Umberto Eco", Genre.Crime, 2003, 631, 9),
                new Book("Misery", "Stephen King", Genre.Crime, 2006, 268, 4),
                new Book("The Woman in White", "Wilkie Collins", Genre.Crime, 1988, 189, 3),
                new Book("A Streetcar Named Desire", "Tennessee Williams ", Genre.Drama, 2001, 98, 2),
                new Book("Who's Afraid of Virginia Woolf? ", "Edward Albee", Genre.Drama, 1998, 78, 1),
                new Book("Dracula", "Bram Stoker", Genre.Horror, 2002, 370, 7),
                new Book("Frankenstein", "Mary Shelley", Genre.Horror, 1991, 248, 6),
                new Book("The Shining", "Stephen King", Genre.Horror, 2001, 340, 9),
                new Book("The Street of Crocodiles", "Bruno Schulz", Genre.ShortStory, 2005, 101, 3),
                new Book("I Robot", "Isaac Asimov", Genre.ShortStory, 1989, 150, 2),
                new Book("The Metamorphosis", "Franz Kafka", Genre.Novel, 2014, 354, 14),
                new Book("The Curious Case of Benjamin Button", "F. Scott Fitzgerald", Genre.ShortStory, 2000, 134, 5),
                new Book("Signs and Symbols", "Vladimir Nabokov", Genre.ShortStory, 2007, 211, 4),
                new Book("A Perfect Day for Bananafish", "J. D. Salinger", Genre.ShortStory, 2003, 123, 2),
                new Book("The Martian Chronicles", "Ray Bradbury", Genre.ScienceFiction, 1999, 341, 11),
                new Book("The Martian", "Andy Weir", Genre.ScienceFiction, 2014, 279, 5),
                new Book("Dune", "Frank Herbert", Genre.ScienceFiction, 2004, 356, 11),
                new Book("Do Androids Dream of Electric Sheep?", "Philip K. Dick", Genre.ScienceFiction, 2013, 354, 7),
                new Book("1984", "George Orwell", Genre.ScienceFiction, 2015, 440, 15),
                new Book("Ulysses", "James Joyce", Genre.Novel, 2004, 1015, 6),
                new Book("One Hundred Years of Solitude", "Gabriel Garcia Marquez", Genre.Novel, 2016, 860, 10),
                new Book("Alice's Adventures in Wonderland", "Lewis Carroll", Genre.Novel, 2010, 189, 9),
                new Book("The Catcher in the Rye", "J. D. Salinger", Genre.Novel, 2009, 382, 5),
                new Book("To the Lighthouse", "Virginia Woolf", Genre.Novel, 2009, 256, 3),
                new Book("For Whom the Bell Tolls", "Ernest Hemingway", Genre.Novel, 2003, 234, 6),
                new Book("Slaughterhouse-Five", "Kurt Vonnegut", Genre.Novel, 2015, 397, 7),
                new Book("Twenty Thousand Leagues Under the Sea", "Jules Verne", Genre.Novel, 2008, 356, 9)
            };

            foreach (Book book in bookList)
            {
                AddBook(book);
            }
        }
    }
}
