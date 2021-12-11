using Domain.DTO.GenresDTO;
using Domain.DTO.PersonDTO;
using FluentValidation;

namespace Application.Validators;
public class PersonDTOValidator : AbstractValidator<PersonDTO>
{
    public class CreatePersonDTOValidator : AbstractValidator<CreatePersonDTO>
    {
        public CreatePersonDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Biography).NotEmpty().WithMessage("Biography is required");
            RuleFor(x => x.DateOfBirth).NotEmpty().WithMessage("DateOfBirth is required");
            RuleFor(x => x.Picture).NotEmpty().WithMessage("Picture is required");
        }
    }
    public class EditPersonDTOValidator : AbstractValidator<EditPersonDTO>
    {
        public EditPersonDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Biography).NotEmpty().WithMessage("Biography is required");
            RuleFor(x => x.DateOfBirth).NotEmpty().WithMessage("DateOfBirth is required");
            RuleFor(x => x.Picture).NotEmpty().WithMessage("Picture is required");
        }
    }
}
