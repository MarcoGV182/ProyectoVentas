using SistemaFacturacion_API.Datos;
using SistemaFacturacion_Model.Modelos;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SistemaFacturacion_Model.Modelos.DTOs;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace SistemaFacturacion_API.Repositorio
{
    public class StockRepositorio : IStockRepositorio
    {
        private readonly ApplicationDbContext _db;

        public StockRepositorio(ApplicationDbContext db) 
        {
            _db = db;
        }

        public async Task AgregarStockAsync(int productoId, int ubicacionId, int cantidad)
        {
            var stock = await ObtenerStockAsync(productoId, ubicacionId);

            if (stock == null)
            {
                stock = new Stock
                {
                    ProductoId = productoId,
                    UbicacionId = ubicacionId,
                    Cantidad = cantidad,
                    FechaActualizacion = DateTime.Now
                };
                await _db.Stock.AddAsync(stock);
            }
            else
            {
                stock.Cantidad += cantidad;
                stock.FechaActualizacion = DateTime.Now;
            }

            await _db.SaveChangesAsync();
        }

        public async Task<int> ObtenerCantidadDisponibleAsync(int productoId, int ubicacionId)
        {
            var stock = await ObtenerStockAsync(productoId, ubicacionId);
            return stock?.Cantidad ?? 0;
        }

        public async Task<IEnumerable<Producto>> ObtenerProductosDisponiblesAsync(int ubicacionId)
        {
            var lista = await _db.Stock
            .Include(s => s.Producto)
            .Where(s => s.UbicacionId == ubicacionId && s.Cantidad > 0)
            .Select(s => s.Producto)
            .Where(p => p.Estado == "A")
            .ToListAsync();

            return lista;
        }

        public async Task<Stock> ObtenerStockAsync(int productoId, int ubicacionId)
        {
            return await _db.Stock
            .FirstOrDefaultAsync(s => s.ProductoId == productoId && s.UbicacionId == ubicacionId);
        }

        public async Task RegistrarMovimientoAsync(MovimientoStock movimiento)
        {
            // 1. Registrar el movimiento histórico
            await _db.Movimientos.AddAsync(movimiento);

            // 2. Actualizar el stock actual
            var stock = await ObtenerStockAsync(movimiento.ProductoId, movimiento.UbicacionId);

            if (stock == null)
            {
                stock = new Stock
                {
                    ProductoId = movimiento.ProductoId,
                    UbicacionId = movimiento.UbicacionId,
                    Cantidad = 0
                };
                _db.Stock.Add(stock);
            }


            stock.Cantidad += movimiento.Cantidad;
            stock.FechaActualizacion = DateTime.Now;
        }

        public async Task<List<MovimientoStock>> ObtenerMovimientosPorProductoAsync(int productoId, DateTime? desde, DateTime? hasta)
        {
            var query = _db.Movimientos
                .Include(m => m.Ubicacion)
                .Where(m => m.ProductoId == productoId);

            if (desde.HasValue)
                query = query.Where(m => m.FechaMovimiento >= desde.Value);

            if (hasta.HasValue)
                query = query.Where(m => m.FechaMovimiento <= hasta.Value);

            return await query.OrderByDescending(m => m.FechaMovimiento).ToListAsync();
        }
            

        public async Task<List<MovimientoStock>> ObtenerMovimientosPorUbicacionAsync(int ubicacionId, DateTime? desde, DateTime? hasta)
        {
            var query = _db.Movimientos
                .Include(m => m.Ubicacion)
                .Where(m => m.UbicacionId == ubicacionId);

            if (desde.HasValue)
                query = query.Where(m => m.FechaMovimiento >= desde.Value);

            if (hasta.HasValue)
                query = query.Where(m => m.FechaMovimiento <= hasta.Value);

            return await query.OrderByDescending(m => m.FechaMovimiento).ToListAsync();
        }
    }
}
