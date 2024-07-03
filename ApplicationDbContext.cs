using ConexionEF.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ConexionEF
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TipoProducto> TiposProductos { get; set; }

        public DbSet<MarcaProducto> MarcasProductos { get; set; }

        public DbSet<Producto> Productos { get; set; }

    }
}