using BookStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Genres.Any())
                {
                    return;
                }
                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Personal Growth"
                    },
                    new Genre
                    {
                        Name = "Science Fiction"
                    },
                    new Genre
                    {
                        Name = "Romance"
                    }
                 );


                if (context.Books.Any())
                {
                    return;
                }
                context.Books.AddRange(
                   new Book
                   {
                       Title = "Harry Potter 1",
                       GenreId = 1,
                       PageCount = 200,
                       PublishDate = new DateTime(2001, 01, 02)
                   },
                   new Book
                   {
                       Title = "Harry Potter 2",
                       GenreId = 2,
                       PageCount = 300,
                       PublishDate = new DateTime(2002, 01, 02)
                   },
                   new Book
                   {
                       Title = "Harry Potter 3",
                       GenreId = 3,
                       PageCount = 400,
                       PublishDate = new DateTime(2003, 01, 02)
                   }
                );

                context.SaveChanges();
            }
        }
    }
}
