using FluentValidation;

namespace BookStoreWebApi.Application.AuthorOperations.Commands.UpdateAuthor
{

    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {

        public UpdateAuthorCommandValidator()
        {
            //minimum length 2 olsun ama boş gelmezse 2 olsun
            RuleFor(command => command.Model.Name).MinimumLength(2).When(x => x.Model.Name.Trim() != string.Empty);

            RuleFor(command => command.Model.Surname).MinimumLength(2).When(x => x.Model.Surname.Trim() != string.Empty);

            //tarih boş olmasın ve bu günden daha küçük olsun
            RuleFor(command => command.Model.BirthDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
        }

    }
}