using Domain.Entities;

namespace Application.Repositories;
public class Repositories
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T Get(object id);
        void Add(T entity);
        void Update(T entity);
        void Delete(object id);
        int Count();
    }

    public interface IGenerRepository : IRepository<Gener> { }
}
