using FluentValidation;

namespace BookStore.Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(c => c.Model.GenreId).GreaterThan(0).WithMessage("GenreId değeri 0'dan büyük bir değer olmalıdır!!!");
            RuleFor(c => c.Model.PageCount).GreaterThan(0).WithMessage("Sayfa sayısı pozitif bir değer olmalıdır.");
            RuleFor(c => c.Model.PublishDate).NotEmpty().LessThan(DateTime.Now.Date).WithMessage("Tarih geçmiş bir zaman olmalıdır!!!");
            RuleFor(c => c.Model.Title).NotEmpty().MinimumLength(4).WithMessage("Başlık en az 4 karakter olabilir!!!");
        }
    }
}
