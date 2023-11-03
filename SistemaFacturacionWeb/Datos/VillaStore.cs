using SistemaFacturacionWeb.Modelos.DTO;

namespace SistemaFacturacionWeb.Datos
{
    public static class VillaStore
    {
        public static List<VillaDTO> VillaList = new List<VillaDTO>()
        {
            new VillaDTO{ Id = 1, Nombre = "Vista a la piscina",Ocupantes = 10,MetrosCuadratos = 5 },
            new VillaDTO{ Id = 2, Nombre = "Vista a la Playa",Ocupantes = 10,MetrosCuadratos = 10}
        };
    }
}
