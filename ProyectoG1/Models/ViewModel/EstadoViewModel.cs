using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ProyectoG1.Models.ViewModel
{
    public class EstadoViewModel
    {
        public int idEstado { get; set; }

        [Required]
        [Display(Name = "ESTADO")]
        public string estado { get; set; }

    }
}