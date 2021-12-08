using Demo.Dal.Authors;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Dal.InMemory
{
    public class AuthorRepository : IAuthorRepository
    {
        public IEnumerable<Author> GetAllAuthors()
        {
            return DB.Authors;
        }

        public Author GetAuthor(int id)
        {
            return DB.Authors.FirstOrDefault(x => x.Id == id);
        }
    }
}
