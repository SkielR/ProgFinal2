using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proyectoClub.Models
{
    public class socio
    {
        public int idSocio { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string apellido { get; set; }
        [Required]
        public int idTipoDocumento { get; set; }
        [Required]
        public string numero { get; set; }
        [Required]
        public int idDeporte { get; set; } 

    }
}