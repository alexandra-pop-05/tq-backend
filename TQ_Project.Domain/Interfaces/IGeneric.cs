
using System.Linq.Expressions;

namespace TQ_Project.Domain.Interfaces
{
    public interface IGeneric<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T>? GetById(int id);
        Task<List<T>> Add(T entity);
        Task<List<T>>? UpdateById(int id, T requested);
        Task<List<T>>? Delete(int id);
        Task SaveChangesAsync();
        Task<T> FindFirstAsync(Expression<Func<T, bool>> predicate);
    }
}
