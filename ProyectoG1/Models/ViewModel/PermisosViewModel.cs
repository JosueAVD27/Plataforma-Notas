using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ProyectoG1.Models.ViewModel
{
    public class PermisosViewModel
    {
        public int idTipo { get; set; }

        [Required]
        [Display(Name = "PERMISO")]
        public string tipo { get; set; }

    }
}
