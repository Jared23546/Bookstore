using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Infrastructure;
using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookstore.Pages
{
    public class CartModel : PageModel
    {
        //private instance of repository
        private IBookstoreRepository repo { get; set;  }

        //constructor
        public CartModel (IBookstoreRepository temp)
        {
            repo = temp;
        }

        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //if there is already basket data in the session then it will pull that but if there is not then it will create a new basket
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
        }

        //on post we will recieve the book id from the summary.cshtml
        public IActionResult OnPost(int bookid, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookID == bookid);

            //initialize
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
            //add item
            basket.AddItem(b, 1);

            HttpContext.Session.SetJson("basket", basket);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
