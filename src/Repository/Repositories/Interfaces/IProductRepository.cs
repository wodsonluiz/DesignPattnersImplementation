using System.Collections.Generic;
using System.Threading.Tasks;
using Repository.Entities;

namespace Repository.Repositories.Interaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsMoreExpensiveThan(decimal price);

        Task<Product?> GetByNameAsync(string name);
    }
}