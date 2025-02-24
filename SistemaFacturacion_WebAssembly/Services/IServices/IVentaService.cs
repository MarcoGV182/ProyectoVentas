using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;

namespace SistemaFacturacion_WebAssembly.Services.IServices
{
    public interface IVentaService
    {
        Task<APIResponse> ObtenerVentas<T>();
        Task<APIResponse> RegistrarVenta<T>(VentaCreateDTO venta);
    }
}
