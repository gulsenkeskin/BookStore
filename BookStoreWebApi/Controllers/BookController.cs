using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using BookStoreWebApi.DbOperations;
using AutoMapper;
using FluentValidation.Results;
using FluentValidation;
using BookStoreWebApi.Application.BookOperations.GetBooks;
using static BookStoreWebApi.Application.BookOperations.CreateBook.CreateBookCommand;
using BookStoreWebApi.Application.BookOperations.CreateBook;
using static BookStoreWebApi.Application.BookOperations.UpdateBook.UpdateBookCommand;
using BookStoreWebApi.Application.BookOperations.UpdateBook;
using BookStoreWebApi.Application.BookOperations.DeleteBook;

namespace BookStoreWebApi.AddControllers
{

    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        //readonly değişkenler sadece constructor içinde set edilebilirler
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailViewModel result;

            GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
            query.BookId = id;

            GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
            validator.ValidateAndThrow(query);

            result = query.Handle();

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
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            command.Model = newBook;

            //validator
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            ValidationResult result = validator.Validate(command);
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            // try
            // {
            UpdateBookCommand command = new UpdateBookCommand(_context);
            command.BookId = id;
            command.Model = updatedBook;

            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            //hata yakalama middleware'ı oluşturduğumuz için artık try catch e ihtiyacımız yok
            // }
            // catch (System.Exception ex)
            // {
            //     return BadRequest(ex.Message);
            // }
            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {

            DeleteBookCommand command = new DeleteBookCommand(_context);
            command.BookId = id;
            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }


    }
}

