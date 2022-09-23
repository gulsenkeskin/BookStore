using BookStoreWebApi.DbOperations;

namespace BookStoreWebApi.BookOperations.UpdateBook
{

    public class UpdateBookCommand
    {
        private readonly BookStoreDbContext _context;

        public UpdateBookModel Model { get; set; }
        public int BookId { get; set; }

        public UpdateBookCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == BookId);

            if (book is null)
                throw new InvalidOperationException("Güncellenecek Kitap Bulunamadı");

            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;

            book.Title = Model.Title != default ? Model.Title : book.Title;

        }

        public class UpdateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
        }


    }


}