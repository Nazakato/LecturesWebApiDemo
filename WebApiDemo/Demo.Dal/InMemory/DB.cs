using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.Dal.Authors;
using Demo.Dal.Books;

namespace Demo.Dal.InMemory
{
    internal static class DB
    {
        internal static List<Author> Authors;
        internal static List<Book> Books;

        static DB()
        {
            Init();
        }

        internal static void Init()
        {
            Authors = new List<Author>
            {
                new Author { Id = 1, Name = "Jeffrey Richter" },
                new Author { Id = 2, Name = "Christopher Paolini" }
            };

            Books = new List<Book>
            {
                new Book { Id = 1, Name = "CLR via C#" },
                new Book { Id = 2, Name = "Eragon" }
            };

            Authors[0].Books = new List<Book> { Books[0] };
            Books[0].Authors = new List<Author> { Authors[0] };
            Authors[1].Books = new List<Book> { Books[1] };
            Books[1].Authors = new List<Author> { Authors[1] };
        }
    }
}
