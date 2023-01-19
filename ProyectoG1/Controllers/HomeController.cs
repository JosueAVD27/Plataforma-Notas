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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Usuario( int id )
        {
            UsuarioViewModel model = new UsuarioViewModel();
            using (registro_calificacionesEntities db = new registro_calificacionesEntities())
            {
                var oUsuario = db.usuarios.Find(id);
                model.idUsuario = oUsuario.idUsuario;
                model.username = oUsuario.username;
                model.nombreUsuario = oUsuario.nombreUsuario;
                model.apellidoUsuario = oUsuario.apellidoUsuario;
                model.cedulaUsuario = oUsuario.cedulaUsuario;
                model.telefonoUsuario = oUsuario.telefonoUsuario;
                model.correoUsuario = oUsuario.correoUsuario;
                model.fotoUsuario = oUsuario.fotoUsuario;
                model.idTipo = oUsuario.idTipo;
                model.idEstado = oUsuario.idEstado;
                model.claveUsuario = oUsuario.claveUsuario;

            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Usuario(UsuarioViewModel usuarioModel)
        {
            try
            {
                //Validar los data Annotations
                if (ModelState.IsValid)
                {
                    HttpPostedFileBase FileBase = Request.Files[0];
                    WebImage image = new WebImage(FileBase.InputStream);
                    usuarioModel.fotoUsuario = image.GetBytes();

                        //Si todo es valio vamos a guardar los datos en la base de datos
                        using (registro_calificacionesEntities db = new registro_calificacionesEntities())
                    {
                        var oUsuario = new usuarios();
                        oUsuario.idUsuario = usuarioModel.idUsuario;
                        oUsuario.claveUsuario = usuarioModel.claveUsuario;
                        oUsuario.username = usuarioModel.username;
                        oUsuario.nombreUsuario = usuarioModel.nombreUsuario;
                        oUsuario.apellidoUsuario = usuarioModel.apellidoUsuario;
                        oUsuario.cedulaUsuario = usuarioModel.cedulaUsuario;
                        oUsuario.telefonoUsuario = usuarioModel.telefonoUsuario;
                        oUsuario.correoUsuario = usuarioModel.correoUsuario;
                        oUsuario.fotoUsuario = usuarioModel.fotoUsuario;
                        oUsuario.idTipo = usuarioModel.idTipo;
                        oUsuario.idEstado = usuarioModel.idEstado;

                        db.Entry(oUsuario).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return RedirectToAction("Usuario", new { id = usuarioModel.idUsuario });
                    
                }
                return View(usuarioModel);
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
    }
}