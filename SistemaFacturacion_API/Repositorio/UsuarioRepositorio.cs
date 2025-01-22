using Microsoft.EntityFrameworkCore;
using SistemaFacturacion_API.Datos;
using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Identity;

namespace SistemaFacturacion_API.Repositorio
{
    public class UsuarioRepositorio : RepositorioGenerico<IdentityUser>, IUsuarioRepositorio
    {
        private readonly ApplicationDbContext _db;

        public UsuarioRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        //public async Task<Usuario> Actualizar(Usuario entidad)
        //{
        //    _db.Usuario.Update(entidad);
        //    await Grabar();
        //    return entidad;
        //}

        public async Task<bool> ValidarUsuario(UsuarioRegistroDTO entidad)
        {  
            /*var Usuario = await _db.Usuario.FirstOrDefaultAsync(c => c.Login == entidad.login);

            if (Usuario == null)
                return true;

            if (Usuario.Estado == "I" || Usuario.Fechabaja != null)
                return false;*/
                       

            return true;
        }
    }
}
