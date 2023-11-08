using Microsoft.EntityFrameworkCore;
using SistemaFacturacionWeb.Datos;
using SistemaFacturacionWeb.Repositorio.IRepositorio;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace SistemaFacturacionWeb.Repositorio
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> _dbSet;

        public RepositorioGenerico(ApplicationDbContext db)
        {
            _db = db;
            this._dbSet = db.Set<T>();
        }

        public async Task Crear(T entidad)
        {
            await _dbSet.AddAsync(entidad);
            await Grabar();
        }

        public async Task Grabar()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<T> Obtener(Expression<Func<T, bool>>? filtro = null, bool tracked = true, params string[] includes)
        {
            IQueryable<T> query = _dbSet;
            if (!tracked)
                query = query.AsNoTracking();

            if (filtro != null)
            {
                query = query.Where(filtro);
            }

            // Aplicar la inclusión de datos relacionados
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<T>> ObtenerTodos(Expression<Func<T, bool>>? filtro=null, params string[] includes)
        {
            IQueryable<T> query = _dbSet;
            

            if (filtro != null)
            {
                query = query.Where(filtro);
            }

            // Aplicar la inclusión de datos relacionados
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        public async Task Eliminar(T entidad)
        {
            _dbSet.Remove(entidad);
            await Grabar();
        }
    }
}
