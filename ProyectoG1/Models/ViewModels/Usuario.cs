using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ProyectoG1.Models
{
    public class Usuario
    {
        public int idUsuario { get; set; }

        [Required]
        [StringLength(20)]
        public string username { get; set; }

        [Required]
        [StringLength(50)]
        public string nombreUsuario { get; set; }

        [Required]
        [StringLength(50)]
        public string apellidoUsuario { get; set; }

        [Required]
        [StringLength(100)]
        public string claveUsuario { get; set; }

        [Required]
        [StringLength(10)]
        public string cedulaUsuario { get; set; }

        [Required]
        [StringLength(10)]
        public string telefonoUsuario { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string correoUsuario { get; set; }

        public byte[] fotoUsuario { get; set; }

        public int idTipo { get; set; }

        public int idEstado { get; set; }
    }
}