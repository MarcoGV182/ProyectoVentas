using Microsoft.EntityFrameworkCore;
using SistemaFacturacion_API.Datos;
using SistemaFacturacion_Model.Modelos;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage;

namespace SistemaFacturacion_API.Repositorio
{
    public class VentaRepositorio: RepositorioGenerico<Venta>, IVentaRepositorio
    {
        private readonly ApplicationDbContext _db;
       

        public VentaRepositorio(ApplicationDbContext db): base(db) 
        {
            _db = db;
        }


        public async Task CreateVentaAsync(Venta venta)
        {
            using var transaction = await _db.Database.BeginTransactionAsync();

            try
            {   
                await _db.Set<Venta>().AddAsync(venta);
                await _db.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw; // Relanza la excepción para manejo superior
            }
        }


    }
}
