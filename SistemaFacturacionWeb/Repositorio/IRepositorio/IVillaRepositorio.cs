using SistemaFacturacionWeb.Modelos;

namespace SistemaFacturacionWeb.Repositorio.IRepositorio
{
    public interface IVillaRepositorio:IRepositorioGenerico<Villa>
    {
        Task<Villa> Actualizar(Villa entidad);
    }
}
