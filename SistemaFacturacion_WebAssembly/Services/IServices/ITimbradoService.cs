using DocumentFormat.OpenXml.Office2010.Excel;
using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;


namespace SistemaFacturacion_WebAssembly.Services.IServices
{
    public interface ITimbradoService
    {
        Task<APIResponse<List<TimbradoDTO>>> ObtenerTodos();
        Task<APIResponse<TimbradoDTO>> Obtener(int id);
        Task<APIResponse<TimbradoDTO>> Crear(TimbradoCreateDTO dto);
        Task<APIResponse<object>> Eliminar(int id);
        Task<APIResponse<object>> Actualizar(int id, TimbradoCreateDTO dto);
    }
}
