using System;
using Microsoft.AspNetCore.Mvc;
using Bookstore.Models;
using System.Linq;

namespace Bookstore.Components
{
    public class TypesViewComponent : ViewComponent
    {
        //see end of vid 5
        private IBookstoreRepository repo { get; set; }

        public TypesViewComponent(IBookstoreRepository temp)
        {
            repo = temp;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }
    }
}
