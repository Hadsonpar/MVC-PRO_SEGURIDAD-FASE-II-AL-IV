using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PRO_SEGURIDAD.Models
{
    public class Login
    {

        [Required]
        [StringLength(100, ErrorMessage = "Debe Ingresar al menos 2 caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }

        [Required(ErrorMessage = "Debe ingresar el nombre del usuario")]
        public string usuario { get; set; }
    }
}