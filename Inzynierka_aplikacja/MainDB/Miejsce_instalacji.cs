//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inzynierka_aplikacja.MainDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Miejsce_instalacji
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Miejsce_instalacji()
        {
            this.Urzadzenie = new HashSet<Urzadzenie>();
        }
    
        public int miejsce_id { get; set; }
        public string kraj { get; set; }
        public string miasto { get; set; }
        public string ulica { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Urzadzenie> Urzadzenie { get; set; }
    }
}
