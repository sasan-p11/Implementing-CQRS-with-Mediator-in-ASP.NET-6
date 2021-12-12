using Domain.Data;
using Domain.Data.Interfaces;
using Domain.Data.Repositories;
using MediatR;

namespace Application.Photos;
public class Delete
{
    public class Command : IRequest<Result<Unit>>
    {
        public string Id { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IPhotoAccessor _photoAccessor;
        public Handler(IUnitOfWork repository, IPhotoAccessor photoAccessor)
        {
            _photoAccessor = photoAccessor;
            _repository = repository;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var result = await _photoAccessor.DeletePhoto(request.Id);

            if (result == null) return Result<Unit>.Failure("Problem deleting photo from Cloudinary");

            var success = await _repository.SaveChangesAsync() > 0;

            if (success) return Result<Unit>.Success(Unit.Value);

            return Result<Unit>.Failure("Problem deleting photo from API");
        }
    }
}