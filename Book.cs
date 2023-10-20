using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A
{
    class Book
    {
        private static int isbn = 0;

        public string Title { get; set; }
        public string Author { get; set; }
        public int ISBN { get; set; }
        public bool IsAvailable { get; set; }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
            this.ISBN = ++isbn;
            IsAvailable = true;
        }
    }
}
