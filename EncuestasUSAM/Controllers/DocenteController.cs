using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using EncuestasUSAM.Models;
using EncuestasUSAM.Models.Utilerias;

namespace EncuestasUSAM.Controllers
{
    public class DocenteController : Controller
    {
        // GET: Docente
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CerrarSesion()
        {
            Session["Usuario"] = null;
            return RedirectToAction("Ingresar", "Accesos");
        }

        // ENTIDAD DE LA BASE
        private ENCUESTASUSAMEntities bdDatos = new ENCUESTASUSAMEntities();

        public void dropSexo() // LLENAR DROPDOWNLIST SEXO
        {
            var sexo = bdDatos.SEXO.ToList();
            ViewBag.Sexo = new SelectList(sexo, dataValueField: "ID_SEXO", dataTextField: "NOMBRE_SEXO");
        }

        public void dropDepartamento() // LLENAR DROPDOWNLIST DEPARTAMENTOS
        {
            var departamento = bdDatos.DEPARTAMENTO.ToList();
            ViewBag.Departamento = new SelectList(departamento, dataValueField: "ID_DEPARTAMENTO", dataTextField: "NOMBRE_DEPARTAMENTO");
        }

        public void dropProfesion() // LLENAR DROPDOWNLIST PROFESION
        {
            var profesion = bdDatos.PROFESION.ToList();
            ViewBag.Profesion = new SelectList(profesion, dataValueField: "ID_PROFESION", dataTextField: "NOMBRE_PROFESION");
        }

        public void dropFacultad() // LLENAR DROPDOWNLIST FACULTAD
        {
            var facultad = bdDatos.FACULTAD.ToList();
            ViewBag.Facultad = new SelectList(facultad, dataValueField: "ID_FACULTAD", dataTextField: "NOMBRE_FACULTAD");
        }

        [HttpGet]
        public ActionResult Insertar() // VISTA INSERTAR
        {
            dropSexo();
            dropDepartamento();
            dropProfesion();
            dropFacultad();
            return View();
        }

        [HttpPost]
        public ActionResult Insertar(DOCENTECrud docente) // METODO INSERTAR
        {
            if (!ModelState.IsValid)
            {
                dropSexo();
                dropDepartamento();
                dropProfesion();
                dropFacultad();
                ViewBag.Error = "Error de Registro";
                return View(docente);
            }

            // ASIGNAR ID_PERSONA
            int? IDPersona = bdDatos.PERSONA.Max(p => (int?)p.ID_PERSONA);
            if (IDPersona == null)
            {
                IDPersona = 1;
            }
            else
            {
                IDPersona += 1;
            }

            // ASIGNAR ID_DOCENTE
            int? IDDocente = bdDatos.DOCENTE.Max(d => (int?)d.ID_DOCENTE);
            if (IDDocente == null)
            {
                IDDocente = 1;
            }
            else
            {
                IDDocente += 1;
            }

            // ASIGNAR ID_USUARIO
            int? IDUsuario = bdDatos.USUARIO.Max(u => (int?)u.ID_USUARIO);
            if (IDUsuario == null)
            {
                IDUsuario = 1;
            }
            else
            {
                IDUsuario += 1;
            }

            using (bdDatos)
            {
                PERSONA objPersona = new PERSONA();
                objPersona.ID_PERSONA = (int)IDPersona;
                objPersona.PRIMER_NOMBRE_PERSONA = docente.PRIMER_NOMBRE;
                objPersona.SEGUNDO_NOMBRE_PERSONA = docente.SEGUNDO_NOMBRE;
                objPersona.PRIMER_APELLIDO_PERSONA = docente.PRIMER_APELLIDO;
                objPersona.SEGUNDO_APELLIDO_PERSONA = docente.SEGUNDO_APELLIDO;
                objPersona.SEXO = (int)docente.SEXO;
                objPersona.CORREO_INSTITUCIONAL = docente.CORREO_INSTITUCIONAL;
                objPersona.CORREO_PERSONAL = docente.CORREO_PERSONAL;
                objPersona.DUI = docente.DUI;
                objPersona.DIRECCION = docente.DIRECCION;
                objPersona.DEPARTAMENTO = (int)docente.DEPARTAMENTO;
                objPersona.TELEFONO_FIJO = docente.TELEFONO_FIJO;
                objPersona.TELEFONO_MOVIL = docente.TELEFONO_MOVIL;
                bdDatos.PERSONA.Add(objPersona);

                DOCENTE objDocente = new DOCENTE();
                objDocente.ID_DOCENTE = (int)IDDocente;
                objDocente.FECHA_INGRESO = docente.FECHA_INGRESO;
                objDocente.PERSONA = (int)IDPersona;
                objDocente.FACULTAD = (int)docente.FACULTAD;
                objDocente.PROFESION = (int)docente.PROFESION;
                bdDatos.DOCENTE.Add(objDocente);

                ASCIIEncoding encoding = new ASCIIEncoding(); // ENCRIPTAR CONTRASEÑA
                USUARIO objUser = new USUARIO();
                objUser.ID_USUARIO = (int)IDUsuario;
                objUser.NOMBRE_USUARIO = docente.NOMBRE_USUARIO;
                objUser.PASSWORD = docente.PASSWORD;
                objUser.ESTADO_PERMISO = false;
                objUser.ID_TIPO_USUARIO = 3;
                objUser.ID_PERSONA_USUARIO = (int)IDPersona;
                bdDatos.USUARIO.Add(objUser);

                bdDatos.SaveChanges();
            }
            //objUser.PASSWORD = encoding.GetBytes(Encriptar.Encrip(docente.PASSWORD));
            return Redirect(Url.Content("~/Docente/Consultar"));
        }

        public ActionResult Consultar()
        {
            List<DOCENTECrud> lista = null;
            using (bdDatos)
            {
                lista = (from d in bdDatos.DOCENTE
                         join pe in bdDatos.PERSONA on d.PERSONA equals pe.ID_PERSONA
                         join f in bdDatos.FACULTAD on d.FACULTAD equals f.ID_FACULTAD
                         join p in bdDatos.PROFESION on d.PROFESION equals p.ID_PROFESION
                         join u in bdDatos.USUARIO on d.PERSONA equals u.ID_PERSONA_USUARIO
                         select new DOCENTECrud
                         {
                             DOCENTE = pe.PRIMER_NOMBRE_PERSONA + " " + pe.PRIMER_APELLIDO_PERSONA,
                             CORREO_INSTITUCIONAL = pe.CORREO_INSTITUCIONAL,
                             CORREO_PERSONAL = pe.CORREO_PERSONAL,
                             NOMBRE_FACULTAD = f.NOMBRE_FACULTAD,
                             NOMBRE_PROFESION = p.NOMBRE_PROFESION,
                             PERMISO = u.ESTADO_PERMISO == true ? "Habilitado" : u.ESTADO_PERMISO == false ? "Deshabilitado" : "Estado",
                             ID_PERSONA = d.PERSONA

                         }).ToList();
            }
            return View(lista);
        }

    }
}