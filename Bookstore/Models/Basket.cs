using System;
using System.Collections.Generic;
using System.Linq;

namespace Bookstore.Models
{
    public class Basket
    {
        //declares and instantiates
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();


        //add a book to a list of books
        public void AddItem(Book bok, int qty)
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


        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * 25);

            return sum;

        }

    }

    public class BasketLineItem
    {
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }

    }
}
