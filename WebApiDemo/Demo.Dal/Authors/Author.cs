using System.Collections.Generic;
using Demo.Dal.Books;
using Demo.Dal.Connections;

namespace Demo.Dal.Authors
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<AuthorBook> Books { get; set; }
    }
}
