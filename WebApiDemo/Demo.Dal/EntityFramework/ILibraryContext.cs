using Microsoft.EntityFrameworkCore;

namespace Demo.Dal.EntityFramework
{
    public interface ILibraryContext
    {
        int SaveChanges();
        DbSet<T> Set<T>() where T: class;
    }
}