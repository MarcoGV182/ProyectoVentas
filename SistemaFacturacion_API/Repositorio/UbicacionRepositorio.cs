﻿using SistemaFacturacion_API.Datos;
using SistemaFacturacion_Model.Modelos;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using System.Linq.Expressions;
using System.Net;

namespace SistemaFacturacion_API.Repositorio
{
    public class UbicacionRepositorio : RepositorioGenerico<Ubicacion>, IUbicacionRepositorio
    {
        private readonly ApplicationDbContext _db;

        public UbicacionRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Ubicacion> Actualizar(Ubicacion entidad)
        {  
            _db.Ubicacion.Update(entidad);
            await Grabar();
            return entidad;
        }

        public async Task<bool> ValidarUbicacionActiva(int ubicacionId)
        {
            var ubicacion = await Obtener(c => c.UbicacionId == ubicacionId);
            if (ubicacion == null || !ubicacion.Activa)
            {
                return false;
            }

            return true;
        }
    }
}
