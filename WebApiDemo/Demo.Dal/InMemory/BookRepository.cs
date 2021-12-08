using Demo.Dal.Books;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Dal.InMemory
{
    public class BookRepository : IBookRepository
    {
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