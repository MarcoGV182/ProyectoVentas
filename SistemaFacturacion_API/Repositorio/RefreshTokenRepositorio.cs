using SistemaFacturacion_API.Datos;
using SistemaFacturacion_Model.Modelos;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using System.Linq.Expressions;

namespace SistemaFacturacion_API.Repositorio
{
    public class RefreshTokenRepositorio : RepositorioGenerico<RefreshToken>, IRefreshTokenRepositorio
    {
        private readonly ApplicationDbContext _db;

        public RefreshTokenRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<RefreshToken> Actualizar(RefreshToken entidad)
        {  
            _db.RefreshTokens.Update(entidad);
            await Grabar();
            return entidad;
        }
       
    }
}
