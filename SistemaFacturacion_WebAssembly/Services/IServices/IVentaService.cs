using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;

namespace SistemaFacturacion_WebAssembly.Services.IServices
{
    public interface IVentaService
    {
        Task<APIResponse<List<VentaDTO>>> ObtenerVentas();
        Task<APIResponse<VentaDTO>> RegistrarVenta(VentaCreateDTO venta);
    }
}
