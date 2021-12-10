using Domain.Data;
using Domain.Data.Repositories;
using Infrastructure.Data.Repositories;
using Migrations;

namespace Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;

    public UnitOfWork(DataContext context)
    {
        _context = context;
    }
    public IGenreRepository Genres => new GenreRepository(_context);

    public IPersonRepository Persons => new PersonRepository(_context);

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}

