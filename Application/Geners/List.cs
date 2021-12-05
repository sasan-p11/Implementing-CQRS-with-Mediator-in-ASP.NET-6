using MediatR;
using Persistence.UnitOfWorks;
using AutoMapper;
using Domain.DTO;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Geners;
public class List
{
    public class GetAllGenersQuery : IRequest<IEnumerable<GenerDTO>>
    {
    }

    public class GetAllGenersQueryHandler : IRequestHandler<GetAllGenersQuery, IEnumerable<GenerDTO>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetAllGenersQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GenerDTO>> Handle( GetAllGenersQuery request, CancellationToken cancellationToken)
        {
            var entities = await Task.FromResult(_repository.Geners.GetAll());
            return _mapper.Map<IEnumerable<GenerDTO>>(entities);
        }
    }
}
