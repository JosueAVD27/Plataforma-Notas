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
    public class EditarController : Controller
    {

        public ActionResult Permiso( int id )
        {
            PermisosViewModel model = new PermisosViewModel();
            using (registro_calificacionesEntities db = new registro_calificacionesEntities())
            {
                var oPermiso = db.tipousuario.Find(id);
                model.idTipo = oPermiso.idTipo;
                model.tipo = oPermiso.tipo;
            }
            return View(model);
        }


        [HttpPost]
        public ActionResult Permiso(PermisosViewModel permisoModel)
        {
            try
            {
                //Validar los data Annotations
                if (ModelState.IsValid)
                {
                    //Si todo es valio vamos a guardar los datos en la base de datos
                    using (registro_calificacionesEntities db = new registro_calificacionesEntities())
                    {
                        var oPermiso = new tipousuario();
                        oPermiso.idTipo = permisoModel.idTipo;
                        oPermiso.tipo = permisoModel.tipo;

                        db.Entry(oPermiso).State = System.Data.Entity.EntityState.Modified;
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
        //Edicion del estado

        public ActionResult Estado( int id )
        {
            EstadoViewModel model = new EstadoViewModel();
            using (registro_calificacionesEntities db = new registro_calificacionesEntities())
            {
                var oEstado = db.estados.Find(id);
                model.idEstado = oEstado.idEstado;
                model.estado = oEstado.estado;
            }
            return View(model);
        }


        [HttpPost]
        public ActionResult Estado(EstadoViewModel estadoModel)
        {
            try
            {
                //Validar los data Annotations
                if (ModelState.IsValid)
                {
                    //Si todo es valio vamos a guardar los datos en la base de datos
                    using (registro_calificacionesEntities db = new registro_calificacionesEntities())
                    {
                        var oEstado = new estados();
                        oEstado.idEstado = estadoModel.idEstado;
                        oEstado.estado = estadoModel.estado;

                        db.Entry(oEstado).State = System.Data.Entity.EntityState.Modified;
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


        public ActionResult Materia(int id)
        {
            MateriasViewModel model = new MateriasViewModel();
            using (registro_calificacionesEntities db = new registro_calificacionesEntities())
            {
                var oEstado = db.materia.Find(id);
                model.idMateria = oEstado.idMateria;
                model.nrc = oEstado.nrc;
                model.nombreMateria = oEstado.nombreMateria;
                model.idUsuario = oEstado.idUsuario;
                model.idEstado = oEstado.idEstado;
            }
            return View(model);
        }


        [HttpPost]
        public ActionResult Materia(MateriasViewModel materiaModel)
        {
            try
            {
                //Validar los data Annotations
                if (ModelState.IsValid)
                {
                    //Si todo es valio vamos a guardar los datos en la base de datos
                    using (registro_calificacionesEntities db = new registro_calificacionesEntities())
                    {
                        var num = 1;

                        var oMateria = new materia();
                        oMateria.idMateria = materiaModel.idMateria;
                        oMateria.nrc = materiaModel.nrc;
                        oMateria.nombreMateria = materiaModel.nombreMateria;
                        oMateria.idUsuario = materiaModel.idUsuario;
                        oMateria.idEstado = num;

                        db.Entry(oMateria).State = System.Data.Entity.EntityState.Modified;
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


        //Edicion del Usuario

        public ActionResult Usuario( int id )
        {
            UsuarioViewModel model = new UsuarioViewModel();
            using (registro_calificacionesEntities db = new registro_calificacionesEntities())
            {
                var oUsuario = db.usuarios.Find(id);
                model.idUsuario = oUsuario.idUsuario;
                model.nombreUsuario = oUsuario.nombreUsuario;
                model.apellidoUsuario = oUsuario.apellidoUsuario;
                model.claveUsuario = oUsuario.claveUsuario;
                model.cedulaUsuario = oUsuario.cedulaUsuario;   
                model.telefonoUsuario = oUsuario.telefonoUsuario;
                model.correoUsuario = oUsuario.correoUsuario;
                model.fotoUsuario = oUsuario.fotoUsuario;
                model.idTipo = oUsuario.idTipo;
                model.idEstado = oUsuario.idEstado;
            }
            return View(model);
        }


        [HttpPost]
        public ActionResult Usuario(UsuarioViewModel usuariomodel)
        {
            try
            {
                //Validar los data Annotations
                if (ModelState.IsValid)
                {
                    //Si todo es valio vamos a guardar los datos en la base de datos
                    using (registro_calificacionesEntities db = new registro_calificacionesEntities())
                    {
                        var oUsuario = new usuarios();
                        oUsuario.idUsuario = usuariomodel.idUsuario;
                        oUsuario.nombreUsuario = usuariomodel.nombreUsuario;
                        oUsuario.apellidoUsuario = usuariomodel.apellidoUsuario;
                        oUsuario.claveUsuario = usuariomodel.claveUsuario;
                        oUsuario.cedulaUsuario = usuariomodel.cedulaUsuario;
                        oUsuario.telefonoUsuario = usuariomodel.telefonoUsuario;
                        oUsuario.correoUsuario = usuariomodel.correoUsuario;
                        oUsuario.fotoUsuario = usuariomodel.fotoUsuario;
                        oUsuario.idTipo = usuariomodel.idTipo;
                        oUsuario.idEstado = usuariomodel.idEstado;

                        db.Entry(oUsuario).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Admin/Usuarios");
                }
                return View(usuariomodel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}