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
    public class CoordinadorController : Controller
    {
        // GET: Coordinador
        public ActionResult Index()
        {
            return View();
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
        public ActionResult Insertar(COORDINADORCrud coordinador) // METODO INSERTAR
        {
            if (!ModelState.IsValid)
            {
                dropSexo();
                dropDepartamento();
                dropProfesion();
                dropFacultad();
                ViewBag.Error = "Error de Registro";
                return View(coordinador);
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

            // ASIGNAR ID_COORDINADOR
            int? IDCoordinador = bdDatos.COORDINADOR.Max(d => (int?)d.ID_COORDINADOR);
            if (IDCoordinador == null)
            {
                IDCoordinador = 1;
            }
            else
            {
                IDCoordinador += 1;
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
                objPersona.PRIMER_NOMBRE_PERSONA = coordinador.PRIMER_NOMBRE;
                objPersona.SEGUNDO_NOMBRE_PERSONA = coordinador.SEGUNDO_NOMBRE;
                objPersona.PRIMER_APELLIDO_PERSONA = coordinador.PRIMER_APELLIDO;
                objPersona.SEGUNDO_APELLIDO_PERSONA = coordinador.SEGUNDO_APELLIDO;
                objPersona.SEXO = coordinador.SEXO;
                objPersona.CORREO_INSTITUCIONAL = coordinador.CORREO_INSTITUCIONAL;
                objPersona.CORREO_PERSONAL = coordinador.CORREO_PERSONAL;
                objPersona.DUI = coordinador.DUI;
                objPersona.DIRECCION = coordinador.DIRECCION;
                objPersona.DEPARTAMENTO = coordinador.DEPARTAMENTO;
                objPersona.TELEFONO_FIJO = coordinador.TELEFONO_FIJO;
                objPersona.TELEFONO_MOVIL = coordinador.TELEFONO_MOVIL;
                bdDatos.PERSONA.Add(objPersona);

                COORDINADOR objCoordinador = new COORDINADOR();
                objCoordinador.ID_COORDINADOR = (int)IDCoordinador;
                objCoordinador.FECHA_INGRESO = coordinador.FECHA_INGRESO;
                objCoordinador.PERSONA = (int)IDPersona;
                objCoordinador.FACULTAD = coordinador.FACULTAD;
                objCoordinador.PROFESION = coordinador.PROFESION;
                bdDatos.COORDINADOR.Add(objCoordinador);

                ASCIIEncoding encoding = new ASCIIEncoding(); // ENCRIPTAR CONTRASEÑA
                USUARIO objUser = new USUARIO();
                objUser.ID_USUARIO = (int)IDUsuario;
                objUser.NOMBRE_USUARIO = coordinador.NOMBRE_USUARIO;
                objUser.PASSWORD = coordinador.PASSWORD;
                objUser.ESTADO_PERMISO = false;
                objUser.ID_TIPO_USUARIO = 3;
                objUser.ID_PERSONA_USUARIO = (int)IDPersona;
                bdDatos.USUARIO.Add(objUser);

                bdDatos.SaveChanges();
            }

            return Redirect(Url.Content("~/Coordinador/Consultar"));
        }

        public ActionResult Consultar()
        {
            List<COORDINADORCrud> lista = null;
            using (bdDatos)
            {
                lista = (from c in bdDatos.COORDINADOR
                         join pe in bdDatos.PERSONA on c.PERSONA equals pe.ID_PERSONA
                         join f in bdDatos.FACULTAD on c.FACULTAD equals f.ID_FACULTAD
                         join p in bdDatos.PROFESION on c.PROFESION equals p.ID_PROFESION
                         join u in bdDatos.USUARIO on c.PERSONA equals u.ID_PERSONA_USUARIO
                         select new COORDINADORCrud
                         {
                             COORDINADOR = pe.PRIMER_NOMBRE_PERSONA + " " + pe.PRIMER_APELLIDO_PERSONA,
                             CORREO_INSTITUCIONAL = pe.CORREO_INSTITUCIONAL,
                             CORREO_PERSONAL = pe.CORREO_PERSONAL,
                             NOMBRE_FACULTAD = f.NOMBRE_FACULTAD,
                             NOMBRE_PROFESION = p.NOMBRE_PROFESION,
                             ESTADO_PERMISO = (bool)u.ESTADO_PERMISO,
                             ID_PERSONA = c.PERSONA
                         }).ToList();
            }
            return View(lista);
        }
    }
}