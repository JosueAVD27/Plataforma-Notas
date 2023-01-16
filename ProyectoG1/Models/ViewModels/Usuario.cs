using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoG1.Models
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string username { get; set; }
        public string nombreUsuario { get; set; }
        public string apellidoUsuario { get; set; }
        public string claveUsuario { get; set; }
        public string cedulaUsuario { get; set; }
        public string telefonoUsuario { get; set; }
        public string correoUsuario { get; set; }
        public int idTipo { get; set; }
        public int idEstado { get; set; }
    }
}