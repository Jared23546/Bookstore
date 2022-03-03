using System;
using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore1.Components
{
    public class CartViewComponent : ViewComponent
    {
        private Basket basket;

        public CartViewComponent(Basket c)
        {
            basket = c;
        }

        public IViewComponentResult Invoke()
        {
            return View(basket);
        }
    }
}