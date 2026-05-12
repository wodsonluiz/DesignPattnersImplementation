using System.Threading.Tasks;
using Repository.Entities;

namespace Repository.Repositories.Interaces
{
    public interface ICategoryRepository
    {
        Task<Category?> GetByNameAsync(string name);
    }
}