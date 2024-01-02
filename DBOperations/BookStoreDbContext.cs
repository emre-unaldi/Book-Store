using BookStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DBOperations
{
    public class BookStoreDbContext : DbContext, IBookStoreDbContext
    {
         public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options) { }

         public DbSet<Book> Books { get; set; }
         public DbSet<Genre> Genres { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
// Genel olarak bir standart vardır.
// Entity isimleri tekil, referans olarak db içinde oluşturulacak isim çoğul olur.