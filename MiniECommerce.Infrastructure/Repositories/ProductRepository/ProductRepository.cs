using LinqKit;
using Microsoft.EntityFrameworkCore;
using MiniECommerce.Domain.Concrete;
using MiniECommerce.Dtos.ProductDtos;
using MiniECommerce.Infrastructure.Context;
using MiniECommerce.Infrastructure.Repositories.GenericRepository;

namespace MiniECommerce.Infrastructure.Repositories.ProductRepository;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    private ETicaretContext? context=> _context as ETicaretContext;
    public ProductRepository(ETicaretContext context) : base(context)
    {
    }

    public async Task<List<ResponseProductDto>> GetProductWithCategory(int id)
    {
        var sartP = PredicateBuilder.New<Product>();
        var sartC = PredicateBuilder.New<Category>();

        sartP.And(a => a.IsActive == true);
        sartC.And(a => a.IsActive == true);
        var query = from a in context.Categories.Where(sartC)
                    join b in context.Products.Where(sartP)
                    on a.Id equals b.CategoryId
                    select new ResponseProductDto
                    {
                        CategoryName = a.Name,
                        Description = b.Description,
                        Name = b.Name,
                        Id = b.Id,

                    };
        return await query.ToListAsync();

    }
}
