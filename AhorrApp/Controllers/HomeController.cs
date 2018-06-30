using AhorrApp.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AhorrApp.Models;
using AhorrApp.ViewModel;

namespace AhorrApp.Controllers
{
    public class HomeController : Controller
    {
        EvoDBEntities context = new EvoDBEntities();
        [CustomAuthorize(Roles ="cliente")]
        public ActionResult Index()
        {
            return View();
        }
        [CustomAuthorize(Roles = "cliente")]
        public ActionResult DatosPersonales()
        {
            DatosPersonalesViewModel objViewModel = new DatosPersonalesViewModel();
            return View(objViewModel);
        }
    }
}