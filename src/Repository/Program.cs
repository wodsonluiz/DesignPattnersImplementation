using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository.Data;
using Repository.Entities;
using Repository.Repositories;
using Repository.Repositories.Interaces;

namespace Repository;

static class Program
{
    static void Main(string[] args)
    {
        var conn = "Host=localhost;Port=5432;Database=repositorydb;Username=postgres;Password=postgres";

        try
        {
            var builder = Host.CreateApplicationBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(conn);
            });

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                context.Database.EnsureCreatedAsync().GetAwaiter();
                context.Database.OpenConnectionAsync().GetAwaiter();

                var genericRepository = scope.ServiceProvider.GetRequiredService<IRepository<Product>>();
                var productRepository = scope.ServiceProvider.GetRequiredService<IProductRepository>();

                var product = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Playstation 5 Pro",
                    Price = 1000
                };

                genericRepository.AddAsync(product).GetAwaiter();
                genericRepository.SaveChangesAsync().GetAwaiter();

                Console.WriteLine("Produto inserido");

                var products = productRepository.GetProductsMoreExpensiveThan(10).GetAwaiter().GetResult();

                foreach (var item in products)
                {
                    Console.WriteLine($"{item.Name} - {item.Price}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error {0}", ex.Message);
        }
    }
}
