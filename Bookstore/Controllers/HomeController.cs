﻿using System;
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
        private IBookstoreRepository repo;
        public HomeController(IBookstoreRepository temp)
        {
            repo = temp;
        }

        //private BookstoreContext context { get; set; }

        //public HomeController(BookstoreContext temp)
        //{
        //    context = temp;
        //}

        public IActionResult Index(string category, int pageNum = 1)
        {
            int pageSize = 5;

            var x = new BookViewModel
            {
                Books = repo.Books
                .Where(p => p.Category == category || category == null)
                .OrderBy(p => p.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = (category == null
                                     ? repo.Books.Count()
                                     : repo.Books.Where(x=>x.Category == category).Count()),

                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }

            };
            return View(x);
        }
        
    }

}

