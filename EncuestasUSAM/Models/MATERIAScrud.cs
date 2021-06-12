using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EncuestasUSAM.Models
{
    public class MATERIAScrudInsert
    {
        [Required]
        [Display(Name = "Código Materia")]
        public string CODIGO_MATERIA { get; set; }

        [Required]
        [Display(Name = "Nombre Materia")]
        public string NOMBRE_MATERIA { get; set; }

        [Display(Name = "Carrera")]
        [ForeignKey(name: "CARRERA")]
        public int CARRERA { get; set; }

        public int ID_MATERIA { get; set; }
    }

    public class MATERIAScrudUpdate
    {
        [Required]
        [Display(Name = "Código Materia")]
        public string CODIGO_MATERIA { get; set; }

        [Required]
        [Display(Name = "Nombre Materia")]
        public string NOMBRE_MATERIA { get; set; }

        [Display(Name = "Carrera")]
        [ForeignKey(name: "CARRERA")]
        public int CARRERA_ { get; set; }

        public int ID_MATERIA { get; set; }
    }
}