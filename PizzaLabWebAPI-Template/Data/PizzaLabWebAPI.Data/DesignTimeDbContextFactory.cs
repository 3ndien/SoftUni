namespace PizzaLabWebAPI.Data
{
    using System.IO;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PizzaLabDbContext>
    {
        public PizzaLabDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var builder = new DbContextOptionsBuilder<PizzaLabDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);

            return new PizzaLabDbContext(builder.Options);
        }
    }
}
