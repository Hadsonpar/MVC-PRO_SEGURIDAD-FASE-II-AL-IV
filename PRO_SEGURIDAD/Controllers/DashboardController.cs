using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRO_SEGURIDAD.Controllers
{
    public class DashboardController : Controller
    {
        //
        // GET: /Dashboard/
        public ActionResult AdminDashboard()
        {
            return View();
        }

        public ActionResult UsuarioDashboard() {
            return View();
        }
    }
}
