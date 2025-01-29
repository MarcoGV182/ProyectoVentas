namespace SistemaFacturacion_Model.Modelos
{
    public class PrecioPromocional
    {
        public int Id { get; set; }
        public int ArticuloId { get; set; }
        public decimal PrecioPromocion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool Activo { get; set; }

        // Relaciones
        public virtual Articulo Articulo { get; set; }
    }
}
