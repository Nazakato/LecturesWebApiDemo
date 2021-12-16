using Demo.Dal.Authors;
using Demo.Dal.Books;
using Demo.Dal.Connections;
using Microsoft.EntityFrameworkCore;

namespace Demo.Dal.EntityFramework
{
    public class LibraryContext : DbContext, ILibraryContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<AuthorBook> AuthorBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AuthorBook>()
                .HasKey(bc => new { bc.BookId, bc.AuthorId });
            modelBuilder.Entity<AuthorBook>()
                .HasOne(ab => ab.Book)
                .WithMany(b => b.Authors)
                .HasForeignKey(ab => ab.BookId);
            modelBuilder.Entity<AuthorBook>()
                .HasOne(ab => ab.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(ab => ab.AuthorId);
        }
    }
}
