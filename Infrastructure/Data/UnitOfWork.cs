using Domain.Data;
using Domain.Data.Interfaces;
using Domain.Data.Repositories;
using Infrastructure.Data.Photos;
using Infrastructure.Data.Repositories;
using Microsoft.Extensions.Options;
using Migrations;

namespace Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;
    private readonly IOptions<CloudinarySettings> config;

    public UnitOfWork(DataContext context, IOptions<CloudinarySettings> config)
    {
        _context = context;
        this.config = config;
    }
    public IGenreRepository Genres => new GenreRepository(_context);

    public IPersonRepository Persons => new PersonRepository(_context);

    public IPhotoAccessor PhotoAccessor => new PhotoAccessor(config);

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
     
          bool IsCompleted = _context.SaveChangesAsync().IsCompletedSuccessfully;
          return IsCompleted ? 1 : 0;

    }
}

