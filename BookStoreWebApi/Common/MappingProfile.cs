using AutoMapper;
using static BookStoreWebApi.BookOperations.CreateBook.CreateBookCommand;

namespace BookStoreWebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();

        }
    }
}