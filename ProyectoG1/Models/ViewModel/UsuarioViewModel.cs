using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ProyectoG1.Models.ViewModel
{
    public class UsuarioViewModel
    {
        public int idUsuario { get; set; }

        [Required]
        [Display(Name = "Nombre de usuario")]
        [StringLength(20)]
        public string username { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [StringLength(50)]
        public string nombreUsuario { get; set; }

        [Required]
        [Display(Name = "Apellido")]
        [StringLength(50)]
        public string apellidoUsuario { get; set; }

        [Required]
        [StringLength(100)]
        public string claveUsuario { get; set; }

        [Required]
        [Display(Name = "Cedula")]
        [StringLength(10)]
        public string cedulaUsuario { get; set; }

        [Required]
        [Display(Name = "Telefono")]
        [StringLength(10)]
        public string telefonoUsuario { get; set; }

        [Required]
        [Display(Name = "Correo")]
        [StringLength(100)]
        [EmailAddress]
        public string correoUsuario { get; set; }

        public byte[] fotoUsuario { get; set; }

        public int idTipo { get; set; }

        public int idEstado { get; set; }
    }
}