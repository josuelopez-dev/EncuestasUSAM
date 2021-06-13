using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EncuestasUSAM.Models;

namespace EncuestasUSAM.Controllers
{
    public class ProyectoController : Controller
    {
       
        // GET: Proyecto
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CerrarSesion()
        {
            Session["Usuario"] = null;
            return RedirectToAction("Ingresar", "Accesos");
        }

        //llenar Tipo Investigación
        public void TIPO_INVESTIGACION()
        {
        
            ENCUESTASUSAMEntities Datos = new ENCUESTASUSAMEntities();
            var tipoInvestigacion = Datos.TIPO_INVESTIGACION.ToList();
            ViewBag.TipoInvestiga = new SelectList(tipoInvestigacion, dataValueField: "ID", dataTextField: "NOMBRE_TIPO_INVESTIGACION");
        }

        //llenar Materias
        public void MATERIAS()
        {
            ENCUESTASUSAMEntities Datos = new ENCUESTASUSAMEntities();
            var obtMaterias = Datos.MATERIAS.ToList();
            ViewBag.Materia = new SelectList(obtMaterias, dataValueField: "ID_MATERIA", dataTextField: "NOMBRE_MATERIA");

        }

        //llenar Diseño de Investigación
        public void DISENIO_INVESTIGACION()
        {
            ENCUESTASUSAMEntities Datos = new ENCUESTASUSAMEntities();
            var obtDisenioInvestigacion = Datos.DISENIO_INVESTIGACION.ToList();
            ViewBag.DisenioInvestigacion = new SelectList(obtDisenioInvestigacion, dataValueField: "ID_DISENIO", dataTextField: "NOMBRE_DISENIO");

        }

        //llenar Grupo Alumno
        public void GRUPO_ALUMNO()
        {
            ENCUESTASUSAMEntities Datos = new ENCUESTASUSAMEntities();
            var obtGrupoAlumno = Datos.GRUPO_ALUMNO.ToList();
            ViewBag.GrupoAlumno = new SelectList(obtGrupoAlumno, dataValueField: "ID_GRUPO_ALUMNO", dataTextField: "ID_ALUMNO");
           
        }

        [HttpGet]
        public ActionResult Agregar()
        {
            
            TIPO_INVESTIGACION();
            MATERIAS();
            DISENIO_INVESTIGACION();
            GRUPO_ALUMNO();
            return View();
        }

        public ActionResult Agregar(PROYECTOcrudInsert modelo)
        {
            DateTime ahora = DateTime.Today;
            if (!ModelState.IsValid)
            {
                TIPO_INVESTIGACION();
                MATERIAS();
                DISENIO_INVESTIGACION();
                GRUPO_ALUMNO();
                return View(modelo);
            }

            using (var dbData = new ENCUESTASUSAMEntities())
            {

                if (!ModelState.IsValid)
                {
                    return View(modelo);
                }

                PROYECTO obj = new PROYECTO();
                obj.NOMBRE_PROYECTO = modelo.NOMBRE_PROYECTO;
                obj.DESCRIPCION = modelo.DESCRIPCION;
                obj.ID_TIPO_INVESTIGACION = modelo.ID_TIPO_INVESTIGACION;
                obj.ID_MATERIA = modelo.ID_MATERIA;
                obj.ID_DISENIO_INVESTIGACION = modelo.ID_DISENIO_INVESTIGACION;
                obj.FECHA_ASIGNACION = modelo.FECHA_ASIGNACION;
                obj.ID_GRUPO_ALUMNO = modelo.ID_GRUPO_ALUMNO;
                dbData.PROYECTO.Add(obj);
                dbData.SaveChanges();
            }

            return Redirect(Url.Content("~/Proyecto/Consultar"));
        }

        public ActionResult Borrar(int? id)
        {
            ENCUESTASUSAMEntities db = new ENCUESTASUSAMEntities();
            PROYECTO proyect = db.PROYECTO.Find(id);
            db.PROYECTO.Remove(proyect);
            db.SaveChanges();
            return Redirect(Url.Content("~/Proyecto/Consultar"));
        }

        public ActionResult Actualizar(int? id)
        {
            TIPO_INVESTIGACION();
            MATERIAS();
            DISENIO_INVESTIGACION();
            GRUPO_ALUMNO();
            PROYECTOcrudUpdate modelo = new PROYECTOcrudUpdate();
            using (var bDatos = new ENCUESTASUSAMEntities())
            {
                var objProyecto = bDatos.PROYECTO.Find(id);

                modelo.NOMBRE_PROYECTO = objProyecto.NOMBRE_PROYECTO;
                modelo.DESCRIPCION = objProyecto.DESCRIPCION;
                modelo.ID_TIPO_INVESTIGACION = (int)objProyecto.ID_TIPO_INVESTIGACION;
                modelo.ID_MATERIA = (int)objProyecto.ID_MATERIA;
                modelo.ID_DISENIO_INVESTIGACION = (int)objProyecto.ID_DISENIO_INVESTIGACION;
                modelo.FECHA_ASIGNACION = (DateTime)objProyecto.FECHA_ASIGNACION.Value;
                modelo.ID_GRUPO_ALUMNO = (int)objProyecto.ID_GRUPO_ALUMNO;
                modelo.ID = objProyecto.ID;
            }
            return View(modelo);
        }
        [HttpPost]
        public ActionResult Actualizar(PROYECTOcrudUpdate modelo)
        {
            if (!ModelState.IsValid)
            {
                TIPO_INVESTIGACION();
                MATERIAS();
                DISENIO_INVESTIGACION();
                GRUPO_ALUMNO();
                return View(modelo);
            }
            using (var bDatos = new ENCUESTASUSAMEntities())
            {
                var objProyecto = bDatos.PROYECTO.Find(modelo.ID);
                objProyecto.ID = modelo.ID;
                objProyecto.NOMBRE_PROYECTO = modelo.NOMBRE_PROYECTO;
                objProyecto.DESCRIPCION = modelo.DESCRIPCION;
                objProyecto.ID_TIPO_INVESTIGACION = modelo.ID_TIPO_INVESTIGACION;
                objProyecto.ID_MATERIA = modelo.ID_MATERIA;
                objProyecto.ID_DISENIO_INVESTIGACION = modelo.ID_DISENIO_INVESTIGACION;
                objProyecto.FECHA_ASIGNACION = modelo.FECHA_ASIGNACION;
                objProyecto.ID_GRUPO_ALUMNO = modelo.ID_GRUPO_ALUMNO;
                bDatos.Entry(objProyecto).State = System.Data.Entity.EntityState.Modified;
                bDatos.SaveChanges();
            }
            return Redirect(Url.Content("~/Proyecto/Consultar"));
        }

        public ActionResult Consultar()
        {
            List<PROYECTOvista> list = null;
            using (ENCUESTASUSAMEntities bDatos = new ENCUESTASUSAMEntities())
            {
                list = (from d in bDatos.PROYECTO
                        join a in bDatos.TIPO_INVESTIGACION on d.ID_TIPO_INVESTIGACION equals a.ID
                        join b in bDatos.MATERIAS on d.ID_MATERIA equals b.ID_MATERIA
                        join c in bDatos.DISENIO_INVESTIGACION on d.ID_DISENIO_INVESTIGACION equals c.ID_DISENIO
                        join e in bDatos.GRUPO_ALUMNO on d.ID_GRUPO_ALUMNO equals e.ID_GRUPO_ALUMNO
                        orderby d.NOMBRE_PROYECTO

                        select new PROYECTOvista
                        {
                            ID = d.ID,
                            NOMBRE_PROYECTO = d.NOMBRE_PROYECTO,
                            DESCRIPCION = d.DESCRIPCION,
                            NOMBRE_TIPO_INVESTIGACION = a.NOMBRE_TIPO_INVESTIGACION,
                            NOMBRE_MATERIA = b.NOMBRE_MATERIA,
                            NOMBRE_DISENIO = c.NOMBRE_DISENIO,
                            FECHA_ASIGNACION = (DateTime)d.FECHA_ASIGNACION,
                            ID_ALUMNO = e.ID_ALUMNO

                        }).ToList();

            }

            return View(list);
        }
    }
}