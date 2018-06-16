using AhorrApp.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AhorrApp.Controllers
{
    public class HomeController : Controller
    { 
       [CustomAuthorize(Roles ="cliente")]
        public ActionResult Index()
        {
            return View();
        }
    }
}