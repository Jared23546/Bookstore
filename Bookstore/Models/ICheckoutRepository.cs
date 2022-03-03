using System;
using System.Linq;

namespace Bookstore.Models
{
    public class ICheckoutRepository
    {
        IQueryable<Checkout> Checkout { get; }

        public void SaveCheckout(Checkout checkout)
        {
            
        }
    }
}
 