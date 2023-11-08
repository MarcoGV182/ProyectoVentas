using Microsoft.EntityFrameworkCore;
using SistemaFacturacionWeb.Modelos;

namespace SistemaFacturacionWeb.Datos
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
                
        }

        public DbSet<Villa> Villas { get; set; }
        public DbSet<Articulo> Articulo { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<TipoImpuesto> TipoImpuesto { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Presentacion> Presentacion { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<TipoProducto> TipoProducto { get; set; }
        public DbSet<UnidadMedida> UnidadMedida { get; set; }
        public DbSet<Ubicacion> Ubicacion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulo>().ToTable("Articulo");
            modelBuilder.Entity<Producto>().ToTable("Producto");
        }
    }
}
