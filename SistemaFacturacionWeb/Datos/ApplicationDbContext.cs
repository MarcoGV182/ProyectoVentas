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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    Nombre = "Villa Real",
                    Detalle = "Detalle villa real",
                    ImagenURL = string.Empty,
                    Ocupantes = 5,
                    MetrosCuadratos = 50,
                    Amenidad = "",
                    FechaCreacion = DateTime.Now
                },
                new Villa()
                {
                    Id = 2,
                    Nombre = "Villa Nueva 2 ",
                    Detalle = "Detalle villa nueva 2",
                    ImagenURL = string.Empty,
                    Ocupantes = 10,
                    MetrosCuadratos = 60,
                    Amenidad = "",
                    FechaCreacion = DateTime.Now
                });
        }
    }
}
