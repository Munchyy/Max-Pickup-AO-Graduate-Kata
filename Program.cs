using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOKata
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Basket shoppingBasket;

            List<string> basketContents;
            List<int> basketContentsInts;

            Console.WriteLine("What is the contents of your basket? (x,x,..,x)");
            string userInput = Console.ReadLine();
            
            basketContents = userInput.Split(',').ToList();
            foreach (string item in basketContents)
            {
                //if typed incorrectly or if a comma is added then an item may be null
                if (item == null)
                {
                    basketContents.Remove(item);
                }
            }

            //wont actually be empty if parse works
            basketContentsInts = new List<int>();

            //attempt to parse the list of strings into integers, if the user enters a letter by mistake, it will throw an exception.
            try
            {
                basketContentsInts = basketContents.Select(int.Parse).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                System.Environment.Exit(1);
            }
    
            shoppingBasket = new Basket(basketContentsInts);


            //calculate the cost of basket by applying the discount
            float price = shoppingBasket.FindTotal();

            //output the price as a 2 decimal point number
            Console.WriteLine("\nThe total cost is: " + price.ToString("n2")+" EUR");


            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

    }
}
