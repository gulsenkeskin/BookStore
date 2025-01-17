using AutoMapper;
using BookStoreWebApi.DbOperations;

namespace BookStoreWebApi.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
        public int AuthorId { get; set; }
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;
        public GetAuthorDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public AuthorDetailViewModel Handle()
        {
            var author = _context.Authors.SingleOrDefault(
                x => x.Id == AuthorId
            );
            if (author is null)
                throw new InvalidOperationException("Yazar Bulunamadı");
            return _mapper.Map<AuthorDetailViewModel>(author);
        }




    }

    public class AuthorDetailViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }

}