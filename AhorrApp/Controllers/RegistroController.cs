using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AhorrApp.ViewModel;
using AhorrApp.Models;

namespace AhorrApp.Controllers
{
    public class RegistroController : Controller
    {
        
        public ActionResult Agregar(int? usuarioId)
        {
            UsuarioViewModel objviewmodel = new UsuarioViewModel();
            objviewmodel.CargarDatos(usuarioId);
            EvoDBEntities context = new EvoDBEntities();
      
            return View(objviewmodel);
        }

        [HttpPost]
   public ActionResult Agregar(UsuarioViewModel objviewmodel)
        {
            if(!ModelState.IsValid)
            {
                return View(objviewmodel);

            }
            
            try
            {
                EvoDBEntities context = new EvoDBEntities();
                Usuario objusuario = new Usuario();
                if(objviewmodel.usuarioId.HasValue)
                {
                    objusuario = context.Usuario.FirstOrDefault(x=>x.usuarioid == objviewmodel.usuarioId);
                    objusuario.usuarioid = objviewmodel.usuarioId.Value;
                    
                }

                else
                {
                    context.Usuario.Add(objusuario);
                }


                objusuario.apellidomaterno = objviewmodel.apellidomaterno;
                objusuario.apellidopaterno = objviewmodel.apellidopaterno;
                objusuario.celular = objviewmodel.celular;
                objusuario.DNI = objviewmodel.DNI;
                objusuario.edad = objviewmodel.edad;
                objusuario.login = objviewmodel.login;
                objusuario.nombre = objviewmodel.nombre;
                objusuario.password = objviewmodel.password;

                context.SaveChanges();
                TempData["Mensaje"] = "Exito! La operación se realizó con éxito";
                return RedirectToAction("Login", "Account");
            }
            
            catch(Exception ex)
            {
                TempData["Mensaje"] = "Error! " + ex.Message.ToList();

                return View(objviewmodel);
            }

        }

        

    }
}