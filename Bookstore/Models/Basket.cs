using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Bookstore.Models
{
    public class Basket
    {
        //declares and instantiates
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();


        //add a book to a list of books
        public virtual void AddItem(Book bok, int qty)
        {
            BasketLineItem line = Items
                .Where(b => b.Book.BookID == bok.BookID)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = bok,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public virtual void RemoveItem (Book bok)
        {
            Items.RemoveAll(x => x.Book.BookID == bok.BookID);
        }

        public virtual void ClearCart ()
        {
            Items.Clear();
        }

        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);

            return sum;

        }

    }

    public class BasketLineItem
    {
        [Key]
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }

    }
}
