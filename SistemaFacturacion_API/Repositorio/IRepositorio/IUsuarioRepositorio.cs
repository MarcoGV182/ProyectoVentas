using SistemaFacturacion_API.Modelos;
using SistemaFacturacion_API.Modelos.DTO;

namespace SistemaFacturacion_API.Repositorio.IRepositorio
{
    public interface IUsuarioRepositorio:IRepositorioGenerico<Usuario>
    {
        Task<Usuario> Actualizar(Usuario entidad);

        Task<bool> ValidarUsuario(UsuarioCreateDTO entidad);
    }
}
