using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstore.Models
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public BookGenre Genre { get; set; }
        public decimal UnitPrice{ get; set; }
    }

    public enum BookGenre
    {
        Crime = 0,
        Romance = 1,
        Fantasy = 2
    }
}
