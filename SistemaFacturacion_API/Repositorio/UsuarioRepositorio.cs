using Microsoft.EntityFrameworkCore;
using SistemaFacturacion_API.Datos;
using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Identity;

namespace SistemaFacturacion_API.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<Usuario> _userManager;

        public UsuarioRepositorio(ApplicationDbContext db, UserManager<Usuario> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<Usuario> ObtenerUsuario(string id)
        {
           var usuario = await _userManager.Users
                .Include(u => u.UserRoles)          // Incluye UserRoles
                .ThenInclude(ur => ur.RoleId)   // Incluye Role desde UserRoles
                .Where(c=>c.Id == id)
                .Select(u => new Usuario  // Proyecta a un DTO
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Email = u.Email,
                    UserRoles = u.UserRoles
                })
                .ToListAsync();

            return usuario.FirstOrDefault();
        }

        public async Task<ICollection<Usuario>> ObtenerUsuarios()
        {
            var usuarios = await _userManager.Users   // Incluye Role desde UserRoles
               .Select(u => new Usuario  // Proyecta a un DTO
               {
                   Id = u.Id,
                   UserName = u.UserName,
                   Email = u.Email,
                   UserRoles = u.UserRoles
               })
               .ToListAsync();

            return usuarios;
        }

        public Task<Usuario> Registrar(UsuarioRegistroDTO entidad)
        {
            throw new NotImplementedException();
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
