using Application.Exeption;
using Domain.Data;
using Domain.Data.Entities;
using Domain.DTO.PersonDTO;
using FluentValidation;
using MediatR;

namespace Application.Persons;
public class Edit
{
    public class Command : IRequest
    {
        public EditPersonDTO Model { get; }
        public Command(EditPersonDTO model)
        {
            this.Model = model;
        }
    }

    public class Handler : IRequestHandler<Command>
    {
        private readonly IUnitOfWork _repository;
        private readonly IValidator<EditPersonDTO> _validator;

        public Handler(IUnitOfWork repository, IValidator<EditPersonDTO> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var model = request.Model;

            var result = _validator.Validate(model);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
                throw new InvalidRequestBodyException
                {
                    Errors = errors
                };
            }
            
            var entity = new Person
            {
                Id = (int)model.Id,
                Name = model.Name,
                Biography = model.Biography,
                Picture = model.Picture,
                DateOfBirth = model.DateOfBirth,
            };

            _repository.Persons.Update(entity);
            await _repository.CommitAsync();

            return Unit.Value;
        }
    }
}