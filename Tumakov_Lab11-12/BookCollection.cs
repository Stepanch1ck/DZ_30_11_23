using System;
using System.Collections.Generic;

namespace Tumakov_Lab11_12
{

    internal class BookCollection
    {
        private List<Book> books;
        public BookCollection(List<Book> books)
        {
            this.books = books;
        }
        public void Add(Book book)
        {
            books.Add(book);
        }

        public void SortBooks(Comparison<Book> comparison)
        {
            books.Sort(comparison);
        }
        public void Print()
        {
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }
    }
}
