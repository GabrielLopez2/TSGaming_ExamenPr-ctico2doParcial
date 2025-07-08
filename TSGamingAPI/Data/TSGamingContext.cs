using Microsoft.EntityFrameworkCore;
using TSGamingAPI.Models;

namespace TSGamingAPI.Data
{
    public class TSGamingContext : DbContext
    {
        public TSGamingContext(DbContextOptions<TSGamingContext> options) : base(options) { }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
    }
}
