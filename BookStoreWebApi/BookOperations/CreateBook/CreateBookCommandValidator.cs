using FluentValidation;

namespace BookStoreWebApi.BookOperations.CreateBook
{

    // AbstractValidator<CreateBookCommand> : bu validator sınıfı  CreateBookCommand 'ı valide eder anlamına gelir

    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            //Genre ID sıfırdan büyük olmalı
            RuleFor(command => command.Model.GenreId).GreaterThan(0);


        }

    }
}