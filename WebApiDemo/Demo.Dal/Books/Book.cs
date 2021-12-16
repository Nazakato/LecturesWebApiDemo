using Demo.Dal.Authors;
using Demo.Dal.Connections;
using System.Collections.Generic;

namespace Demo.Dal.Books
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<AuthorBook> Authors { get; set; }
    }
}
