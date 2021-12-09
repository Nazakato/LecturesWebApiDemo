using Demo.Dal.Authors;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Dal.InMemory
{
    public class AuthorRepository : IAuthorRepository
    {
        public void CreateAuthor(Author author)
        {
            if (DB.Authors.Exists(a => a.Id == author.Id || a.Name == author.Name)) throw new ArgumentException();

            DB.Authors.Add(author);
        }

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
