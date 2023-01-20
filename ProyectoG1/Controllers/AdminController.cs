using ProyectoG1.Models;
using ProyectoG1.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Razor.Generator;

namespace ProyectoG1.Controllers
{
    public class AdminController : Controller
    {

        public ActionResult Configuraciones()
        {
            return View();
        }



        public ActionResult Permisos()
        {
            List<ListaPermisosViewModel> lst;
            using (registro_calificacionesEntities  db = new registro_calificacionesEntities())
            {
                lst = (from d in db.tipousuario
                       select new ListaPermisosViewModel
                       {
                           idTipo = d.idTipo,
                           tipo = d.tipo,

                       }).ToList();
            }
            return View(lst);
        }



        public ActionResult Estados()
        {
            List<ListaEstadoViewModel> lst;
            using (registro_calificacionesEntities db = new registro_calificacionesEntities())
            {
                lst = (from d in db.estados
                       select new ListaEstadoViewModel
                       {
                           idEstado = d.idEstado,
                           estado = d.estado,

                       }).ToList();
            }
            return View(lst);
        }


        public ActionResult Materias()
        {
            List<ListaMateriasViewModel> lst;
            using (registro_calificacionesEntities db = new registro_calificacionesEntities())
            {
                lst = (from d in db.materia
                       select new ListaMateriasViewModel
                       {
                           idMateria = d.idMateria,
                           nrc = d.nrc,
                           nombreMateria = d.nombreMateria,
                           idUsuario = d.idUsuario,
                           idEstado = d.idEstado,

                       }).ToList();
            }
            return View(lst);
        }

        public ActionResult Usuarios()
        {
            List<ListaUsuarioViewModel> lst;
            using (registro_calificacionesEntities db = new registro_calificacionesEntities())
            {
                lst = (from d in db.usuarios
                       select new ListaUsuarioViewModel
                       {
                           idUsuario = d.idUsuario,
                           username = d.username,
                           nombreUsuario = d.nombreUsuario,
                           apellidoUsuario = d.apellidoUsuario,
                           cedulaUsuario = d.cedulaUsuario,
                           telefonoUsuario = d.telefonoUsuario,
                           correoUsuario = d.correoUsuario,
                           idTipo = d.idTipo,
                           idEstado = d.idEstado,

                       }).ToList();
            }
            return View(lst);
        }


        public ActionResult Inscripciones()
        {
            return View();
        }


        // DELETE: Permiso
        [HttpGet]
        public ActionResult EliminarPermiso(int id)
        {
            using (registro_calificacionesEntities db = new registro_calificacionesEntities())
            {
                var oPermiso = db.tipousuario.Find(id);
                db.tipousuario.Remove(oPermiso);
                db.SaveChanges();
            }
            return Redirect("~/Admin/Permisos");
        }
    }
}