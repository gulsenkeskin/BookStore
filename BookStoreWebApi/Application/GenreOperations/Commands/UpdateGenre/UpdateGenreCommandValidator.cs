using FluentValidation;

namespace BookStoreWebApi.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(command => command.GenreId).GreaterThan(0);

            //minimum length 2 olsun ama boş gelmezse 2 olsun
            RuleFor(command => command.Model.Name).MinimumLength(2).When(x => x.Model.Name.Trim() != string.Empty);
        }
    }

}