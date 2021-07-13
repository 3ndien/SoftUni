namespace PizzaLabWebAPI.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        Task SeedAsync(PizzaLabDbContext dbContext, IServiceProvider serviceProvider);
    }
}
