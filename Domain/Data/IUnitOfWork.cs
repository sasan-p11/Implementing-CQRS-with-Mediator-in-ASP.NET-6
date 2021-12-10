using Domain.Data.Repositories;

namespace Domain.Data;
public interface IUnitOfWork
{
    IGenreRepository Genres { get; }
    IPersonRepository Persons { get; }
    Task CommitAsync();
}

