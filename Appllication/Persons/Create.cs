using Appllication.Exeption;
using Domain.Data;
using Domain.Data.Entities;
using Domain.DTO.GenresDTO;
using FluentValidation;
using MediatR;

namespace Appllication.Persons;
public class Create
{
    public class Command : IRequest
    {
        public CreatePersonDTO Model { get; }
        public Command(CreatePersonDTO model)
        {
            this.Model = model;
        }
    }

    public class Handler : IRequestHandler<Command>
    {
        private readonly IUnitOfWork _repository;
        private readonly IValidator<CreatePersonDTO> _validator;

        public Handler(IUnitOfWork repository, IValidator<CreatePersonDTO> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            CreatePersonDTO model = request.Model;

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
                Name = model.Name,
                Biography = model.Biography,
                DateOfBirth = model.DateOfBirth,
                Picture = model.Picture,
            };

            _repository.Persons.Add(entity);
            await _repository.CommitAsync();

            return Unit.Value;
        }
    }
}