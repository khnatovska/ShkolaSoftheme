using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheConsoleLibrary
{
    class Program
    {
        static Library library = new Library();
        static Validator validator = new Validator();
        static IUser CurrentUser { get; set; }
        
        static void Main(string[] args)
        {
       
            CurrentUser = AuthenticateUser();

            Console.WriteLine(CurrentUser.GetFullInfo());

            while (true)
            {
                GetCommand();
            }

            Console.ReadLine();
        }

        static IUser AuthenticateUser()
        {
            Console.WriteLine("Do you want to log in? (yes/no)");
            string loginInput = Console.ReadLine();
            ExitWanted(loginInput);
            if (loginInput == "yes")
            {
                string nameOrEmail;
                string password;
                bool nameGiven = true;
                Console.WriteLine("Enter name or email");
                string nameOrEmailInput = Console.ReadLine();
                ExitWanted(nameOrEmailInput);
                if (nameOrEmailInput.Contains("@"))
                {
                    nameGiven = false;
                }
                nameOrEmail = nameOrEmailInput;
                Console.WriteLine("Enter password");
                string passwordInput = Console.ReadLine();
                ExitWanted(passwordInput);
                password = passwordInput;
                var user = new User(nameOrEmail, password, nameGiven);
                if (validator.ValidateUser(user))
                {
                    return user;
                }
                else
                {
                    Console.WriteLine("Incorrect login or password.");
                    return AuthenticateUser();
                }
            }
            else if (loginInput == "no")
            {
                return new AnonimousUser();
            }
            else {
                Console.WriteLine("Invalid input.");
                return AuthenticateUser();
            }
        }

        static void GetCommand()
        {
            Console.WriteLine("Commands: Summary, MostPopularBook, FindBook, TakeBook, ReturnBook, AddBook.");
            var input = Console.ReadLine();
            ExitWanted(input);
            switch (input)
            {
                case "Summary":
                    Console.WriteLine(library.Summary());
                    break;
                case "MostPopularBook":
                    MostPopularWanted();
                    break;
                case "FindBook":
                    FindBookWanted();
                    break;
                case "TakeBook":
                    if (CurrentUser.IsAuthorized)
                    {
                        TakeBookWanted();
                    }
                    else
                    {
                        Console.WriteLine("Only logged in users can take books.");
                    }
                    break;
                case "ReturnBook":
                    if (CurrentUser.IsAuthorized)
                    {
                        ReturnBookWanted();
                    }
                    else
                    {
                        Console.WriteLine("Only logged in users can return books.");
                    }
                    break;
                case "AddBook":
                    if (CurrentUser.IsAuthorized)
                    {
                        AddBookWanted();
                    }
                    else
                    {
                        Console.WriteLine("Only logged in users can add books.");
                    }
                    break;
                default:
                    Console.WriteLine("Command not recognized.");
                    GetCommand();
                    break;
            }
        }

        static void MostPopularWanted()
        {
            Console.WriteLine("Please select genre:\n1 - Drama, 2 - Crime, 3 - Novel, 4 - GraphicNovel, 5 - Nonfiction, 6 - ScienceFiction, 7 - ShortStory, 8 - Horror, 9 - Poetry. Enter \"back\" to return.");
            var input = Console.ReadLine();
            ExitWanted(input);
            switch (input)
            {
                case "1":
                    Console.WriteLine(library.ShowGenreSummary(Genre.Drama));
                    break;
                case "2":
                    Console.WriteLine(library.ShowGenreSummary(Genre.Crime));
                    break;
                case "3":
                    Console.WriteLine(library.ShowGenreSummary(Genre.Novel));
                    break;
                case "4":
                    Console.WriteLine(library.ShowGenreSummary(Genre.GraphicNovel));
                    break;
                case "5":
                    Console.WriteLine(library.ShowGenreSummary(Genre.Nonfiction));
                    break;
                case "6":
                    Console.WriteLine(library.ShowGenreSummary(Genre.ScienceFiction));
                    break;
                case "7":
                    Console.WriteLine(library.ShowGenreSummary(Genre.ShortStory));
                    break;
                case "8":
                    Console.WriteLine(library.ShowGenreSummary(Genre.Horror));
                    break;
                case "9":
                    Console.WriteLine(library.ShowGenreSummary(Genre.Poetry));
                    break;
                case "back":
                    return;
                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }
        }

        static BookFinder FindBookWanted()
        {
            var finder = new BookFinder(library);
            Console.WriteLine("Find your book. Enter book title or author, or both separated by semicolon (;)");
            var input = Console.ReadLine();
            ExitWanted(input);
            finder.Find(input);
            finder.ShowBooksFound();
            return finder;
        }

        static void TakeBookWanted()
        {
            var finder = FindBookWanted();
            if (finder.BooksFound.Count == 0)
            {
                return;
            }
            else
            {
                var index = ConvertStringToBookIndex(finder.BooksFound.Count);
                CurrentUser.TakeBook(finder.BooksFound[index]);
            }
        }

        static void ReturnBookWanted()
        {
            CurrentUser.ShowBooks();
            var index = ConvertStringToBookIndex(CurrentUser.Books.Count);
            var book = CurrentUser.Books[index];
            library.ReturnBook(book, CurrentUser);
            CurrentUser.ReturnBook(book);
        }

        static void AddBookWanted()
        {
            var newBook = ConstructBook();
            library.AddBook(newBook);
        }

        static void ExitWanted(string input)
        {
            if (input == "exit")
                Environment.Exit(0);
        }

        static Book ConstructBook()
        {
            Console.WriteLine("Enter book title");
            var title = Console.ReadLine();
            Console.WriteLine("Enter book author");
            var author = Console.ReadLine();
            var genre = ConvertStringToGenre();
            var year = ConvertStringToYear();
            var pages = ConvertStringToPages();
            var book = new Book(title, author, genre, year, pages);
            Console.WriteLine("New book: {0}", book.GetBookInfo());
            return book;
        }

        static Genre ConvertStringToGenre()
        {
            Console.WriteLine("Please select genre:\n1 - Drama, 2 - Crime, 3 - Novel, 4 - GraphicNovel, 5 - Nonfiction, 6 - ScienceFiction, 7 - ShortStory, 8 - Horror, 9 - Poetry");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    return Genre.Drama;
                case "2":
                    return Genre.Crime;
                case "3":
                    return Genre.Novel;
                case "4":
                    return Genre.GraphicNovel;
                case "5":
                    return Genre.Nonfiction;
                case "6":
                    return Genre.ScienceFiction;
                case "7":
                    return Genre.ShortStory;
                case "8":
                    return Genre.Horror;
                case "9":
                    return Genre.Poetry;
                default:
                    Console.WriteLine("Invalid input.");
                    return ConvertStringToGenre();
            }
        }

        static int ConvertStringToYear()
        {
            Console.WriteLine("Enter publication year");
            var input = Console.ReadLine();
            int parsed;
            if (int.TryParse(input, out parsed))
            {
                if (parsed <= DateTime.Today.Year && parsed > 0)
                {
                    return parsed;
                }
                else
                {
                    Console.WriteLine("Invalid year.");
                    return ConvertStringToYear();
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
                return ConvertStringToYear();
            }
        }

        static int ConvertStringToPages()
        {
            Console.WriteLine("Enter number of pages");
            var input = Console.ReadLine();
            int parsed;
            if (int.TryParse(input, out parsed))
            {
                if (parsed > 0)
                {
                    return parsed;
                }
                else
                {
                    Console.WriteLine("Invalid number of pages.");
                    return ConvertStringToPages();
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
                return ConvertStringToPages();
            }
        }

        static int ConvertStringToBookIndex(int maxIndex)
        {
            Console.WriteLine("Please select book from the list");
            var input = Console.ReadLine();
            int parsed;
            if (int.TryParse(input, out parsed))
            {
                if (parsed <= maxIndex && parsed > 0)
                {
                    return parsed-1;
                }
                else
                {
                    Console.WriteLine("Invalid book index.");
                    return ConvertStringToBookIndex(maxIndex);
                }
            }
            else
            {   
                Console.WriteLine("Invalid input.");
                return ConvertStringToBookIndex(maxIndex);
            }
        }
    }
}
