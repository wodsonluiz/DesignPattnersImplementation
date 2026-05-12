using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repositories.Interaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);

        Task<IEnumerable<T>> GetAllAsync();

        Task AddAsync(T entity);

        void Update(T entity);

        void Remove(T entity);

        Task SaveChangesAsync();
    }
}