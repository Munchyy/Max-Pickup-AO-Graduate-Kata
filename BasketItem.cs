using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOKata
{

    /// <summary>
    /// A class to create a tuple of the book reference and the amount in the order. Acts like a dictionary however the "key" can't be read only.
    /// </summary>
    class BasketItem
    {
        private Book bookRef;
        public Book BookRef
        {
            get { return bookRef; }

        }

        private int amount;
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public BasketItem(Book bookNumber, int amount)
        {
            this.bookRef = bookNumber;
            this.amount = amount;
        }
    }
}
