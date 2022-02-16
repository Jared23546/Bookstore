using System;
using System.Linq;

namespace Bookstore.Models.ViewModels
{
    public class BookViewModel
    {
        public IQueryable<Book> Books { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
