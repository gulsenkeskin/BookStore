using AutoMapper;
using BookStoreWebApi.DbOperations;
using BookStoreWebApi.Entities;

namespace BookStoreWebApzi.Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateBookCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }

        public void Handle()
        {

            var book = _dbContext.Books.SingleOrDefault(x => x.Title == Model.Title);

            if (book is not null)
            {
                throw new InvalidOperationException("Bu Kitap Sisteme Kayıtlı");
            }

            //Model deki veriyi Book objesine convert eder
            book = _mapper.Map<Book>(Model); //new Book();
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();

        }


        //bir kitap kaydetmek istediğimizde dışardan ne almamız gerekiyorsa onu yazarız
        public class CreateBookModel
        {
            public string? Title { get; set; }
            public int GenreId { get; set; }
            public int AuthorId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }



    }
}