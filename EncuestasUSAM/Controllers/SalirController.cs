using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EncuestasUSAM.Controllers
{
    public class SalirController : Controller
    {
        // GET: Salir
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CerrarSesion()
        {
            Session["Usuario"] = null;
            return RedirectToAction("Ingresar", "Accesos");
        }
    }
}