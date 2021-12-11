using AutoMapper;
using Domain.Data;
using Domain.DTO.PersonDTO;
using MediatR;

namespace Application.Persons;
public class List
{
    public class Query : IRequest<List<PersonDTO>>
    {
    }

    public class Handler : IRequestHandler<Query, List<PersonDTO>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public Handler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<PersonDTO>> Handle(Query request, CancellationToken cancellationToken)
        {
            var entities = await Task.FromResult(_repository.Persons.GetAll());
            return _mapper.Map<List<PersonDTO>>(entities);
        }
    }
}
