using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;

namespace SistemaFacturacion_WebAssembly.Services.IServices 
{ 
    public interface IArticuloService
    {
        Task<List<ArticuloDTO>> ObtenerTodos(int ubicacion);
        Task<ArticuloDTO> Obtener(int id);        
    }
}
