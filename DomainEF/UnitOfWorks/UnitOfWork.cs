using Persistence.UnitOfWorks;
using static Application.Repositories.Repositories;

namespace Persistence;
public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;

    public UnitOfWork(DataContext context)
    {
        _context = context;
    }

   // public IGenerRepository Geners =>new GenerRepository(_context);

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}

