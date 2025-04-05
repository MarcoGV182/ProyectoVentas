using Microsoft.EntityFrameworkCore;
using SistemaFacturacion_API.Datos;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace SistemaFacturacion_API.Repositorio
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
        }

        public async Task Grabar()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<T> Obtener(Expression<Func<T, bool>>? filtro = null, bool tracked = true, string incluirPropiedades = null)
        {
            IQueryable<T> query = _dbSet;
            if (!tracked)
                query = query.AsNoTracking();

            // Aplicar la inclusión de datos relacionados
            if (incluirPropiedades != null)
            {
                foreach (var include in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(include);
                }
            }

            if (filtro != null)
            {
                query = query.Where(filtro);
            }           

            var queryEF = query.ToQueryString();

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<T>> ObtenerTodos(Expression<Func<T, bool>>? filtro=null, string incluirPropiedades = null)
        {
            try
            {
                IQueryable<T> query = _dbSet;

                // Aplicar la inclusión de datos relacionados
                if (incluirPropiedades != null)
                {
                    foreach (var include in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(include);
                    }
                }


                if (filtro != null)
                {
                    query = query.Where(filtro);
                }

                
                var queryEF = query.ToQueryString();


                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task Eliminar(T entidad)
        {
            _dbSet.Remove(entidad);
            await Grabar();
        }
    }
}
