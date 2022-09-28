using AutoMapper;
using BookStoreWebApi.Application.BookOperations.Queries.GetBooks;
using BookStoreWebApi.Application.GenreOperations.Commands.CreateGenre;
using BookStoreWebApi.Application.GenreOperations.Queries;
using BookStoreWebApi.Application.GenreOperations.Queries.GetGenreDetail;
using BookStoreWebApi.Application.GenreOperations.Queries.GetGenres;
using BookStoreWebApi.Entities;
using static BookStoreWebApzi.Application.BookOperations.Commands.CreateBook.CreateBookCommand;

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
            //Genrenin GenresViewModele dönüştürülebileceğini söyler
            CreateMap<Genre, GenresViewModel>();

            CreateMap<Genre, GenreDetailViewModel>();

            CreateMap<Genre, CreateGenreModel>();

        }
    }
}