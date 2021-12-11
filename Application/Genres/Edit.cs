using Application.Exeption;
using Domain.Data;
using Domain.Data.Entities;
using Domain.DTO.GenresDTO;
using FluentValidation;
using MediatR;

namespace Application.Genres;
public class Edit
{
    public class Command : IRequest
    {
        public EditGenreDTO Model { get; }
        public Command(EditGenreDTO model)
        {
            this.Model = model;
        }
    }

    public class Handler : IRequestHandler<Command>
    {
        private readonly IUnitOfWork _repository;
        private readonly IValidator<EditGenreDTO> _validator;

        public Handler(IUnitOfWork repository, IValidator<EditGenreDTO> validator)
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
            
            var entity = new Genre
            {
                Id = (int)model.Id,
                Name = model.Name,
            };

            _repository.Genres.Update(entity);
            await _repository.CommitAsync();

            return Unit.Value;
        }
    }
}