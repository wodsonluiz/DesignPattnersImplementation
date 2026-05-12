using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Repository.UnitOfWork
{
    public abstract class UnitOfWorkBase : IUnitOfWork
    {
        protected readonly DbContext _context;

        private IDbContextTransaction? _transaction;

        protected UnitOfWorkBase(DbContext context)
        {
            _context = context;
        }

        protected async Task BeginTransactionAsync()
        {
            if (_transaction is null)
            {
                _transaction =
                    await _context.Database.BeginTransactionAsync();
            }
        }

        public virtual async Task CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();

                if (_transaction is not null)
                {
                    await _transaction.CommitAsync();
                }
            }
            catch
            {
                await RollbackAsync();
                throw;
            }
        }

        public virtual async Task RollbackAsync()
        {
            if (_transaction is not null)
            {
                await _transaction.RollbackAsync();
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (_transaction is not null)
            {
                await _transaction.DisposeAsync();
            }

            await _context.DisposeAsync();
        }
    }
}