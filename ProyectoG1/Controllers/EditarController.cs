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

    }
}