using APIPruebaTecnicav1.Models;
using Microsoft.EntityFrameworkCore;

namespace APIPruebaTecnicav1.Data
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
