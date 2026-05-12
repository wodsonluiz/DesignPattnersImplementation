using System;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Entities;
using Repository.Repositories;
using Repository.Repositories.Interaces;

namespace Repository.UnitOfWork
{
    public class UnitOfWorkService : UnitOfWorkBase
    {
        public IRepository<Product> Products { get; }

        public IRepository<Category> Categories { get; }

        public IProductRepository ProductRepository { get; }

        public ICategoryRepository CategoryRepository { get; }
        
        public UnitOfWorkService(AppDbContext context) : base(context)
        {
            Products = new Repository<Product>(context);

            Categories = new Repository<Category>(context);

            ProductRepository = new ProductRepository(context);

            CategoryRepository = new CategoryRepository(context);
        }
    }
}