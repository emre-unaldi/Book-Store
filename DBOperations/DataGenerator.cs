using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                 if(context.Books.Any())
                 {
                    return;
                 }

                context.Books.AddRange(
                   new Book
                   {
                       Title = "Harry Potter 1",
                       GenreId = 0,
                       PageCount = 200,
                       PublishDate = new DateTime(2001, 01, 02)
                   },
                   new Book
                   {
                       Title = "Harry Potter 2",
                       GenreId = 1,
                       PageCount = 300,
                       PublishDate = new DateTime(2002, 01, 02)
                   },
                   new Book
                   {
                       Title = "Harry Potter 3",
                       GenreId = 1,
                       PageCount = 400,
                       PublishDate = new DateTime(2003, 01, 02)
                   }
                );

                context.SaveChanges();
            }
        }
    }
}
