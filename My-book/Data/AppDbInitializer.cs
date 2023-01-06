using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using My_book.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_book.Data.Models
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

            if (!context.Book.Any())
            {
                //var book1 = new My_book();
                //book1.Author = "First Author";
                //book1.Title = "1st Book Title";
                //book1.Description = "1st Book Desc";
                //book1.IsRead = true;
                //book1.Genre = "Biography";
                //book1.DateRead = DateTime.Now.AddDays(-10);
                //book1.DateAdded = DateTime.Now;
                //book1.CoverUrl = "https...";
                //book1.Rate = 4;

                //context.My_Books.Add(book1);

                context.Book.AddRange(
                    new Book()
                    {
                        Title = "1st Book Title",
                        Description = "1st Book Description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Biography",
                        Author = "First Author",
                        ////CoverUrl = "https....",
                        DateAdded = DateTime.Now

                    },
                    new Book()
                    {
                        Title = "2nd Book Title",
                        Description = "2nd Book Description",
                        IsRead = false,
                        Genre = "Biography",
                        Author = "First Author",
                        //CoverUrl = "https....",
                        DateAdded = DateTime.Now

                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
