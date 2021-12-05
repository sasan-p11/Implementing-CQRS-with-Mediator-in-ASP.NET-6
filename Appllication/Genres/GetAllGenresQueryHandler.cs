using AutoMapper;
using Domain.Data;
using Domain.DTO;
using MediatR;

namespace Appllication.Genres
{
    public class GetAllGenresQuery : IRequest<IEnumerable<GenreDTO>>
    {
    }

    public class GetAllGenresQueryHandler : IRequestHandler<GetAllGenresQuery, IEnumerable<GenreDTO>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetAllGenresQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GenreDTO>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
        {
            var entities = await Task.FromResult(_repository.Genres.GetAll());
            return _mapper.Map<IEnumerable<GenreDTO>>(entities);
        }
    }
}
