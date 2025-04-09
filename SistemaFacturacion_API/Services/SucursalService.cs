using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using SistemaFacturacion_Model.Modelos;
using SistemaFacturacion_Model.Modelos.DTOs;
using System.Net;

namespace SistemaFacturacion_API.Services
{
    public class SucursalService
    {
        private readonly ILogger<SucursalService> _logger;
        private readonly IMapper _mapper;
        private readonly ISucursalRepositorio _SucursalRepositorio;

        public SucursalService(ILogger<SucursalService> logger, IMapper mapper, ISucursalRepositorio sucursalRepositorio)
        {
            _logger = logger;
            _mapper = mapper;
            _SucursalRepositorio = sucursalRepositorio;
        }

        public async Task<IEnumerable<SucursalDTO>> GetSucursales()
        {   
            try
            {
                IEnumerable<Sucursal> sucursalList = await _SucursalRepositorio.ObtenerTodos();
                var _response = _mapper.Map<IEnumerable<SucursalDTO>>(sucursalList);
                return _response;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<SucursalDTO> GetSucursalById(int id)
        {
            try
            {
                Sucursal sucursal = await _SucursalRepositorio.Obtener(x => x.SucursalId == id);
                var _response = _mapper.Map<SucursalDTO>(sucursal);
                return _response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<SucursalDTO> CrearSucursal(SucursalCreateDTO CreateDTO)
        {
            try
            {
                var existeSucursal = _SucursalRepositorio.Obtener(v => v.Nombre.ToLower() == CreateDTO.Nombre.ToLower() &&
                                                                        v.Direccion.ToLower() == CreateDTO.Direccion.ToLower());
                if (existeSucursal.Result != null)
                { 
                    throw new BadHttpRequestException("La registro con el mismo Nombre y dirección ya existe");
                }


                Sucursal sucursal = _mapper.Map<Sucursal>(CreateDTO);
                await _SucursalRepositorio.Crear(sucursal);
                return _mapper.Map<SucursalDTO>(sucursal);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> ActualizarSucursal(int id,SucursalCreateDTO sucursalDTO)
        {
            try
            {
                var Sucursal = await _SucursalRepositorio.Obtener(c => c.SucursalId == id, tracked: false);
                if (Sucursal == null)
                { 
                    throw new BadHttpRequestException("La sucursal no existe");
                }


                Sucursal sucursal = _mapper.Map<Sucursal>(sucursalDTO);
                await _SucursalRepositorio.Actualizar(sucursal);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> EliminarSucursal(int id)
        {
            try
            {
                var Sucursal = await _SucursalRepositorio.Obtener(c => c.SucursalId == id, tracked: false);
                if (Sucursal == null)
                {
                    throw new BadHttpRequestException("La sucursal no existe");
                }

                await _SucursalRepositorio.Eliminar(Sucursal);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
