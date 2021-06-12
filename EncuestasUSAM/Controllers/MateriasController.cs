using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EncuestasUSAM.Models;

namespace EncuestasUSAM.Controllers
{
    public class MateriasController : Controller
    {
        // GET: Materias
        public ActionResult Index()
        {
            return View();
        }

        //llenar Carrera
        public void CARRERA()
        {
            ENCUESTASUSAMEntities Datos = new ENCUESTASUSAMEntities();
            var carrera = Datos.CARRERA.ToList();
            ViewBag.Carrera = new SelectList(carrera, dataValueField: "ID_CARRERA", dataTextField: "NOMBRE_CARRERA");
        }

        [HttpGet]
        public ActionResult Agregar()
        {
            CARRERA();
            return View();
        }

        public ActionResult Agregar(MATERIAScrudInsert modelo)
        {
            DateTime ahora = DateTime.Today;
            if (!ModelState.IsValid)
            {
                CARRERA();
                return View(modelo);
            }

            using (var dbData = new ENCUESTASUSAMEntities())
            {

                MATERIAS obj = new MATERIAS();
                obj.NOMBRE_MATERIA = modelo.NOMBRE_MATERIA;
                obj.CODIGO_MATERIA = modelo.CODIGO_MATERIA;
                obj.CARRERA = modelo.CARRERA;
                dbData.MATERIAS.Add(obj);
                dbData.SaveChanges();
            }

            return Redirect(Url.Content("~/Materias/Consultar"));
        }

        public ActionResult Borrar(int? id)
        {
            ENCUESTASUSAMEntities db = new ENCUESTASUSAMEntities();
            MATERIAS materia = db.MATERIAS.Find(id);
            db.MATERIAS.Remove(materia);
            db.SaveChanges();
            return Redirect(Url.Content("~/Materias/Consultar"));
        }
        public ActionResult Actualizar(int? id)
        {
            CARRERA();
            MATERIAScrudUpdate modelo = new MATERIAScrudUpdate();
            using (var bDatos = new ENCUESTASUSAMEntities())
            {
                var objMaterias = bDatos.MATERIAS.Find(id);

                modelo.NOMBRE_MATERIA = objMaterias.NOMBRE_MATERIA;
                modelo.CODIGO_MATERIA = objMaterias.CODIGO_MATERIA;
                modelo.CARRERA_ = (int) objMaterias.CARRERA;
                modelo.ID_MATERIA = objMaterias.ID_MATERIA;
            }
            return View(modelo);
        }
        [HttpPost]
        public ActionResult Actualizar(MATERIAScrudUpdate modelo)
        {
            if (!ModelState.IsValid)
            {
                CARRERA();
                return View(modelo);
            }
            using (var bDatos = new ENCUESTASUSAMEntities())
            {
                var objMaterias = bDatos.MATERIAS.Find(modelo.ID_MATERIA);
                objMaterias.ID_MATERIA = modelo.ID_MATERIA;
                objMaterias.CODIGO_MATERIA = modelo.CODIGO_MATERIA;
                objMaterias.CARRERA = modelo.CARRERA_;
                bDatos.Entry(objMaterias).State = System.Data.Entity.EntityState.Modified;
                bDatos.SaveChanges();
            }
            return Redirect(Url.Content("~/Materias/Consultar"));
        }

        public ActionResult Consultar()
        {
            List<MATERIASvista> list = null;
            using (ENCUESTASUSAMEntities bDatos = new ENCUESTASUSAMEntities())
            {
                list = (from d in bDatos.MATERIAS
                        join a in bDatos.CARRERA on d.CARRERA equals a.ID_CARRERA
                        orderby d.ID_MATERIA
                        select new MATERIASvista
                        {
                            ID_MATERIA = d.ID_MATERIA,
                            NOMBRE_MATERIA = d.NOMBRE_MATERIA,
                            CODIGO_MATERIA = d.CODIGO_MATERIA,
                            NOMBRE_CARRERA = a.NOMBRE_CARRERA,
  
                        }).ToList();

            }

            return View(list);
        }
    }
}