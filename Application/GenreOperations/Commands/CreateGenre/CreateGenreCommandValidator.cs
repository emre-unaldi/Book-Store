using FluentValidation;

namespace BookStore.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(genre => genre.Model.Name).NotEmpty().MinimumLength(4);
        }
    }
}
