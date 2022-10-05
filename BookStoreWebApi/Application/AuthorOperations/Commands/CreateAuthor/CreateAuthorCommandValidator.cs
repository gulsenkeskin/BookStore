using FluentValidation;


namespace BookStoreWebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(command => command.Model!.Name).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model!.Surname).NotEmpty().MinimumLength(2);
            //tarih boş olmasın ve bu günden daha küçük olsun
            RuleFor(command => command.Model!.BirthDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }

}