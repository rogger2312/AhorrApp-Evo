using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AhorrApp.Models;
using System.Security.Principal;

namespace AhorrApp.Security
{
    public class CustomPrincipal : IPrincipal
    {
        public Usuario usuarios;
        public IIdentity Identity { get; set; }

        public CustomPrincipal(Usuario usuario)
        {
            usuarios = usuario;
            Identity = new GenericIdentity(usuario.login);
        }

        public bool IsInRole(string role)
        {
            return role.Contains(usuarios.nombre);
        }
    }
}