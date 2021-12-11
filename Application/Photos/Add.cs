using Application.Exeption;
using Domain.Data;
using Domain.Data.Entities;
using Domain.Data.Interfaces;
using Domain.Data.Repositories;
using Domain.DTO.PhotoDTO;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Photos;
public class Add
{
    public class Command : IRequest<Result<PhotoDTO>>
    {
        public IFormFile File { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<PhotoDTO>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IPhotoAccessor _photoAccessor;

        public Handler(IUnitOfWork repository, IPhotoAccessor photoAccessor)
        {
            _photoAccessor = photoAccessor;
            _repository = repository;
        }

        public async Task<Result<PhotoDTO>> Handle(Command request, CancellationToken cancellationToken)
        {
            var photoUploadResult = await _photoAccessor.AddPhoto(request.File);

            var photo = new PhotoDTO
            {
                Url = photoUploadResult.Url,
                Id = photoUploadResult.PublicId
            };

            var result = await _repository.SaveChangesAsync(cancellationToken) > 0;

            if (result) return Result<PhotoDTO>.Success(photo);

            return Result<PhotoDTO>.Failure("Problem adding photo");
        }
    }
}