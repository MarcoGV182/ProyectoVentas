using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;


namespace SistemaFacturacion_WebAssembly.Services.IServices
{
    public interface IRangoTimbradoService
    {
        Task<APIResponse<List<RangoTimbradoDTO>>> ObtenerTodos();
        Task<APIResponse<RangoTimbradoDTO>> Obtener(int id);
        Task<APIResponse<RangoTimbradoDTO>> Crear(RangoTimbradoCreateDTO dto);
        Task<APIResponse<object>> Eliminar(int id);
        Task<APIResponse<object>> Actualizar(int id, RangoTimbradoCreateDTO dto);
    }
}
