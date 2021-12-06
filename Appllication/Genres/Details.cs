
using AutoMapper;
using Domain.Data;
using Domain.DTO;
using MediatR;

namespace Appllication.Genres;
public class Details
{
    public class Query : IRequest<GenreDTO>
    {
        public int Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, GenreDTO>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public Handler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GenreDTO> Handle(Query request, CancellationToken cancellationToken)
        {
            var entities = await Task.FromResult(_repository.Genres.Get(request.Id));
            return _mapper.Map<GenreDTO>(entities);
        }
    }
}

