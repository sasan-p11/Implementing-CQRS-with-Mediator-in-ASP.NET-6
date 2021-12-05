using static Application.Repositories.Repositories;

namespace Persistence.UnitOfWorks;
public interface IUnitOfWork
{
   // IGenerRepository Geners { get; }
    Task CommitAsync();
}
