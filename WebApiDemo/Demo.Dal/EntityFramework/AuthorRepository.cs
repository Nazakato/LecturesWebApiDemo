using Demo.Dal.Authors;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Dal.EntityFramework
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ILibraryContext _dbContext;
        private readonly DbSet<Author> _authors;

        public AuthorRepository(ILibraryContext dbContext)
        {
            _dbContext = dbContext;
            _authors = _dbContext.Set<Author>();
        }

        public void CreateAuthor(Author author)
        {
            _authors.Add(author);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _authors.ToList();
        }

        public Author GetAuthor(int id)
        {
            return _authors.Find(id);
        }
    }
}
