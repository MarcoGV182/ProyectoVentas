using SistemaFacturacion_API.Modelos;

namespace SistemaFacturacion_API.Repositorio.IRepositorio
{
    public interface IMarcaRepositorio:IRepositorioGenerico<Marca>
    {
        Task<Marca> Actualizar(Marca entidad);
    }
}
