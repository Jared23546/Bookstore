using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Models;
using Bookstore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
//using Bookstore.Models;

namespace Bookstore.Controllers
{
    public class HomeController : Controller
    {
        private BookstoreContext context { get; set; }

        public HomeController(BookstoreContext temp)
        {
            context = temp;
        }

        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 5;

            var x = new BookViewModel
            {
                Books = context.Books
                .OrderBy(p => p.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = context.Books.Count(),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }

            };
            return View(x);
        }
        
    }

}

