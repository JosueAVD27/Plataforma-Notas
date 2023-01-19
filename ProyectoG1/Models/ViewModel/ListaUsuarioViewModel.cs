using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ProyectoG1.Models.ViewModel
{
    public class ListaUsuarioViewModel
    {
        public int idUsuario { get; set; }

        public string username { get; set; }

        public string nombreUsuario { get; set; }

        public string apellidoUsuario { get; set; }

        public string claveUsuario { get; set; }

        public string cedulaUsuario { get; set; }

        public string telefonoUsuario { get; set; }

        public string correoUsuario { get; set; }

        public byte[] fotoUsuario { get; set; }

        public int idTipo { get; set; }

        public int idEstado { get; set; }
    }
}
