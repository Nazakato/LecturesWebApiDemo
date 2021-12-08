using System.Collections.Generic;

namespace Demo.Dal.Books
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBook(int id);
    }
}
