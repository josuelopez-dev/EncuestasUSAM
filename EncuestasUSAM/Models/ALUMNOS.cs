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
    
    public partial class ALUMNOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ALUMNOS()
        {
            this.MATERIA_ALUMNO = new HashSet<MATERIA_ALUMNO>();
        }
    
        public int ID_ALUMNO { get; set; }
        public string CARNET { get; set; }
        public int PERSONA { get; set; }
        public int CARRERA { get; set; }
    
        public virtual CARRERA CARRERA1 { get; set; }
        public virtual PERSONA PERSONA1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MATERIA_ALUMNO> MATERIA_ALUMNO { get; set; }
    }
}
