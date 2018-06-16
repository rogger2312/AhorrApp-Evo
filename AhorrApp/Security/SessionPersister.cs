using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AhorrApp.Models;
namespace AhorrApp.Security
{
    public class SessionPersister
    {
        static string usuarioSession = "objusuario";

        public static Usuario usuario
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return null;
                }
                var sessionvar = HttpContext.Current.Session[usuarioSession];
                if (sessionvar != null)
                {
                    return sessionvar as Usuario;
                }
                return null;
            }
            set
            {
                HttpContext.Current.Session[usuarioSession] = value;
            }
        }
    }
}