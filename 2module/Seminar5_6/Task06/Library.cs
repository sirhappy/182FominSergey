using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06
{
    class Library
    {
        public static Random rnd = new Random();

        public int NumberOfSections { get; set; }
        List<Book> books;
 
        public Library() { books = new List<Book>(); }
        public Library(List<Book> books)
        {
            this.books = books;
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public int BooksCount
        {
            get { return books.Count; }
        }

        public int CountBooksWithTheLessAmountOfPages(int n)
        {
            int ans = 0;
            foreach (Book i in books)
            {
                if (i.CountPages < n) ++ans;
            }
            return ans;
        }
    }
}
