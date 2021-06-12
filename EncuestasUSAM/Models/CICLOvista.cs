using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EncuestasUSAM.Models
{
    public class CICLOvista
    {
        public int? ID_CICLO { get; set; }
        public string COD_CICLO { get; set; }
        public int? DOCENTE { get; set; }
        public int? MATERIA { get; set; }
        public DateTime FECHA_INICIO { get; set; }
        public DateTime FECHA_FIN { get; set; }

        //Materias
        public string NOMBRE_MATERIA { get; set; }

        //Persona
        public string PRIMER_NOMBRE { get; set; }
        public string SEGUNDO_NOMBRE { get; set; }
    }
}