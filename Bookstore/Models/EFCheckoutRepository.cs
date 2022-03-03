using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Models
{
    public class EFCheckoutRepository : ICheckoutRepository
    {
        public BookstoreContext context;
        public EFCheckoutRepository (BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Checkout> Checkouts => context.checkouts.Include(x => x.Lines).ThenInclude(x=>x.Book);

        public void SaveCheckout(Checkout checkout)
        {
            context.AttachRange(checkout.Lines.Select(x => x.Book));

            if (checkout.CheckoutId == 0)
            {
                context.checkouts.Add(checkout);
            }

            context.SaveChanges();
        }
    }
}
