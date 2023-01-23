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

        [Required]
        [Display(Name = "NRC")]
        public int nrc { get; set; }

        [Required]
        [Display(Name = "MATERIA")]
        public string nombreMateria { get; set; }

        [Required]
        [Display(Name = "DOCENTE")]
        public int idUsuario { get; set; }

        public int idEstado { get; set; }

    }
}