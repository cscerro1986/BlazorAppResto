using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppResto2.Shared.Models
{
    public class CategoriaProducto
    {
        [Key]
        public int Id { get; set; }
        public string NombreCategoria { get; set; }= String.Empty;

    }
}
