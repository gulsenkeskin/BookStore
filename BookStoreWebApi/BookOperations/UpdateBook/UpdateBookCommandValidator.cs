using FluentValidation;

namespace BookStoreWebApi.BookOperations.UpdateBook
{
    //abstract validator'un içine doğrulamak istediğimiz class ı yazarız
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(2);
        }
    }
}