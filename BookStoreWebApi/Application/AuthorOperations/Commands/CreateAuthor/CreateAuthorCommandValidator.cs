using FluentValidation;


namespace BookStoreWebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(2);
    }

}