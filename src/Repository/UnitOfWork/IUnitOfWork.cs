using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CommitAsync();

        Task RollbackAsync();
    }
}