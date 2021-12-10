using Domain.Data.Entities;
using Domain.Data.Repositories;
using Infrastructure.Data.Repositories.Generics;
using Migrations;

namespace Infrastructure.Data.Repositories;

public class PersonRepository : Repository<Person>, IPersonRepository
{
    public PersonRepository(DataContext context) : base(context)
    {
    }
}