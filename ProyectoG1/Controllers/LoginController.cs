using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using ProyectoG1.Models;
using ProyectoG1.Models.ViewModel;

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
                        Session["id"] = oUser.idUsuario;
                        Session["username"] = oUser.username;
                        Session["nombre"] = oUser.nombreUsuario;
                        Session["apellido"] = oUser.apellidoUsuario;
                        Session["cedula"] = oUser.cedulaUsuario;
                        Session["telefono"] = oUser.telefonoUsuario;
                        Session["correo"] = oUser.correoUsuario;
                        Session["foto"] = oUser.fotoUsuario;
                        Session["tipo"] = oUser.idTipo;
                        Session["estado"] = oUser.idEstado;
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
        public ActionResult Registrar(UsuarioViewModel usuariomodel)
        {
            try
            {
                //Validar los datos Annotations
                if (ModelState.IsValid)
                {
                    

                    //Si todo es valido vamos a guaradar todos los datos en la base
                    using (registro_calificacionesEntities db = new registro_calificacionesEntities())
                    {
                        string default_image_path = Server.MapPath("~/Imagenes/default/usuario.jpg");
                        byte[] image_bytes = System.IO.File.ReadAllBytes(default_image_path);
                        usuariomodel.fotoUsuario = image_bytes;

                        var num = 1;

                        var oUsuario = new usuarios();
                        oUsuario.idUsuario = usuariomodel.idUsuario;
                        oUsuario.username = usuariomodel.username;
                        oUsuario.nombreUsuario = usuariomodel.nombreUsuario;
                        oUsuario.apellidoUsuario = usuariomodel.apellidoUsuario;
                        oUsuario.claveUsuario = usuariomodel.claveUsuario;
                        oUsuario.cedulaUsuario = usuariomodel.cedulaUsuario;
                        oUsuario.telefonoUsuario = usuariomodel.telefonoUsuario;
                        oUsuario.correoUsuario = usuariomodel.correoUsuario;
                        oUsuario.fotoUsuario = image_bytes;
                        oUsuario.idTipo = num;
                        oUsuario.idEstado = num;

                        db.usuarios.Add(oUsuario);
                        db.SaveChanges();
                    }
                    return Redirect("~/Login/Index");
                }
                return View(usuariomodel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Agregar una imagen
        public ActionResult Imagen()
        {
            var imag = Session["id"];
            registro_calificacionesEntities db = new registro_calificacionesEntities();
            usuarios usuariomodel = db.usuarios.Find(imag);
            byte[] byteImage = usuariomodel.fotoUsuario;
            MemoryStream memoryStream = new MemoryStream(byteImage);
            Image imagen = Image.FromStream(memoryStream);
            memoryStream = new MemoryStream();
            imagen.Save(memoryStream, ImageFormat.Png);
            memoryStream.Position = 0;

            return File(memoryStream, "image/jpg");
        }

        public ActionResult LogOut()
        {
            Session["User"] = null;
            return RedirectToAction("Login/Index");
        }
    }
}