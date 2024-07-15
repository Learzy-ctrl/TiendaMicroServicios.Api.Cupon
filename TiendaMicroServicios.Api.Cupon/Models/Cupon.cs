using System.ComponentModel.DataAnnotations;

namespace TiendaMicroServicios.Api.Cupon.Models
{
    public class Cupon
    {
        [Key]
        public int CuponId { get; set; }
        [Required]
        public string CuponCode { get; set; }
        [Required]
        public double PorcentajeDescuento { get; set; }

        public int DescuentoMinimo { get; set; }
    }
}
