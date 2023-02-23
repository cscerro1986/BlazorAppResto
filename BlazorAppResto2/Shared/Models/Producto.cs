using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppResto2.Shared.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        public string NombreProducto { get; set; } = string.Empty;
        public EstadoProducto? EstadoProducto { get; set; }
        public int EstadoProductoId { get; set; }
        public CategoriaProducto? CategoriaProducto { get; set; }
        public int CategoriaProductoId { get; set; }
        public float Importe { get; set; }
        public int Stock { get; set; }


    }
}
