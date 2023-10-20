using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A
{
    class Borrow
    {
        public Customer Customer { get; set; }
        public Book Book { get; set; }

        public Borrow(Customer customer, Book book)
        {
            Customer = customer;
            Book = book;
            book.IsAvailable = false;
        }
    }
}
