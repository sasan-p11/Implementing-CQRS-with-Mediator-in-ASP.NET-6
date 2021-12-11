using Domain.DTO.GenresDTO;
using FluentValidation;

namespace Application.Validators;
public class GenreDTOValidator : AbstractValidator<GenreDTO>
{
    public class CreateGenreDTOValidator : AbstractValidator<CreateGenreDTO>
    {
        public CreateGenreDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        }
    }
    public class EditGenreDTOValidator : AbstractValidator<EditGenreDTO>
    {
        public EditGenreDTOValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        }
    }
}