using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using BookStoreWebApi.DbOperations;
using BookStoreWebApi.BookOperations.GetBooks;
using BookStoreWebApi.BookOperations.CreateBook;
using static BookStoreWebApi.BookOperations.CreateBook.CreateBookCommand;

namespace BookStoreWebApi.AddControllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        //readonly değişkenler sadece constructor içinde set edilebilirler
        private readonly BookStoreDbContext _context;

        public BookController(BookStoreDbContext context)
        {
            _context = context;
        }



        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailViewModel result;

            try
            {
                GetBookDetailQuery query = new GetBookDetailQuery(_context);
                query.BookId = id;
                result = query.Handle();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(result);
        }

        // [HttpGet]
        // public Book? Get([FromQuery] string id)
        // {
        //     var book = BookList.Where(book => book.Id == Convert.ToInt32(id)).SingleOrDefault();
        //     return book;
        // }


        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context);
            try
            {

                command.Model = newBook;
                command.Handle();

                return Ok();
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]

        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
            if (book is not null)
            {
                return BadRequest();
            }
            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();
        }


    }
}

