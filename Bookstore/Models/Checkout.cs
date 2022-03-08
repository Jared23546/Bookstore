using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Bookstore.Models
{
    public class Checkout
    {
        [Key]
        [BindNever]
        public int CheckoutId { get; set; }

        [BindNever]
        public ICollection<BasketLineItem> Lines { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        [Required(ErrorMessage = "Please enter a city name")]

        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a State")]

        public string State { get; set; }
        public string Zip { get; set; }

        [Required(ErrorMessage = "Please enter a Country")]

        public string Country { get; set; }
        public string Anonymous { get; set; }

        [BindNever]
        public bool CheckoutRecieved { get; set; }
    }
}
