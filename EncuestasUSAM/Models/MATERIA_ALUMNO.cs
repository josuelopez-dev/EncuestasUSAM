//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EncuestasUSAM.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MATERIA_ALUMNO
    {
        public int ID_MATERIA_ALUMNO { get; set; }
        public int ID_MATERIA { get; set; }
        public int ID_ALUMNO { get; set; }
    
        public virtual ALUMNOS ALUMNOS { get; set; }
        public virtual MATERIAS MATERIAS { get; set; }
    }
}
