using System;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Models
{
    public class BookstoreContext : DbContext
    {
        public BookstoreContext()
        {
        }

        public BookstoreContext(DbContextOptions<BookstoreContext> options)
            : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Checkout> checkouts { get; set; }
    }
}
