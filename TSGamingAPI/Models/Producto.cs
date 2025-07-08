using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TSGamingAPI.Models
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string ImagenUrl { get; set; }

        [ForeignKey("Categoria")]
        public int IdCategoria { get; set; }

        public Categoria Categoria { get; set; }
    }
}
