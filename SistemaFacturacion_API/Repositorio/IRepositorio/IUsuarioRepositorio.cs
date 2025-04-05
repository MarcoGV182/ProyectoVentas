using SistemaFacturacion_API.Datos;
using SistemaFacturacion_Model.Modelos.DTOs;

namespace SistemaFacturacion_API.Repositorio.IRepositorio
{
    public interface IUsuarioRepositorio
    {
        Task<ICollection<Usuario>> ObtenerUsuarios();

        Task<Usuario> ObtenerUsuario(string id);

        Task<Usuario> Registrar(UsuarioRegistroDTO entidad);

        Task<bool> ValidarUsuario(UsuarioRegistroDTO entidad);
    }
}
