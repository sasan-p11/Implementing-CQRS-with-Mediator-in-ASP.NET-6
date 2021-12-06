using Domain.DTO;
using FluentValidation;

namespace Appllication.Validators;
public class CreateGenreDTOValidator : AbstractValidator<CreateGenreDTO>
{
    public CreateGenreDTOValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
    }
}

