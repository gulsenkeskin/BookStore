using BookStoreWebApi.DbOperations;
namespace BookStoreWebApi.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        private readonly BookStoreDbContext _context;
        public int GenreId { get; set; }
        public DeleteGenreCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);
            if (genre is null)
                throw new InvalidOperationException("Silinecek kategori bulunamadı");
            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }

    }

}