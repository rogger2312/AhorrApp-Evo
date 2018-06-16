using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using AhorrApp.Models;

namespace AhorrApp.ViewModel
{
    public class LoginViewModel
    {
        EvoDBEntities context = new EvoDBEntities();
        [Display(Name = "username")]
        [Required(ErrorMessage = "Necesita completar este campo")]
        public String login { get; set; }
        [Display(Name = "password")]
        [Required(ErrorMessage = "Necesita completar este campo")]
        public String password { get; set; }

        public LoginViewModel()
        {

        }

        public Usuario findUser(string login)
        {
            return context.Usuario.FirstOrDefault(x => x.login == login);
        }
    }
}