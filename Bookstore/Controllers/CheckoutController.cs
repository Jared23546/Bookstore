using System;
using System.Linq;
using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers
{
    public class CheckoutController : Controller
    {

        private ICheckoutRepository repo { get; set; }
        public Basket basket { get; set; }
        public CheckoutController (ICheckoutRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Checkout());
        }

        [HttpPost]
        public IActionResult Checkout(Checkout checkout)
        {
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your basket is empty");

            }
            if (ModelState.IsValid)
            {
                checkout.Lines = basket.Items.ToArray();
                repo.SaveCheckout(checkout);
                basket.ClearCart();

                return RedirectToPage("/CheckoutCompleted");
            }
            else
            {
                return View();
            }
        }
    }
}
