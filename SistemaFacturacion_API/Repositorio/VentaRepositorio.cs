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

            using var transaction = await _db.Database.BeginTransactionAsync().ConfigureAwait(false);

            try
            {
                // 1. Primero guardar la venta para obtener el ID
                await _db.Venta.AddAsync(venta).ConfigureAwait(false);


                var cambios = _db.ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified).ToList();

                foreach (var cambio in cambios)
                {
                    Console.WriteLine($"{cambio.Entity.GetType().Name} - {cambio.State}");
                    if (cambio.Entity is Articulo art)
                    {
                        Console.WriteLine($"Artículo ID: {art.ArticuloId}");
                    }
                }



                await _db.SaveChangesAsync().ConfigureAwait(false); // Genera el VentaId

                // 2. Procesar los items para crear movimientos de stock
                await ProcesarMovimientosStockAsync(venta).ConfigureAwait(false);

                await _db.SaveChangesAsync().ConfigureAwait(false);
                await transaction.CommitAsync().ConfigureAwait(false);

                return venta;
            }
            catch (DbUpdateException ex)
            {
                await transaction.RollbackAsync().ConfigureAwait(false);
                // Log the exception (ex) here if necessary
                throw new InvalidOperationException("Error al guardar la venta en la base de datos.", ex);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync().ConfigureAwait(false);
                // Log the exception (ex) here if necessary
                throw new InvalidOperationException("Ocurrió un error al crear la venta.", ex);
            }
        }

        private async Task ProcesarMovimientosStockAsync(Venta venta)
        {
            venta.MovimientosStock = new List<MovimientoStock>();

            foreach (var item in venta.DetalleVenta.Where(d => d.TipoItem == TipoArticulo.Producto))
            {
                var movimiento = new MovimientoStock
                {
                    ProductoId = item.ItemId,
                    UbicacionId = venta.UbicacionId.Value,
                    Cantidad = -(int)item.Cantidad, // Negativo porque es salida
                    PrecioUnitario = item.Precio,
                    TipoMovimiento = TipoMovimientoStock.Venta,
                    ReferenciaId = venta.Id, // Ahora tenemos el ID
                    DocumentoReferencia = $"Venta-{venta.Id}", // ID conocido
                    UsuarioId = venta.UsuarioIdRegistro,
                    FechaMovimiento = DateTime.Now,
                    Comentarios = $"Venta #{venta.Id}"
                };

                // Registrar movimiento y actualizar stock
                await _stockRepository.RegistrarMovimientoAsync(movimiento).ConfigureAwait(false);
                venta.MovimientosStock.Add(movimiento);
            }
        }
    }
}
