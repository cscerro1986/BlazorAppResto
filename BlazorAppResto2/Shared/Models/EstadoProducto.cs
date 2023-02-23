using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorAppResto2.Shared.Models
{
    public class EstadoProducto
    {
        [Key]
        public int Id { get; set; }
        public string NombreEstado { get; set; }

    }
}
