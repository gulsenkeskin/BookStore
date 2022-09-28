using BookStoreWebApi.DbOperations;

namespace BookStoreWebApi.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        private readonly BookStoreDbContext _context;
        public UpdateGenreModel Model { get; set; }
        public int GenreId { get; set; }

        public UpdateGenreCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);

            if (genre is null)
                throw new InvalidOperationException("Güncellenecek kategori bulunamadı");

            genre.Name = Model.Name != default ? Model.Name : genre.Name;

            _context.SaveChanges();
        }

    }

    public class UpdateGenreModel
    {
        public string Name { get; set; }
    }
}