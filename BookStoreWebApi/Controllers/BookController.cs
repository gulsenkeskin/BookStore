using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebApi.AddControllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private static List<Book> BookList = new List<Book>(){
            new Book{
                Id=1,
                Title="Learn Startup",
                GenreId=1,
                PageCount=200,
                PublishDate=new DateTime(2001,06,12)
            },
               new Book{
                Id=2,
                Title="Herland",
                GenreId=2,
                PageCount=250,
                PublishDate=new DateTime(2001,06,12)
            }


    };
    }
}

