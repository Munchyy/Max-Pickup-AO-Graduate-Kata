using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOKata
{

    /// <summary>
    /// This Class hold all the information about the order and hold references to each book possible in a list.
    /// 
    /// After creating an instance and filling the basket contents with the order, the main thread calls FindTotal.
    /// 
    /// This calls FindSetPrice once, then calls it iteratively until all the order has been calculated.
    /// 
    /// FindSetPrice will find the largest set of books i.e. 1,2,3,4,5 not 1,1,1; and get the price according to each book. It then passes the set count and price to ApplyDiscounts.
    /// 
    /// ApplyDiscounts will take match the set number with a switch, and apply the discount to the set price, it will return the price with the applied discount.
    /// </summary>
    class Basket
    {
        //holds count of each book that is in the basket
        List<BasketItem> basketContents;

        //a list of the books available
        List<Book> inventory;

        public Basket(List<int> newBasketContents)
        {
            //populate inventory of store (references of available books with prices)
            InitialiseInventory();

            //populate basket (list BasketItems of available books with amounts of 0)
            InitialiseBasketContents();            

            //update the basket items with the amounts of each item
            foreach (int item in newBasketContents)
            {
                switch (item)
                {
                    case 1:
                        basketContents[0].Amount++;
                        break;
                    case 2:
                        basketContents[1].Amount++;
                        break;
                    case 3:
                        basketContents[2].Amount++;
                        break;
                    case 4:
                        basketContents[3].Amount++;
                        break;
                    case 5:
                        basketContents[4].Amount++;
                        break;
                }
            }

            //test
            Console.WriteLine("Your Order: ");
            foreach (BasketItem bItem in basketContents)
            {
                Console.WriteLine("Book Number: " + bItem.BookRef.BookNumber + ", Amount: " + bItem.Amount);
            }
        }
        

        /// <summary>
        /// Iterates over FindSetPrice, could have been done using (tail) recursion easily, however in this case it would have made little difference and stack frames would have complicated any issues.
        /// </summary>
        /// <returns>a float, the final total of the order</returns>
        public float FindTotal()
        {
            float total = 0f;
            float runningTotal = 0f;
            
            //put a copy of the basket contents into tempContents to edit it while keeping the origial intact
            List<BasketItem> tempContents = basketContents;

            //Find a the first set price and then iterate to find the total of the basket
            runningTotal = FindSetPrice(tempContents);
            total += runningTotal;
            while (runningTotal != 0f)
            {
                runningTotal = FindSetPrice(tempContents);
                total += runningTotal;
            }

            return total;
        }

        /// <summary>
        /// finds the biggest possible set i.e. 1,2,3,4,5 not 1,1,1; calculates the price of the set and calls ApplyDiscount
        /// </summary>
        /// <param name="tempContents">a copy of the basket contents that is ok to be edited</param>
        /// <returns>a float, the final discounted price of the set found </returns>
        private float FindSetPrice(List<BasketItem> tempContents)
        {
            //marks how many books are in the current set, e.g. will return 5 for a full set, 0 if there are no books left
            int setCount = 0;

            //the price of the set according to the book values (constant 8EUR but calculated for extensibility)
            float setPrice = 0f;

            //iterate over dictionary to find a the most complete set and remove it from dictionary
            foreach (BasketItem entry in basketContents)
            {
                if (entry.Amount > 0)
                {
                    setCount++;
                    entry.Amount--;

                    setPrice += entry.BookRef.Price;

                }
            }

            //if ther basket is empty, return 0, else 
            if (setCount == 0)
            {
                return 0f;
            }
            else
            {
                float discountSetPrice = ApplyDiscounts(setCount, setPrice);
                return discountSetPrice;
            }
            
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="setCount">the amount of items in the set that is being discounted</param>
        /// <param name="setPrice">the full price of the set that is being discounted</param>
        /// <returns>the discounted price of the set that was given</returns>
        private float ApplyDiscounts(int setCount, float setPrice)
        {
            float discountPrice = 0f;

            //find the appropriate discount for the set, if the number is bigger than 5 (there are 7 books!) then set largest discount possible
            switch (setCount)
            {
                case 1:
                    discountPrice = setPrice;
                    break;
                case 2:
                    discountPrice = setPrice * 0.95f;
                    break;
                case 3:
                    discountPrice = setPrice * 0.9f;
                    break;
                case 4:
                    discountPrice = setPrice * 0.8f;
                    break;
                case 5:
                    discountPrice = setPrice * 0.75f;
                    break;
                default:
                    discountPrice = setPrice * 0.75f;
                    break;
            }


            return discountPrice;
        }

        /// <summary>
        /// Populates the inventory of books. This is where new books would be added, or prices changed.
        /// </summary>
        private void InitialiseInventory()
        {
            inventory = new List<Book>();
            inventory.Add(new Book(1, 8f));
            inventory.Add(new Book(2, 8f));
            inventory.Add(new Book(3, 8f));
            inventory.Add(new Book(4, 8f));
            inventory.Add(new Book(5, 8f));
        }

        /// <summary>
        /// Populates a skeleton of the basket. As there are only 5 possible books they are all added, however could be changed to add them as each book is found in the order (e.g. order 1,1,2,3,4 would not have 5 in the basket
        /// </summary>
        private void InitialiseBasketContents()
        {
            basketContents = new List<BasketItem>();
            basketContents.Add(new BasketItem(inventory[0], 0));
            basketContents.Add(new BasketItem(inventory[1], 0));
            basketContents.Add(new BasketItem(inventory[2], 0));
            basketContents.Add(new BasketItem(inventory[3], 0));
            basketContents.Add(new BasketItem(inventory[4], 0));
        }
    }
}
