using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRO_SEGURIDAD.Filtros
{
    public class MyErrorHandler : HandleErrorAttribute
    {
        //
        // GET: /MyErrorHandler/

        public override void OnException(ExceptionContext filterContext)
        {
            Exception e = filterContext.Exception;
            //Log Exception e
            filterContext.ExceptionHandled = true;
            filterContext.Result = new ViewResult()
            {
                ViewName = "Error"
            };
        }

    }
}
