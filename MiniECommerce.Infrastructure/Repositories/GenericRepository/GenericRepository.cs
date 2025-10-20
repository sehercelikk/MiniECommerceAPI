using Microsoft.EntityFrameworkCore;
using MiniECommerce.Domain.Abstract;
using System.Linq.Expressions;

namespace MiniECommerce.Infrastructure.Repositories.GenericRepository;

public class GenericRepository<T> : IGenericRepository<T> where T: class, IEntity, new()
{
    private readonly DbContext _context;

    public GenericRepository(DbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate=null, params Expression<Func<T, object>>[] expressions)
    {
        IQueryable<T> query = _context.Set<T>();
        if(predicate is not null)
        {
            query = query.Where(predicate);
        }
        if(expressions is not null && expressions.Length > 0)
        {
            foreach(var expression in expressions)
            {
                query = query.Include(expression);
            }
        }
        return await query.AsNoTracking().ToListAsync();
    }


    public async Task<T> GetAsync(Expression<Func<T, bool>> predicate=null, params Expression<Func<T, object>>[] expressions)
    {
        IQueryable<T> query= _context.Set<T>();
        if(predicate is not null)
        {
            query = query.Where(predicate);
        }
        if(expressions is not null && expressions.Length > 0)
        {
            foreach(var expression in  expressions)
            {
                query = query.Include(expression);
            }
        }
        return await query.AsNoTracking().FirstOrDefaultAsync();
    }


    public async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }
}
