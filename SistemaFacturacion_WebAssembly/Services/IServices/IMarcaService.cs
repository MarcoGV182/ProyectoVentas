using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;

namespace SistemaFacturacion_WebAssembly.Services.IServices
{
    public interface IMarcaService
    {
        Task<APIResponse<List<MarcaDTO>>> ObtenerTodos();
        Task<APIResponse<MarcaDTO>> Obtener(int id);
        Task<APIResponse<MarcaDTO>> Crear(MarcaCreateDTO dto);
        Task<APIResponse<object>> Actualizar(int id, MarcaCreateDTO dto);
        Task<APIResponse<object>> Eliminar(int id);
    }
}
