using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOKata
{
    /// <summary>
    /// A class to hold the information about each book.
    /// This is only price, and the number of the book, in this case 1-5 of the harry potter series.
    /// If this exercise is extended, this could include name, author, ISBN etc.
    /// </summary>
    class Book
    {
        private float price;
        public float Price
        {
            get { return price; }
            set { price = value; }
        }

        //Book number in the harry potter series
        //1-5
        private int bookNumber;
        public int BookNumber
        {
            get { return bookNumber; }
        }
        
        public Book(int bookNum, float price)
        {
            bookNumber = bookNum;
            this.price = price;
        }
    }
}
