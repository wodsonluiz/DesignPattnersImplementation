using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository.Data;
using Repository.Entities;
using Repository.UnitOfWork;

namespace Repository;

static class Program
{
    static async Task Main(string[] args)
    {
        var conn = "Host=localhost;Port=5432;Database=repositorydb;Username=postgres;Password=postgres";

        try
        {
            var builder = Host.CreateApplicationBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(conn);
            });

            //builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<UnitOfWorkService>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var unitOfWork = scope.ServiceProvider.GetRequiredService<UnitOfWorkService>();

                await context.Database.EnsureCreatedAsync();
                await context.Database.OpenConnectionAsync();

                //var genericRepository = scope.ServiceProvider.GetRequiredService<IRepository<Product>>();
                //var productRepository = scope.ServiceProvider.GetRequiredService<IProductRepository>();

                var category = new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Hardware"
                };

                await unitOfWork.Categories.AddAsync(category);

                var product = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Playstation 5 Pro",
                    Price = 1000
                };

                await unitOfWork.Products.AddAsync(product);
                await unitOfWork.CommitAsync();

                //genericRepository.AddAsync(product).GetAwaiter();
                //genericRepository.SaveChangesAsync().GetAwaiter();

                Console.WriteLine("Transação concluida");

                //var products = productRepository.GetProductsMoreExpensiveThan(10).GetAwaiter().GetResult();
                var products = await unitOfWork.ProductRepository.GetProductsMoreExpensiveThan(10);
                var categories = await unitOfWork.Categories.GetAllAsync();

                foreach (var item in products)
                {
                    Console.WriteLine($"product: {item.Name} - {item.Price}");
                }

                foreach (var item in categories)
                {
                    Console.WriteLine($"product: {item.Name}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error {0}", ex.Message);
        }
    }
}
