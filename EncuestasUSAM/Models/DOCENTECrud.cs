using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EncuestasUSAM.Models.Utilerias;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EncuestasUSAM.Models
{
    public class DOCENTECrud
    {
        // VARIABLES PARA JOIN
        public string DOCENTE { get; set; }

        public string NOMBRE_FACULTAD { get; set; }

        public string NOMBRE_PROFESION { get; set; }

        // TABLA PERSONA
        public int? ID_PERSONA { get; set; }

        [Display(Name = "Primer Nombre")]
        public string PRIMER_NOMBRE { get; set; }

        [Display(Name = "Segundo Nombre")]
        public string SEGUNDO_NOMBRE { get; set; }

        [Display(Name = "Primer Apellido")]
        public string PRIMER_APELLIDO { get; set; }

        [Display(Name = "Segundo Apellido")]
        public string SEGUNDO_APELLIDO { get; set; }

        [ForeignKey(name: "SEXO")]
        public int? SEXO { get; set; }

        [WorkEmailExist]
        [Display(Name = "Correo Institucional")]
        public string CORREO_INSTITUCIONAL { get; set; }

        [PersonalEmailExist]
        [Display(Name = "Correo Personal")]
        public string CORREO_PERSONAL { get; set; }

        [DUIExist]
        [Display(Name = "DUI")]
        public string DUI { get; set; }

        [Display(Name = "Direccion")]
        public string DIRECCION { get; set; }

        [ForeignKey(name: "DEPARTAMENTO")]
        public int? DEPARTAMENTO { get; set; }

        [HousePhoneExist]
        [Display(Name = "Telefono Fijo")]
        public string TELEFONO_FIJO { get; set; }

        [MovilPhoneExist]
        [Display(Name = "Telefono Movil")]
        public string TELEFONO_MOVIL { get; set; }
        // FIN TABLA PERSONA


        // TABLA DOCENTE
        public int? ID_DOCENTE { get; set; }

        [Display(Name = "Fecha")]
        public DateTime FECHA_INGRESO { get; set; }

        public int? PERSONA { get; set; }

        public int? FACULTAD { get; set; }

        public int? PROFESION { get; set; }


        // TABLA USUARIO
        public int ID_USUARIO { get; set; }

        [Display(Name = "Usuario")]
        [UserExist]
        public string NOMBRE_USUARIO { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string PASSWORD { get; set; }

        [Display(Name = "Confirmacion de Password")]
        public string RePASSWORD { get; set; }

        public bool ESTADO_PERMISO { get; set; }

        public int? ID_TIPO_USUARIO { get; set; }

        public int? ID_PERSONA_USUARIO { get; set; }
    }
}