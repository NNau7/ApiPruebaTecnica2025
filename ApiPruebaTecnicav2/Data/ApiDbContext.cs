using APIPruebaTecnicav2.Models;
using Microsoft.EntityFrameworkCore;

namespace APIPruebaTecnicav2.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
