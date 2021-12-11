using Domain.Data.Interfaces;
using Domain.Data.Repositories;

namespace Domain.Data;
public interface IUnitOfWork
{
    IGenreRepository Genres { get; }
    IPersonRepository Persons { get; }
    IPhotoAccessor  PhotoAccessor { get; }
    Task CommitAsync();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}

