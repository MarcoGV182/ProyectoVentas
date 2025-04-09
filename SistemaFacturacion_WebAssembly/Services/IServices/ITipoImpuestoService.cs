using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;


namespace SistemaFacturacion_WebAssembly.Services.IServices
{
    public interface ITipoImpuestoService
    {
        Task<APIResponse<List<TipoImpuestoDTO>>> ObtenerTodos();
        Task<APIResponse<TipoImpuestoDTO>> Obtener(int id);
        Task<APIResponse<TipoImpuestoDTO>> Crear(TipoImpuestoCreateDTO dto);
        Task<APIResponse<object>> Eliminar(int id);
        Task<APIResponse<object>> Actualizar(int id, TipoImpuestoCreateDTO dto);
    }
}
