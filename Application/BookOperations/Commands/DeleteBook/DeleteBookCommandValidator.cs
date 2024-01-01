using FluentValidation;

namespace BookStore.Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(c => c.BookId).GreaterThan(0).WithMessage("Id değeri 0'dan büyük bir değer olmalıdır!!!");
        }
    }
}
