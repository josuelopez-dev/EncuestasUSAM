using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using EncuestasUSAM.Models;
using EncuestasUSAM.Controllers;

namespace MVC_SEGURIDAD.Filters
{
    public class VerificaSesion : ActionFilterAttribute
    {
        USUARIO obUsuario = new USUARIO();
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            try
            {
                base.OnActionExecuted(filterContext);
                obUsuario = (USUARIO)HttpContext.Current.Session["Usuario"];
                if (obUsuario == null)
                {
                    if (filterContext.Controller is AccesosController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("~/Accesos/Ingresar");
                    }
                }
            }
            catch(Exception)
            {
                filterContext.Result= new RedirectResult("~/Accesos/Ingresar");

            }
            }

    }
}