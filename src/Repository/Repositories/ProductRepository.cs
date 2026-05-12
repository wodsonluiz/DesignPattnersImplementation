using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Entities;
using Repository.Repositories.Interaces;

namespace Repository.Repositories
{
    public class ProductRepository: Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetProductsMoreExpensiveThan(decimal price)
        {
            return await _dbSet
                .Where(x => x.Price > price)
                .ToListAsync();
        }

        public async Task<Product?> GetByNameAsync(string name)
        {
            return await _dbSet
                .FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}