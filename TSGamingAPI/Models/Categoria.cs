using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TSGamingAPI.Models
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }

        public string Nombre { get; set; }

        public ICollection<Producto> Productos { get; set; }
    }
}
