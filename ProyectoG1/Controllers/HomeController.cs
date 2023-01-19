using ProyectoG1.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoG1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
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