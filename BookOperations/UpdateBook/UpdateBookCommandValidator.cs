using FluentValidation;

namespace BookStore.BookOperations.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(c => c.BookId).GreaterThan(0).WithMessage("Id alanının değeri 0'dan büyük olmalıdır!!!");
            RuleFor(c => c.Model.Title).NotEmpty().MinimumLength(4).WithMessage("Başlık en az 4 karakter olabilir!!!");
            RuleFor(c => c.Model.GenreId).GreaterThan(0).WithMessage("GenreId değeri 0'dan büyük bir değer olmalıdır!!!");
            RuleFor(c => c.Model.PageCount).GreaterThan(0).WithMessage("Sayfa sayısı pozitif bir değer olmalıdır.");
        }
    }
}
