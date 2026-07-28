using E_Commerce.Doman.Contracts;

namespace E_Commerce.API
{
    public static class WebApplicationExtension
    {
        public static async Task<WebApplication> SeedAndMigrateDataAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredKeyedService<IDataSeeder>("Catalog");

            await seeder.SeedDataAsync();
            return app;
        }
    }
}
