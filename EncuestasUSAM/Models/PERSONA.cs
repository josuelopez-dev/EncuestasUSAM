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
    
    public partial class PERSONA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PERSONA()
        {
            this.ALUMNOS = new HashSet<ALUMNOS>();
            this.COORDINADOR = new HashSet<COORDINADOR>();
            this.DOCENTE = new HashSet<DOCENTE>();
            this.USUARIO = new HashSet<USUARIO>();
        }
    
        public int ID_PERSONA { get; set; }
        public string PRIMER_NOMBRE_PERSONA { get; set; }
        public string SEGUNDO_NOMBRE_PERSONA { get; set; }
        public string PRIMER_APELLIDO_PERSONA { get; set; }
        public string SEGUNDO_APELLIDO_PERSONA { get; set; }
        public int SEXO { get; set; }
        public string CORREO_INSTITUCIONAL { get; set; }
        public string CORREO_PERSONAL { get; set; }
        public string DUI { get; set; }
        public string DIRECCION { get; set; }
        public int DEPARTAMENTO { get; set; }
        public string TELEFONO_FIJO { get; set; }
        public string TELEFONO_MOVIL { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ALUMNOS> ALUMNOS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COORDINADOR> COORDINADOR { get; set; }
        public virtual DEPARTAMENTO DEPARTAMENTO1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOCENTE> DOCENTE { get; set; }
        public virtual SEXO SEXO1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USUARIO> USUARIO { get; set; }
    }
}
