using FluentValidation;

namespace BookStoreWebApi.Application.GenreOperations.Queries.GetGenreDetail
{
    //fluent validator ı kullanabilmek için abstract validatordan kalıtım almak gerekir içerisine valide etmek istediğimiz class ı yazarız
    public class GetGenreDetailQueryValidator : AbstractValidator<GetGenreDetailQuery>
    {
        public GetGenreDetailQueryValidator()
        {
            RuleFor(query => query.GenreId).GreaterThan(0);
        }
    }
}