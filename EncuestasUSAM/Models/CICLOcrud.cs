using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EncuestasUSAM.Models
{
    public class CICLOcrudInsert
    {
        [Required]
        [Display(Name = "Código Ciclo")]
        public string COD_CICLO { get; set; }

        [Display(Name = "Docente")]
        [ForeignKey(name: "DOCENTE")]
        public int DOCENTE { get; set; }

        [Display(Name = "Materia")]
        [ForeignKey(name: "MATERIA")]
        public int MATERIA { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Inicio")]
        public DateTime FECHA_INICIO { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Fin")]
        public DateTime FECHA_FIN { get; set; }

        public int ID_CICLO { get; set; }
    }

    public class CICLOcrudUpdate
    {
        [Required]
        [Display(Name = "Código Ciclo")]
        public string COD_CICLO { get; set; }

        [Display(Name = "Docente")]
        [ForeignKey(name: "DOCENTE")]
        public int DOCENTE { get; set; }

        [Display(Name = "Materia")]
        [ForeignKey(name: "MATERIA")]
        public int MATERIA { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Inicio")]
        public DateTime FECHA_INICIO { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Fin")]
        public DateTime FECHA_FIN { get; set; }

        public int ID_CICLO { get; set; }
    }
}