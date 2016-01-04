using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PRO_SEGURIDAD.Models;
using PRO_SEGURIDAD.Repositorio;

namespace PRO_SEGURIDAD.Controllers
{
    public class LoginController : Controller
    {
        ILoginData ObjILoginData;//Referencia a la interfaz para el acceso a datos

        public LoginController()
        {
            ObjILoginData = new LoginData();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View("Login");
        }
        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                //Se capturan los valores de la base de datos
                var IdUsuario = getIdUsuario(login.usuario);
                var RolUsuario = getRolIdUsuario(Convert.ToString(IdUsuario));

                //Se controla si el usario esta asignado a un determinado rol
                if (string.IsNullOrEmpty(Convert.ToString(RolUsuario)))
                {
                    ModelState.AddModelError("Error", "El usuario no cuenta con un rol asignado");
                    return View(login);
                }
                else
                {
                    //Se inica las sesiones
                    Session["Usuario"] = login.usuario;
                    Session["IdUsuario"] = IdUsuario;
                    Session["RolAsigando"] = RolUsuario;

                    if (string.Equals(Convert.ToString(Session["RolAsigando"]), "Admin"))
                    {
                        return RedirectToAction("AdminDashboard", "Dashboard");//Si el rol asignado es Admin se redirecciona a la vista AdminDashboard
                    }
                    else
                    {
                        return RedirectToAction("UsuarioDashboard", "Dashboard");//Si el rol asignado es Usuario se redirecciona a la vista UsuarioDashboard
                    }
                    //A esto se puede adicinar mas roles, es decir n roles y se controla a base de un switch
                }
            }
            else
            {
                ModelState.AddModelError("Error", "Por favor, Ingresar nombre del usuario y password");
            }
            return View(login);

        }

        [NonAction]
        public string getRolIdUsuario(string UserId)
        {
            return ObjILoginData.getRolIdUsuario(UserId);
        }

        [NonAction]
        public string getIdUsuario(string UserName)
        {
            return ObjILoginData.getIdUsuario(UserName);
        }

    }
}
