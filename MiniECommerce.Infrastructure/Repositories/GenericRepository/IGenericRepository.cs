using MiniECommerce.Domain.Abstract;
using System.Linq.Expressions;

namespace MiniECommerce.Infrastructure.Repositories.GenericRepository;

public interface IGenericRepository<T> where T: class, IEntity, new()
{
    Task<List<T>> GetAllAsync(Expression<Func<T,bool>> predicate=null,params Expression<Func<T, object>>[] expressions);
    Task<T> GetAsync(Expression<Func<T,bool>> predicate=null, params Expression<Func<T, object>>[] expressions);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
