using Microsoft.EntityFrameworkCore;
using SistemaFacturacion_API.Datos;
using SistemaFacturacion_Model.Modelos;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage;

namespace SistemaFacturacion_API.Repositorio
{
    public class VentaRepositorio : RepositorioGenerico<Venta>, IVentaRepositorio
    {
        private readonly ApplicationDbContext _db;
        private readonly IStockRepositorio _stockRepository;

        public VentaRepositorio(ApplicationDbContext db, IStockRepositorio stockRepository) : base(db)
        {
            _db = db;
            _stockRepository = stockRepository;
        }

        public async Task<Venta> CreateVentaAsync(Venta venta)
        {
            if (venta == null) throw new ArgumentNullException(nameof(venta));
            if (venta.DetalleVenta == null || !venta.DetalleVenta.Any()) throw new ArgumentException("La venta debe tener al menos un detalle de venta.");

            try
            {
                // 1. Primero guardar la venta para obtener el ID
                await _db.Venta.AddAsync(venta);
                await _db.SaveChangesAsync(); // Genera el VentaId

                return venta;
            }           
            catch (Exception ex)
            { 
                // Log the exception (ex) here if necessary
                throw new InvalidOperationException("Ocurrió un error al crear la venta.", ex);
            }
        }

        
    }
}
