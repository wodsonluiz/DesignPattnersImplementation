using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Entities;
using Repository.Repositories.Interaces;

namespace Repository.Repositories
{
    public class CategoryRepository: Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context): base(context)
        {
        }

        public async Task<Category?> GetByNameAsync(string name)
        {
            return await _dbSet
                .FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}