using System.Collections.Generic;
using Demo.Dal.Books;

namespace Demo.Dal.Authors
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
