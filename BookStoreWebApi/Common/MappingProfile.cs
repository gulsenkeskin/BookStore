using AutoMapper;
using BookStoreWebApi.Application.BookOperations.GetBooks;
using BookStoreWebApi.Entities;
using static BookStoreWebApi.Application.BookOperations.CreateBook.CreateBookCommand;


namespace BookStoreWebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            //Genrenin nasıl oluşturulacağını özel olaraak söyledim
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));

            //buradaki dest booksviewmodel e karşılık gelir
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));

        }
    }
}