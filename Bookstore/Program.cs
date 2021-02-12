using System;
using System.Collections.Generic;
using System.Linq;
using Bookstore.Models;

namespace Bookstore
{
    class Program
    {
        static void Main(string[] args)
        {
            //set any discounts
            var discounts = new Dictionary<BookGenre, decimal>();
            discounts.Add(BookGenre.Crime, 0.05m);

            var repository = new BookRespository();

            var order = new List<BookOrder>
            {
                new BookOrder
                {
                    Book = repository.GetByTitle("Unsolved murders"),
                    Quantity = 1
                },
                new BookOrder
                {
                    Book = repository.GetByTitle("A Little Love Story"),
                    Quantity = 1
                },
                new BookOrder
                {
                    Book = repository.GetByTitle("Heresy"),
                    Quantity = 1
                },
                new BookOrder
                {
                    Book = repository.GetByTitle("Jack the Ripper"),
                    Quantity = 1
                },
                new BookOrder
                {
                    Book = repository.GetByTitle("The Tolkien Years"),
                    Quantity = 1
                }
            };

            var gstExcluded = CalculateTotal(order, discounts);

            //10% GST on total price (after delivery fee)
            var gstIncluded = RoundNearestCent(gstExcluded * 1.1m);

            Console.Out.WriteLine($"Ex-GST:\t\t{gstExcluded:c}");
            Console.Out.WriteLine($"Inc-GST:\t{gstIncluded:c}");
            Console.Out.WriteLine("Press any key to exit");
            Console.Read();
        }

        /// <summary>
        /// Take an order, apply any discounts and produce an ex-GST cost
        /// </summary>
        /// <param name="order"></param>
        /// <param name="discounts"></param>
        /// <returns></returns>
        private static decimal CalculateTotal(IEnumerable<BookOrder> order, Dictionary<BookGenre, decimal> discounts)
        {
            //validate the order
            if (order.Count() == 0)
            {
                throw new ArgumentException(nameof(order), "The order is empty");
            }
            if (order.Any(x => x.Quantity <= 0))
            {
                throw new ArgumentException(nameof(order), "All quantities must be greater than 0");
            }

            var total = 0m;
            foreach (var item in order)
            {
                decimal cost = item.Book.UnitPrice;

                //apply discount if it exists for the genre
                if (discounts.ContainsKey(item.Book.Genre))
                {
                    cost = RoundNearestCent(cost * (1m - discounts[item.Book.Genre]));
                }

                total = cost * item.Quantity;
            }

            //$5.95 delivery fee for orders less than $20
            if (total < 20m)
            {
                total += 5.95m;
            }
            return total;
        }

        /// <summary>
        /// Round a number to the nearest cent for currency purposes
        /// </summary>
        /// <param name="num">The number to round</param>
        /// <returns><The rounded number/returns>
        private static decimal RoundNearestCent(decimal num)
        {
            return Math.Round(num * 100) / 100;
        }
    }
}