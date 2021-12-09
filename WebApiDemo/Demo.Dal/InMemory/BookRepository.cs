using Demo.Dal.Books;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Dal.InMemory
{
    public class BookRepository : IBookRepository
    {
        public void CreateBook(Book book)
        {
            if (DB.Books.Exists(b => b.Id == book.Id || b.Name == book.Name)) throw new ArgumentException();

            DB.Books.Add(book);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return DB.Books;
        }

        public Book GetBook(int id)
        {
            return DB.Books.FirstOrDefault(x => x.Id == id);
        }
    }
}