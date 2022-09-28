using FluentValidation;

namespace BookStoreWebApi.Application.BookOperations.CreateBook
{

    // AbstractValidator<CreateBookCommand> : bu validator sınıfı  CreateBookCommand 'ı valide eder anlamına gelir

    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            //Genre ID sıfırdan büyük olmalı
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(command => command.Model.PageCount).GreaterThan(0);
            //tarih boş olmasın ve bu günden daha küçük olsun
            RuleFor(command => command.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
            //kitabın title ı boş olmasın ve miniömum 2 karakter olsun
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(2);


        }

    }
}