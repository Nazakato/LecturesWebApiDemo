using Demo.Dal.Authors;
using Demo.Dal.Books;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Dal.EntityFramework
{
    public class BookRepository : IBookRepository
    {
        private readonly ILibraryContext _dbContext;
        private readonly DbSet<Book> _books;

        public BookRepository(ILibraryContext dbContext)
        {
            _dbContext = dbContext;
            _books = _dbContext.Set<Book>();
        }

        public void CreateBook(Book book)
        {
            _books.Add(book);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _books.ToList();
        }

        public Book GetBook(int id)
        {
            return _books.Find(id);
        }
    }
}
