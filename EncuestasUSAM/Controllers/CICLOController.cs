using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EncuestasUSAM.Models;

namespace EncuestasUSAM.Controllers
{
    public class CICLOController : Controller
    {
        // GET: CICLO
        public ActionResult Index()
        {
            return View();
        }
        //llenar Materias
        public void MATERIAS()
        {
            ENCUESTASUSAMEntities Datos = new ENCUESTASUSAMEntities();
            var obtMaterias = Datos.MATERIAS.ToList();
            ViewBag.Materia = new SelectList(obtMaterias, dataValueField: "ID_MATERIA", dataTextField: "NOMBRE_MATERIA");

        }

        //llenar Persona
        public void DOCENTE()
        {
            ENCUESTASUSAMEntities Datos = new ENCUESTASUSAMEntities();
            //var obtPersona = Datos.DOCENTE.ToList();
            //ViewBag.Docente = new SelectList(obtPersona, dataValueField: "ID_DOCENTE", dataTextField: "PERSONA");

            List<DOCENTECrud> lista = null;
            using (Datos)
            {
                lista = (from d in Datos.DOCENTE
                         join p in Datos.PERSONA on d.PERSONA equals p.ID_PERSONA
                         select new DOCENTECrud
                         {
                             ID_DOCENTE = d.ID_DOCENTE,
                             DOCENTE = p.PRIMER_NOMBRE_PERSONA + " " + p.PRIMER_APELLIDO_PERSONA
                         }).ToList();
            }

            List<SelectListItem> items = lista.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.DOCENTE.ToString(),
                    Value = d.ID_DOCENTE.ToString(),
                    Selected = false
                };
            }).ToList();

            ViewBag.Docente = items;
        }

        [HttpGet]
        public ActionResult Agregar()
        {
            MATERIAS();
            DOCENTE();
            return View();
        }

        public ActionResult Agregar(CICLOcrudInsert modelo)
        {
            DateTime ahora = DateTime.Today;
            if (!ModelState.IsValid)
            {
                MATERIAS();
                DOCENTE();
                return View(modelo);
            }

            using (var dbData = new ENCUESTASUSAMEntities())
            {

                CICLO obj = new CICLO();
                obj.COD_CICLO = modelo.COD_CICLO;
                obj.DOCENTE = modelo.DOCENTE;
                obj.MATERIA = modelo.MATERIA;
                obj.FECHA_INICIO = modelo.FECHA_INICIO;
                obj.FECHA_FIN = modelo.FECHA_FIN;
                dbData.CICLO.Add(obj);
                dbData.SaveChanges();
            }

            return Redirect(Url.Content("~/CICLO/Consultar"));
        }

        public ActionResult Borrar(int? id)
        {
            ENCUESTASUSAMEntities db = new ENCUESTASUSAMEntities();
            CICLO ciclo = db.CICLO.Find(id);
            db.CICLO.Remove(ciclo);
            db.SaveChanges();
            return Redirect(Url.Content("~/CICLO/Consultar"));
        }

        public ActionResult Actualizar(int? id)
        {
            MATERIAS();
            DOCENTE();
            CICLOcrudUpdate modelo = new CICLOcrudUpdate();
            using (var bDatos = new ENCUESTASUSAMEntities())
            {
                var objCiclo = bDatos.CICLO.Find(id);

                modelo.COD_CICLO = objCiclo.COD_CICLO;
                modelo.DOCENTE =(int) objCiclo.DOCENTE;
                modelo.MATERIA = (int)objCiclo.MATERIA;
                modelo.FECHA_INICIO = (DateTime)objCiclo.FECHA_INICIO;
                modelo.FECHA_FIN = (DateTime)objCiclo.FECHA_FIN;
                modelo.ID_CICLO = objCiclo.ID_CICLO;
            }
            return View(modelo);
        }
        [HttpPost]
        public ActionResult Actualizar(CICLOcrudUpdate modelo)
        {
            if (!ModelState.IsValid)
            {
                MATERIAS();
                DOCENTE();
                return View(modelo);
            }
            using (var bDatos = new ENCUESTASUSAMEntities())
            {
                var objCiclo = bDatos.CICLO.Find(modelo.ID_CICLO);
                objCiclo.ID_CICLO = modelo.ID_CICLO;
                objCiclo.COD_CICLO = modelo.COD_CICLO;
                objCiclo.DOCENTE = modelo.DOCENTE;
                objCiclo.MATERIA = modelo.MATERIA;
                objCiclo.FECHA_INICIO = modelo.FECHA_INICIO;
                objCiclo.FECHA_FIN = modelo.FECHA_FIN;
                bDatos.Entry(objCiclo).State = System.Data.Entity.EntityState.Modified;
                bDatos.SaveChanges();
            }
            return Redirect(Url.Content("~/CICLO/Consultar"));
        }

        public ActionResult Consultar()
        {
            List<CICLOvista> list = null;
            using (ENCUESTASUSAMEntities bDatos = new ENCUESTASUSAMEntities())
            {
                list = (from d in bDatos.CICLO
                        join a in bDatos.PERSONA on d.DOCENTE equals a.ID_PERSONA
                        join b in bDatos.MATERIAS on d.MATERIA equals b.ID_MATERIA
                        orderby d.ID_CICLO
                        select  new CICLOvista 
                        {
                            ID_CICLO = d.ID_CICLO,
                            COD_CICLO = d.COD_CICLO,
                            PRIMER_NOMBRE = a.PRIMER_NOMBRE_PERSONA + " " + a.SEGUNDO_APELLIDO_PERSONA,
                            NOMBRE_MATERIA = b.NOMBRE_MATERIA,
                            FECHA_INICIO = d.FECHA_INICIO,
                            FECHA_FIN = d.FECHA_FIN
                        }).ToList();

            }

            return View(list);
        }
    }
}