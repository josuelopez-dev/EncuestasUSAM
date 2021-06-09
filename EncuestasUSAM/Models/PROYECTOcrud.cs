using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EncuestasUSAM.Models
{
    public class PROYECTOcrudInsert
    {

        [Required]
        [Display(Name = "Nombre")]
        public string NOMBRE_PROYECTO { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string DESCRIPCION { get; set; }

        [Required]
        [ForeignKey(name: "ID_TIPO_INVESTIGACION")]
        [Display(Name = "Tipo de Investigación")]
        public int ID_TIPO_INVESTIGACION { get; set; }

        [Required]
        [ForeignKey(name: "ID_MATERIA")]
        [Display(Name = "Materia")]
        public int ID_MATERIA { get; set; }

        [Required]
        [ForeignKey(name: "ID_DISENIO_INVESTIGACION")]
        [Display(Name = "Diseño de Investigación")]
        public int ID_DISENIO_INVESTIGACION { get; set; }

        [Required]
        [Display(Name = "Grupo Alumno")]
        [ForeignKey(name: "ID_GRUPO_ALUMNO")]
        public int ID_GRUPO_ALUMNO { get; set; }

        [Required]
        [Display(Name = "Fecha Asignación")]
        public DateTime FECHA_ASIGNACION { get; set; }

        public int ID { get; set; }
    }
    public class PROYECTOcrudUpdate
    {
        [Required]
        [Display(Name = "Nombre")]
        public string NOMBRE_PROYECTO { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string DESCRIPCION { get; set; }

        [Required]
        [Display(Name = "Tipo de Investigación")]
        public int ID_TIPO_INVESTIGACION { get; set; }

        [Required]
        [Display(Name = "Materia")]
        public int ID_MATERIA { get; set; }

        [Required]
        [Display(Name = "Diseño de Investigación")]
        public int ID_DISENIO_INVESTIGACION { get; set; }

        [Required]
        [Display(Name = "Grupo Alumno")]
        public int ID_GRUPO_ALUMNO { get; set; }

        [Required]
        [Display(Name = "Fecha Asignación")]
        public DateTime FECHA_ASIGNACION { get; set; }

        public int ID { get; set; }
    }
}