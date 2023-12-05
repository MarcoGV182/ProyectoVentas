namespace SistemaFacturacion_Web.Services.IServices
{
    public interface ITipoImpuestoService
    {
        Task<T> ObtenerTodos<T>();
        Task<T> Obtener<T>(int id);        
    }
}
