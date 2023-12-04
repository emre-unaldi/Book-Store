using Microsoft.EntityFrameworkCore;

namespace BookStore.DBOperations
{
    public class BookStoreDbContext : DbContext
    {
         public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options) { }

         public DbSet<Book> Books { get; set; }
    }
}
// Genel olarak bir standart vardır.
// Entity isimleri tekil, referans olarak db içinde oluşturulacak isim çoğul olur.