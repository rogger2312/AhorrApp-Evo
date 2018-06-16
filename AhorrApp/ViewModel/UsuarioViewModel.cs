using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AhorrApp.Models;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
namespace AhorrApp.ViewModel
{
    public class UsuarioViewModel
    {

        public int? usuarioId { get; set; }
        [Display(Name = "DNI")]
        [Required(ErrorMessage = "Este campo es necesario")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Ingrese un DNI correcto")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "DNI Debe tener 8 caracters")]
        public string DNI { get; set; }
        [Required(ErrorMessage = "Este campo es necesario")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "Este campo es necesario")]
        public string apellidopaterno { get; set; }
        [Required(ErrorMessage = "Este campo es necesario")]
        public string apellidomaterno { get; set; }
        [Display(Name = "Celular")]
        [Required(ErrorMessage = "Este campo es necesario")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Ingrese un Celular correcto")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Celular Debe tener 9 caracters")]
        public string celular { get; set; }
        [Required(ErrorMessage = "Este campo es necesario")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Ingrese una edad correcta")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Edad Debe tener 2 caracters")]
        public int edad { get; set; }
        [Required(ErrorMessage = "Este campo es necesario")]
        public string login { get; set; }
        [Required(ErrorMessage = "Este campo es necesario")]
        public string password { get; set; }

        public UsuarioViewModel()
        {
            EvoDBEntities context = new EvoDBEntities();
           
        }
        public void CargarDatos(int? usuarioId)
        {
            EvoDBEntities context = new EvoDBEntities();
            this.usuarioId = usuarioId;
            if (usuarioId.HasValue)
            {
                Usuario objusuario = context.Usuario.FirstOrDefault(x => x.usuarioid == usuarioId);

                this.DNI = DNI;
                this.apellidomaterno = apellidomaterno;
                this.apellidopaterno = apellidopaterno;
                this.celular = celular;
                this.edad = edad;
                this.login = login;
                this.password = password;
            }

        }
    }
}