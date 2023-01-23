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
    public class AgregarController : Controller
    {

        public ActionResult Permiso()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Permiso(PermisosViewModel permisoModel)
        {
            try
            {
                //Validar los datos Annotations
                if (ModelState.IsValid)
                {
                    //Si todo es valido vamos a guaradar todos los datos en la base
                    using (registro_calificacionesEntities db = new registro_calificacionesEntities())
                    {
                        var oPermiso = new tipousuario();
                        oPermiso.idTipo = permisoModel.idTipo;
                        oPermiso.tipo = permisoModel.tipo;


                        db.tipousuario.Add(oPermiso);
                        db.SaveChanges();
                    }
                    return Redirect("~/Admin/Permisos");
                }
                return View(permisoModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public ActionResult Estado()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Estado(EstadoViewModel estadoModel)
        {
            try
            {
                //Validar los datos Annotations
                if (ModelState.IsValid)
                {
                    //Si todo es valido vamos a guaradar todos los datos en la base
                    using (registro_calificacionesEntities db = new registro_calificacionesEntities())
                    {
                        var oEstado = new estados();
                        oEstado.idEstado = estadoModel.idEstado;
                        oEstado.estado = estadoModel.estado;


                        db.estados.Add(oEstado);
                        db.SaveChanges();
                    }
                    return Redirect("~/Admin/Estados");
                }
                return View(estadoModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public ActionResult Materia()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Materia(MateriasViewModel materiaModel)
        {
            try
            {
                //Validar los datos Annotations
                if (ModelState.IsValid)
                {
                    //Si todo es valido vamos a guaradar todos los datos en la base
                    using (registro_calificacionesEntities db = new registro_calificacionesEntities())
                    {
                        var num = 1;

                        var oMateria = new materia();
                        oMateria.idMateria = materiaModel.idMateria;
                        oMateria.nrc = materiaModel.nrc;
                        oMateria.nombreMateria = materiaModel.nombreMateria;
                        oMateria.idUsuario = materiaModel.idUsuario;
                        oMateria.idEstado = num;

                        db.materia.Add(oMateria);
                        db.SaveChanges();
                    }
                    return Redirect("~/Admin/Materias");
                }
                return View(materiaModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}