using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EncuestasUSAM.Models
{
    public class MATERIASvista
    {
        public int? ID_MATERIA { get; set; }
        public string CODIGO_MATERIA { get; set; }
        public string NOMBRE_MATERIA { get; set; }
        public int? CARRERA { get; set; }

        //Carrera
        public string NOMBRE_CARRERA { get; set; }

    }
}