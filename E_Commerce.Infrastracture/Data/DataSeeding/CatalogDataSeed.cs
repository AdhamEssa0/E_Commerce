using E_Commerce.Doman.Commen;
using E_Commerce.Doman.Contracts;
using E_Commerce.Doman.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commerce.Infrastracture.Data.DataSeeding
{
    public class CatalogDataSeed(StoreDbContext dbContext) : IDataSeeder
    {
        public async Task SeedDataAsync(CancellationToken ct = default)
        {
            // Check if there is any pending migration or not
            try
            {
                var PendingMigrations = await dbContext.Database.GetPendingMigrationsAsync();
                if (PendingMigrations.Any())
                    await dbContext.Database.MigrateAsync(); // Update-Database

                // Path
                var rootPath = Path.Combine(AppContext.BaseDirectory, "DataSeed");

                await SeedDataIfEmptyAsync<Brand, int>(rootPath, "brands.json", ct);
                await SeedDataIfEmptyAsync<ProductType, int>(rootPath, "types.json", ct);
                await SeedDataIfEmptyAsync<Product, int>(rootPath, "products.json", ct);

                var result = await dbContext.SaveChangesAsync(ct);
                //if (result > 0)
                //{
                //    logger.LogInformation($"Data Seeded Successfully, {result} rows affected");
                //}
                //else
                //    logger.LogInformation("Failed to seed data");
            }
            catch (Exception ex)
            {
                //logger.LogError(ex.Message);
            }

        }

        // Method to read data from json
        private async Task SeedDataIfEmptyAsync<T, TKey>(string rootPath, string fileName, CancellationToken ct) where T : BaseEntity<TKey>
        {
            if (await dbContext.Set<T>().AnyAsync())
            {
                return;
            }
            var filePath = Path.Combine(rootPath, fileName);
            if (!File.Exists(filePath))
            {
                return;
            }
            using var fileStream = File.OpenRead(filePath);

            var items = await JsonSerializer.DeserializeAsync<List<T>>(fileStream);
            if (items?.Any() ?? false)
                dbContext.Set<T>().AddRange(items);
            

        }
    }
}