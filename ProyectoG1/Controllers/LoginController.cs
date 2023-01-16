using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoG1.Models;

namespace ProyectoG1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Enter(string login_correo, string login_contrasenia)
        {
            try
            {
                using (registro_calificacionesEntities db = new registro_calificacionesEntities())
                {
                    var lst = from u in db.usuarios
                              where u.username == login_correo && u.claveUsuario == login_contrasenia
                              select u;

                    if (lst.Count() > 0)
                    {
                        usuarios oUser = lst.First();
                        Session["User"] = oUser;
                        return Content("1");
                    }
                    else
                    {
                        return Content("Usuario inválido");
                    }
                }

            }
            catch (Exception ex)
            {
                return Content("Ocurrió un error :(" + ex.Message);
            }
        }





        public ActionResult Registrar()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Registrar(Usuario usuariomodel)
        {
            try
            {
                //Validar los datos Annotations
                if (ModelState.IsValid)
                {
                    //Si todo es valido vamos a guaradar todos los datos en la base
                    using (registro_calificacionesEntities db = new registro_calificacionesEntities())
                    {
                        var oUsuario = new usuarios();
                        oUsuario.idUsuario = usuariomodel.idUsuario;
                        oUsuario.username = usuariomodel.username;
                        oUsuario.nombreUsuario = usuariomodel.nombreUsuario;
                        oUsuario.apellidoUsuario = usuariomodel.apellidoUsuario;
                        oUsuario.claveUsuario = usuariomodel.claveUsuario;
                        oUsuario.cedulaUsuario = usuariomodel.cedulaUsuario;
                        oUsuario.telefonoUsuario = usuariomodel.telefonoUsuario;
                        oUsuario.correoUsuario = usuariomodel.correoUsuario;
                        oUsuario.idTipo = usuariomodel.idTipo;
                        oUsuario.idEstado = usuariomodel.idEstado;

                        db.usuarios.Add(oUsuario);
                        db.SaveChanges();
                    }
                    return Redirect("~/Cliente/Index");
                }
                return View(usuariomodel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }






        public ActionResult LogOut()
        {
            Session["User"] = null;
            return RedirectToAction("Login/Index");
        }
    }
}