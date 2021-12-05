using Domain.Data.Entities;
using Domain.Data.Repositories;
using Infrastructure.Data.Repositories.Generics;
using Migrations;

namespace Infrastructure.Data.Repositories;
public class GenreRepository : Repository<Genre>, IGenreRepository
{
    public GenreRepository(DataContext context) : base(context)
    {
    }
}

