using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bookstore.Models;

namespace Bookstore
{
    //Simple in-memory Book repository
    public class BookRespository
    {
        public List<Book> Books { get; private set; }

        public BookRespository()
        {
            Books = new List<Book> {
                new Book
                {
                    Title = "Unsolved murders",
                    Author = "Emily G. Thompson, Amber Hunt",
                    Genre = BookGenre.Crime,
                    UnitPrice = 10.99m
                },
                new Book
                {
                    Title = "Alice in Wonderland",
                    Author = "Lewis Carroll",
                    Genre = BookGenre.Fantasy,
                    UnitPrice = 5.99m
                },
                new Book
                {
                    Title = "A Little Love Story",
                    Author = "Roland Merullo",
                    Genre = BookGenre.Romance,
                    UnitPrice = 2.40m
                },
                new Book
                {
                    Title = "Heresy",
                    Author = "S J Parris",
                    Genre = BookGenre.Fantasy,
                    UnitPrice = 6.80m
                },
                new Book
                {
                    Title = "The Neverending Story",
                    Author = "Michael Ende",
                    Genre = BookGenre.Fantasy,
                    UnitPrice = 7.99m
                },
                new Book
                {
                    Title = "Jack the Ripper",
                    Author = "Philip Sugden",
                    Genre = BookGenre.Crime,
                    UnitPrice = 16.00m
                },
                new Book
                {
                    Title = "The Tolkien Years",
                    Author = "Greg Hildebrandt",
                    Genre = BookGenre.Fantasy,
                    UnitPrice = 22.90m
                }
            };
        }

        /// <summary>
        /// Get a book based on its title. Throws an execption if it cannot be found
        /// </summary>
        /// <param name="title">The book title. Case is important</param>
        /// <returns>The correct book</returns>
        public Book GetByTitle(string title)
        {
            return Books.First(x => x.Title == title);
        }
    }
}
