using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AhorrApp.ViewModel;
namespace AhorrApp.Security
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (SessionPersister.usuario == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Account", action = "Login" }));
            }
            else
            {
                LoginViewModel cuentavm = new LoginViewModel();
                CustomPrincipal mp = new CustomPrincipal(cuentavm.findUser(SessionPersister.usuario.login));

                //if (!mp.IsInRole(Roles))
                //{
                //    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Account", action = "AccessDenied" }));
                //}
            }
        }
    }
}