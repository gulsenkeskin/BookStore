using AutoMapper;
using BookStoreWebApi.BookOperations.GetBooks;
using static BookStoreWebApi.BookOperations.CreateBook.CreateBookCommand;

namespace BookStoreWebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            //Genrenin nasıl oluşturulacağını özel olaraak söyledim
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));

        }
    }
}