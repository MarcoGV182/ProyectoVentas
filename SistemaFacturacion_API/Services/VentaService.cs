using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SistemaFacturacion_API.Datos;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using SistemaFacturacion_Model.Modelos;
using SistemaFacturacion_Model.Modelos.DTOs;
using System.Net;

namespace SistemaFacturacion_API.Services
{
    public class VentaService
    {
        private readonly IMapper _mapper;
        private readonly IVentaRepositorio _VentaRepositorio;
        private readonly IStockRepositorio _stockRepositorio;
        private readonly ApplicationDbContext _context;

        public VentaService(IMapper mapper, IVentaRepositorio ventaRepositorio, IStockRepositorio stockRepositorio, ApplicationDbContext context)
        {
            _mapper = mapper;
            _VentaRepositorio = ventaRepositorio;
            _stockRepositorio = stockRepositorio;
            _context = context;
        }

        public async Task<IEnumerable<VentaDTO>> GetVentas()
        {
            var _response = new List<VentaDTO>();
            try
            {
                IEnumerable<Venta> VentaList = await _VentaRepositorio.ObtenerTodos(incluirPropiedades: "TipoImpuesto,Cliente,Vendedor,Timbrado,Empresa,DetalleVenta");
                _response = _mapper.Map<List<VentaDTO>>(VentaList);


                return _response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<VentaDTO> GetVentaById(int id)
        {
            var _response = new VentaDTO();
            try
            {
                Venta Venta = await _VentaRepositorio.Obtener(v=> v.Id == id, incluirPropiedades: "TipoImpuesto,Cliente,Vendedor,Timbrado,Empresa,DetalleVenta");
                _response = _mapper.Map<VentaDTO>(Venta);
                return _response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<VentaDTO> RegistrarVenta(VentaCreateDTO _ventaDTO)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                #region Validaciones previas
                var existe = await _VentaRepositorio.Obtener(v => v.Establecimiento == _ventaDTO.Establecimiento &&
                                                    v.PuntoExpedicion == _ventaDTO.PuntoExpedicion &&
                                                    v.Numero == _ventaDTO.Numero &&
                                                    v.TimbradoId == _ventaDTO.TimbradoId &&
                                                    v.ClienteId == _ventaDTO.ClienteId);
                if (existe != null)
                {
                    var mensajeError = "La numeración de la factura y timbrado ya existe para el mismo cliente";
                    throw new InvalidOperationException(mensajeError);
                }


                // Validar stock disponible para cada item
                foreach (var item in _ventaDTO.DetalleVenta)
                {
                    var articulo = await _context.Articulo
                   .AsNoTracking()
                   .FirstOrDefaultAsync(a => a.ArticuloId == item.ItemId);
                    if (item.TipoItem == TipoArticulo.Servicio)
                        continue;


                    var disponible = await _stockRepositorio.ObtenerCantidadDisponibleAsync(item.ItemId, _ventaDTO.UbicacionId);

                    if (disponible < item.Cantidad)
                    {
                        var mensajeError = $"Stock insuficiente para el producto {articulo.Descripcion}({item.ItemId})";
                        throw new InvalidOperationException(mensajeError);
                    }
                }
                #endregion

                //Mapear DTO
                var _Venta = _mapper.Map<Venta>(_ventaDTO);

                // 1. Crear venta 
                var ventaCreada = await _VentaRepositorio.CreateVentaAsync(_Venta);

                // 2. Procesar los items para crear movimientos de stock
                await ProcesarMovimientosStockAsync(ventaCreada);

                await transaction.CommitAsync();

                return _mapper.Map<VentaDTO>(ventaCreada);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
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
                await _stockRepositorio.RegistrarMovimientoAsync(movimiento);
                venta.MovimientosStock.Add(movimiento);
            }
        }
    }
}
