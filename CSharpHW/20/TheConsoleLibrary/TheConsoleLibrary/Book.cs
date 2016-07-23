using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TheConsoleLibrary
{
    public class Book : IValidatableObject
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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.Title))
                errors.Add(new ValidationResult("No title"));

            if (string.IsNullOrWhiteSpace(this.Author))
                errors.Add(new ValidationResult("No author"));
            
            if (this.Genre <= 0 || this.Genre > (Genre)9)
                errors.Add(new ValidationResult("Incorrect genre"));

            if (this.PublicationYear <= 0 || this.PublicationYear > DateTime.Today.Year)
                errors.Add(new ValidationResult("Incorrect publication year"));

            if (this.Pages <= 0)
                errors.Add(new ValidationResult("Incorrect number of pages"));

            return errors;
        }
    }
}
