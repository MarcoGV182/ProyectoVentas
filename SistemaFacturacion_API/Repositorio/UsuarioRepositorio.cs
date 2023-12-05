using Microsoft.EntityFrameworkCore;
using SistemaFacturacion_API.Datos;
using SistemaFacturacion_API.Modelos;
using SistemaFacturacion_API.Modelos.DTO;
using SistemaFacturacion_API.Repositorio.IRepositorio;

namespace SistemaFacturacion_API.Repositorio
{
    public class UsuarioRepositorio : RepositorioGenerico<Usuario>, IUsuarioRepositorio
    {
        private readonly ApplicationDbContext _db;

        public UsuarioRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Usuario> Actualizar(Usuario entidad)
        {
            _db.Usuario.Update(entidad);
            await Grabar();
            return entidad;
        }

        public async Task<bool> ValidarUsuario(UsuarioCreateDTO entidad)
        {  
            var ExisteColaborador = await _db.Colaborador.FirstOrDefaultAsync(c => c.PersonaId == entidad.UsuarioId);

            if (ExisteColaborador == null)
                return false;

            if (ExisteColaborador.Fechaegreso != null)
                return false;

            return true;
        }
    }
}
