using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaFacturacion_Model.Modelos;

namespace SistemaFacturacion_API.Datos
{
    public class ApplicationDbContext: IdentityDbContext<Usuario>
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
        public DbSet<CategoriaProducto> CategoriaProducto { get; set; }
        public DbSet<UnidadMedida> UnidadMedida { get; set; }
        public DbSet<Ubicacion> Ubicacion { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Colaborador> Colaborador { get; set; }
        //public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Servicio> Servicio { get; set; }
        public DbSet<TipoServicio> TipoServicio { get; set; }
        public DbSet<Ciudad> Ciudad { get; set; }
        public DbSet<Venta> Venta { get; set; }
        public DbSet<TipoDocumentoIdentidad> TipoDocumentoIdentidad { get; set; }
        public DbSet<Timbrado> Timbrado { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<DetalleVenta> DetalleVenta { get; set; }
        public DbSet<PrecioPromocional> PrecioPromocional { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.GetTableName().ToLower());
            }

            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.HasKey(e => e.ArticuloId);
                entity.HasDiscriminator<TipoArticulo>("TipoArticulo")
                        .HasValue<Producto>(TipoArticulo.Producto)
                        .HasValue<Servicio>(TipoArticulo.Servicio);               
            ;
            });

            // Persona - Colaborador (Relación uno a uno)
            modelBuilder.Entity<Colaborador>()
                .HasOne(c => c.Persona)
                .WithOne(p => p.Colaborador)
                .HasForeignKey<Colaborador>(c => c.PersonaId);
                       

            // Configurar la relación uno a uno entre Usuario y Colaborador
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Colaborador)
                .WithOne()
                .HasForeignKey<Usuario>(u => u.ColaboradorId);


            modelBuilder.Entity<HistorialRefreshToken>()
            .Property(e => e.EsActivo)
            .HasComputedColumnSql("(FechaExpiracion >= CURRENT_DATE)", stored: true);
        }
    }
}
