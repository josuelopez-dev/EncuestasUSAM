using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EncuestasUSAM.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobarFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new MVC_SEGURIDAD.Filters.VerificaSesion());
        }
    }
}