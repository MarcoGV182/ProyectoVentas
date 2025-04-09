using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;

namespace SistemaFacturacion_WebAssembly.Services.IServices
{
    public interface ITipoServicioService
    {
        Task<APIResponse<List<TipoServicioDTO>>> ObtenerTodos();
        Task<APIResponse<TipoServicioDTO>> Obtener(int id);
        Task<APIResponse<TipoServicioDTO>> Crear(TablaMenorCreateDTO dto);
        Task<APIResponse<object>> Actualizar(int id, TablaMenorCreateDTO dto);
        Task<APIResponse<object>> Eliminar(int id);
    }
}
