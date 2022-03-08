using System;
using System.Linq;

namespace Bookstore.Models
{
    public class ICheckoutRepository
    {
        public IQueryable<Checkout> Checkout { get; }

        public void SaveCheckout(Checkout checkout)
        {
            
        }
    }
}
 