using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstore.Models
{
    public class BookOrder
    {
        public Book Book{ get; set; }
        public int Quantity { get; set; }
    }
}
