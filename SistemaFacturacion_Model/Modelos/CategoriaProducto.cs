using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SistemaFacturacion_Model.Modelos.DTOs;

namespace SistemaFacturacion_Model.Modelos
{
    [Table("categoriaproduto")]
    public class CategoriaProducto
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short CategoriaId { get; set; }

        public string Descripcion { get; set; }
    }
}
