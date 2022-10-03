using AutoMapper;
using BookStoreWebApi.DbOperations;

namespace BookStoreWebApi.Application.AuthorOperations.Queries.GetAuthor
{
    public class GetAuthorQuery
    {
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;
        public GetAuthorQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<AuthorViewModel> Handle()
        {
            var author = _context.Authors.OrderBy(x => x.Id);
            List<AuthorViewModel> returnObj = _mapper.Map<List<AuthorViewModel>>(author);
            return returnObj;
        }


    }

    public class AuthorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }

}