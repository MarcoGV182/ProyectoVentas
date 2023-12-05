using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaFacturacion_Web.Models.DTO;

namespace SistemaFacturacion_Web.Models.ViewModel
{
    public class ProductoCreateViewModel
    {
        public ProductoCreateDTO Producto { get; set; }
        public IEnumerable<SelectListItem> MarcaLista { get; set; }
        public IEnumerable<SelectListItem> TipoImpuestoLista { get; set; }

        public ProductoCreateViewModel()
        {
            Producto = new ProductoCreateDTO();
        }
    }
}
