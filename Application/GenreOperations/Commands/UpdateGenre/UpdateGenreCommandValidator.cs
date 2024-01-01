using FluentValidation;

namespace BookStore.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(genre => genre.Model.Name).MinimumLength(4).When(genre => genre.Model.Name.Trim() != string.Empty);
        }
    }
}
