using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EncuestasUSAM.Models
{
    public class PROYECTOvista
    {
        public int? ID { get; set; }
        public string NOMBRE_PROYECTO { get; set; }
        public string DESCRIPCION { get; set; }
        public int? ID_TIPO_INVESTIGACION { get; set; }
        public int? ID_MATERIA { get; set; }
        public int? ID_DISENIO_INVESTIGACION { get; set; }
        public DateTime FECHA_ASIGNACION { get; set; }
        public int? ID_GRUPO_ALUMNO { get; set; }

        //Tipo Investigación
        public string NOMBRE_TIPO_INVESTIGACION { get; set; }

        //Materias
        public string NOMBRE_MATERIA { get; set; }

        //Diseño Investigación
        public string NOMBRE_DISENIO { get; set; }

        //Grupo Alumno
        public int? ID_ALUMNO { get; set; }
    }
}