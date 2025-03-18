using Microsoft.EntityFrameworkCore;
using SistemaFacturacion_API.Datos;
using SistemaFacturacion_Model.Modelos;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace SistemaFacturacion_API.Repositorio
{
    public class TransaccionRepositorio<TCabecera, TDetalle> : ITransaccionRepositorio<TCabecera, TDetalle> where TCabecera : class
        where TDetalle : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<TCabecera> _dbSet;
        internal DbSet<TDetalle> _dbSetDetalle;

        public TransaccionRepositorio(ApplicationDbContext db)
        {
            _db = db;
            this._dbSet = db.Set<TCabecera>();
            this._dbSetDetalle = db.Set<TDetalle>();
        }

        public async Task Anular(TCabecera entidad)
        {
            _db.Update(entidad);
            await Grabar();
        }

        public async Task Grabar()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<TCabecera> Obtener(Expression<Func<TCabecera, bool>> filtro = null, bool tracked = true, string incluirPropiedades = null)
        {
            IQueryable<TCabecera> query = _dbSet;
            if (!tracked)
                query = query.AsNoTracking();

            if (filtro != null)
            {
                query = query.Where(filtro);
            }

            // Aplicar la inclusión de datos relacionados
            if (incluirPropiedades != null)
            {
                foreach (var include in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(include);
                }
            }

            var queryEF = query.ToQueryString();



            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<TCabecera>> ObtenerTodos(Expression<Func<TCabecera, bool>> filtro = null, string incluirPropiedades = null)
        {
            try
            {
                IQueryable<TCabecera> query = _dbSet;


                if (filtro != null)
                {
                    query = query.Where(filtro);
                }

                // Aplicar la inclusión de datos relacionados
                if (incluirPropiedades != null)
                {
                    foreach (var include in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(include);
                    }
                }
                var queryEF = query.ToQueryString();


                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Registrar(TCabecera cabecera, IEnumerable<TDetalle> detalles)
        {
            // Iniciar la transacción
            using var transaction = await _db.Database.BeginTransactionAsync();
            try
            {
                // Insertar la cabecera
                await _dbSet.AddAsync(cabecera);
                await Grabar();

                // Insertar los detalles
                foreach (var detalle in detalles)
                {
                    await _dbSetDetalle.AddAsync(detalle);
                }
                await Grabar();

                // Confirmar la transacción si todo va bien
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                // Si hay un error, revertir la transacción
                await transaction.RollbackAsync();
                throw;
            }
        }

     
    }
}
