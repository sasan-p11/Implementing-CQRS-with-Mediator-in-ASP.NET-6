
using Application.Exeption;
using Domain.Data;
using Domain.Data.Entities;
using Domain.DTO.GenresDTO;
using FluentValidation;
using MediatR;

namespace Application.Genres;
public class Create
{
    public class Command : IRequest
    { 
        public CreateGenreDTO Model { get; }
        public Command(CreateGenreDTO model)
        {
            this.Model = model;
        }
    }

    public class Handler : IRequestHandler<Command>
    {
        private readonly IUnitOfWork _repository;
        private readonly IValidator<CreateGenreDTO> _validator;

        public Handler(IUnitOfWork repository, IValidator<CreateGenreDTO> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            CreateGenreDTO model = request.Model;

            var result = _validator.Validate(model);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
                throw new InvalidRequestBodyException
                {
                    Errors = errors
                };
            }

            var entity = new Genre
            {
                Name = model.Name,
            };

            _repository.Genres.Add(entity);
            await _repository.CommitAsync();

            return Unit.Value;
        }
    }
}
