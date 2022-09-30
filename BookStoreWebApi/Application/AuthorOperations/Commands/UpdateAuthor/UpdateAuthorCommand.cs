using BookStoreWebApi.DbOperations;

namespace BookStoreWebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        private readonly BookStoreDbContext _contex;
        public UpdateAuthorModel Model { get; set; }
        public int AuthorId { get; set; }

        public UpdateAuthorCommand(BookStoreDbContext context)
        {
            _contex = context;
        }

        public void Handle()
        {
            var author = _contex.Authors.SingleOrDefault(x => x.Id == AuthorId);

            if (author is null)
            {
                throw new InvalidOperationException("Yazar bulunamadı");
            }

            if (_contex.Authors.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Surname.ToLower() == Model.Surname.ToLower() && x.BirthDate == Model.BirthDate && x.Id != AuthorId))
                throw new InvalidOperationException("Yazar sisteme kayıtlı");

            author.Name = string.IsNullOrEmpty(Model.Name.Trim()) ? author.Name : Model.Name;
            author.Surname = string.IsNullOrEmpty(Model.Surname.Trim()) ? author.Surname : Model.Surname;

            author.BirthDate = Model.BirthDate;

            _contex.SaveChanges();
        }
    }

    public class UpdateAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }

    }

}