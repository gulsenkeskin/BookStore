using AutoMapper;
using BookStoreWebApi.Application.AuthorOperations.Commands.CreateAuthor;
using BookStoreWebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using BookStoreWebApi.Application.AuthorOperations.Queries.GetAuthor;
using BookStoreWebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using BookStoreWebApi.Application.BookOperations.Queries.GetBooks;
using BookStoreWebApi.Application.GenreOperations.Commands.CreateGenre;
using BookStoreWebApi.Application.GenreOperations.Commands.UpdateGenre;
using BookStoreWebApi.Application.GenreOperations.Queries;
using BookStoreWebApi.Application.GenreOperations.Queries.GetGenreDetail;
using BookStoreWebApi.Application.GenreOperations.Queries.GetGenres;
using BookStoreWebApi.Application.UserOperations.Commands.CreateUser;
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
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));

            //buradaki dest booksviewmodel e karşılık gelir
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            //Genrenin GenresViewModele dönüştürülebileceğini söyler
            CreateMap<Genre, GenresViewModel>();

            CreateMap<Genre, GenreDetailViewModel>();

            CreateMap<Genre, UpdateGenreModel>();

            CreateMap<CreateGenreModel, Genre>();

            CreateMap<CreateAuthorModel, Author>();

            CreateMap<Author, UpdateAuthorModel>();

            CreateMap<Author, AuthorDetailViewModel>();

            CreateMap<Author, AuthorViewModel>();

            CreateMap<CreateUserCommand, User>();

        }
    }
}