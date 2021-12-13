using Domain.Data;
using MediatR;

namespace Application.Persons;
public class Delete
{
    public class Command : IRequest
    {
        public Guid Id { get; set; }
        public Command(Guid id)
        {
            this.Id = id;
        }
    }

    public class Handler : IRequestHandler<Command>
    {
        private readonly IUnitOfWork _repository;

        public Handler(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {

            _repository.Persons.Delete(request.Id);
            await _repository.CommitAsync();

            return Unit.Value;
        }
    }
}
