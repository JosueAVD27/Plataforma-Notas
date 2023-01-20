using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ProyectoG1.Models.ViewModel
{
    public class MateriasViewModel
    {
        public int idMateria { get; set; }

        public int nrc { get; set; }

        public string nombreMateria { get; set; }

        public int idUsuario { get; set; }

        public int idEstado { get; set; }

    }
}