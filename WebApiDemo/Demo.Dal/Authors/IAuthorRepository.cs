using System.Collections.Generic;

namespace Demo.Dal.Authors
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAllAuthors();
        Author GetAuthor(int id);
        void CreateAuthor(Author author);
    }
}