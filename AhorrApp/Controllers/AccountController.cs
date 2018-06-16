using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using AhorrApp.Models;
using AhorrApp.ViewModel;
using AhorrApp.Security;

namespace AhorrApp.Controllers
{
    public class AccountController : Controller
    {

        EvoDBEntities context = new EvoDBEntities();
        [AllowAnonymous]
        public ActionResult Login()
        {
            LoginViewModel objviewmodel = new LoginViewModel();
            return View(objviewmodel);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel objviewmodel)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (!ModelState.IsValid)
            {
                //MENSAJE CAMPOS INCOMPLETOS
                return View();
            }

            try
            {
                Usuario usuario = context.Usuario.FirstOrDefault(x => x.login == objviewmodel.login && x.password == objviewmodel.password);
                if (usuario == null)
                {
                    //MENSAJE DE CORREO O CONTRASEÑA INCORRECTO
                    return View();
                }
                SessionPersister.usuario = usuario;


                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CerrarSesion()
        {
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}