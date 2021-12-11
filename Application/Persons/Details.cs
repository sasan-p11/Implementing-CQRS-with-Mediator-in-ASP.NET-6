using AutoMapper;
using Domain.Data;
using Domain.DTO.PersonDTO;
using MediatR;

namespace Application.Persons;
public class Details
{
     public class Query : IRequest<PersonDTO>
    {
        public int Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, PersonDTO>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public Handler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PersonDTO> Handle(Query request, CancellationToken cancellationToken)
        {
            var entities = await Task.FromResult(_repository.Persons.Get(request.Id));
            return _mapper.Map<PersonDTO>(entities);
        }
    }
}