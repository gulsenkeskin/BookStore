using BookStoreWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebApi.DbOperations
{
    public class DataGenerator
    {
        //uygulama her ayağa kalktığında çalışacak bir yapı yapmak için Service Provider ı kullanırız
        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                //uygulama ayağa kalktığında database de veri yoksa veri yazılması için

                if (context.Books.Any()) return;

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

                context.Books.AddRange(new Book
                {
                    Id = 1,
                    Title = "Posta kutusundaki Mızıka",
                    GenreId = 1,
                    PageCount = 200,
                    PublishDate = new DateTime(2001, 06, 12)
                });
                context.SaveChanges();


            }
        }
    }
}