using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PizzaLab.Data.Models;

namespace PizzaLab.Data
{
    public class PizzaLabDbContext : IdentityDbContext<ApplicationUser>
    {
        public PizzaLabDbContext(DbContextOptions<PizzaLabDbContext> options) : base(options)
        {
        }
    }
}
