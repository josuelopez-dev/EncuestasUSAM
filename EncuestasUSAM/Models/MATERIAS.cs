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
    
    public partial class MATERIAS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MATERIAS()
        {
            this.CICLO = new HashSet<CICLO>();
            this.MATERIA_ALUMNO = new HashSet<MATERIA_ALUMNO>();
            this.PROYECTO = new HashSet<PROYECTO>();
        }
    
        public int ID_MATERIA { get; set; }
        public string CODIGO_MATERIA { get; set; }
        public string NOMBRE_MATERIA { get; set; }
        public int CARRERA { get; set; }
    
        public virtual CARRERA CARRERA1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CICLO> CICLO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MATERIA_ALUMNO> MATERIA_ALUMNO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROYECTO> PROYECTO { get; set; }
    }
}