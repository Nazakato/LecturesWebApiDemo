using Demo.Dal.Authors;
using Demo.Dal.Books;

namespace Demo.Dal.Connections
{
    public class AuthorBook
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
