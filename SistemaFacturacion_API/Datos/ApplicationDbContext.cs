using Microsoft.EntityFrameworkCore;
using SistemaFacturacion_API.Modelos;

namespace SistemaFacturacion_API.Datos
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
                
        }
        public DbSet<Articulo> Articulo { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<TipoImpuesto> TipoImpuesto { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Presentacion> Presentacion { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<TipoProducto> TipoProducto { get; set; }
        public DbSet<UnidadMedida> UnidadMedida { get; set; }
        public DbSet<Ubicacion> Ubicacion { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Colaborador> Colaborador { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Servicio> Servicio { get; set; }
        public DbSet<TipoServicio> TipoServicio { get; set; }
        public DbSet<HistorialRefreshToken> HistorialRefreshToken { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Colaborador>()
            .HasOne(c => c.Persona)
            .WithMany()
            .HasForeignKey(c => c.PersonaId);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Colaborador)
                .WithMany()
                .HasForeignKey(u => u.ColaboradorId);

            modelBuilder.Entity<Articulo>().ToTable("Articulo");
            modelBuilder.Entity<Producto>().ToTable("Producto");
            modelBuilder.Entity<Persona>().ToTable("Persona");
            modelBuilder.Entity<Colaborador>().ToTable("Colaborador");
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Servicio>().ToTable("Servicio");
            modelBuilder.Entity<TipoServicio>().ToTable("TipoServicio");

            modelBuilder.Entity<HistorialRefreshToken>()
            .Property(e => e.EsActivo)
            .HasComputedColumnSql("(FechaExpiracion >= CURRENT_DATE)", stored: true);
        }
    }
}
