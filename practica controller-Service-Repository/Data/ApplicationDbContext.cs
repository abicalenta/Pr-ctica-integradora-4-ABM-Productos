using Microsoft.EntityFrameworkCore;
using practica_controller_Service_Repository.Entities;

namespace practica_controller_Service_Repository.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
