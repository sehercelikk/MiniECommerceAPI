using MiniECommerce.Domain.Abstract;

namespace MiniECommerce.Application.Services.GenericService;

public interface IGenericService<TResponse,TUpdate,TCreate>
{
    Task<List<TResponse>> GetAllAsync();
    Task<TResponse> GetAsync(TResponse entity);
    Task AddAsync(TCreate entity);
    Task UpdateAsync(TUpdate entity);
    Task DeleteAsync(int id);

}
