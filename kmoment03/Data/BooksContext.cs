using BooksDirectory.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksDirectory.Data {
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options) : base(options) {


        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author_data> Authors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Loan> Loans { get; set; }
    }
}