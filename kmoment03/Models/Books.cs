

using System.ComponentModel.DataAnnotations;

namespace BooksDirectory.Models {


    public class Author_data { 
        public int Id {get; set;}

        [StringLength(50)]
        [Display(Name = "Namn")]
        public required string Name {get; set;}

        [StringLength(200)]
        [Display(Name = "Om")]
        public required string About {get; set;}

        public List<Book> Books {get; set;} = new();
    }
    public class Book {
        public int Id {get; set;}

        [StringLength(50)]
        [Display(Name = "Titel")]
        public required  string Title {get; set;}

        [StringLength(400)]
        [Display(Name = "Beskrivning")]
        public required  string Description {get; set;}

        [Display(Name = "Författare")]
        public int AuthorId {get; set;}
        [Display(Name = "Författare")]
        public required Author_data Author {get; set;}
    }

    public class Customer {
        public int Id {get; set;}

        [StringLength(50)]

        [Display(Name = "Namn")]
        public required  string Name { get; set;}

        public required  string Email {get; set;}

        [Display(Name = "Födelsedag")]
        public DateTime Birthday {get; set;}
    }

    public class Loan {
        public int Id {get; set;}

        [Display(Name = "Bok titel")]
        public int BookId {get; set;}

        [Display(Name = "Bok")]
        public required Book Book {get; set;}

        [Display(Name = "Kund")]
        public int CustomerId {get; set;}

        [Display(Name = "Kund")]
        public required Customer Customer {get; set;}

        [Display(Name = "Lånedatum")]
        public required  DateTime LoanDate {get; set;}
        
        [Display(Name = "Status")]
        public bool IsLoaned {get; set;}

    }
}