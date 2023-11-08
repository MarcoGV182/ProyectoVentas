using SistemaFacturacionWeb.Modelos;

namespace SistemaFacturacionWeb.Repositorio.IRepositorio
{
    public interface IMarcaRepositorio:IRepositorioGenerico<Marca>
    {
        Task<Marca> Actualizar(Marca entidad);
    }
}
