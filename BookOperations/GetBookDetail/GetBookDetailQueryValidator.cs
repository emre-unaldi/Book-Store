using FluentValidation;

namespace BookStore.BookOperations.GetBookDetail
{
    public class GetBookDetailQueryValidator : AbstractValidator<GetBookDetailQuery>
    {
        public GetBookDetailQueryValidator()
        {
            RuleFor(c => c.BookId).GreaterThan(0).WithMessage("Id alanının değeri 0'dan büyük olmalıdır");
        }
    }
}
