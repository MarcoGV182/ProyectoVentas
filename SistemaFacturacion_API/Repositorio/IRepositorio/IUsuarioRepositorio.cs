using Microsoft.AspNetCore.Identity;
using SistemaFacturacion_Model.Modelos.DTOs;

namespace SistemaFacturacion_API.Repositorio.IRepositorio
{
    public interface IUsuarioRepositorio:IRepositorioGenerico<IdentityUser>
    {
        //Task<IdentityUser> Actualizar(IdentityUser entidad);

        Task<bool> ValidarUsuario(UsuarioRegistroDTO entidad);
    }
}
