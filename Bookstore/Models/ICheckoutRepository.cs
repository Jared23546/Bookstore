using System;
using System.Linq;

namespace Bookstore.Models
{
    public interface ICheckoutRepository
    {
        public IQueryable<Checkout> Checkout { get; }

        void SaveCheckout(Checkout checkout);
        
            
        
    }
}
 