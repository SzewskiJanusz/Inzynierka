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
    
    public partial class Urzadzenie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Urzadzenie()
        {
            this.GrupaNaprawcza = new HashSet<GrupaNaprawcza>();
            this.SerwisUrzadzenia = new HashSet<SerwisUrzadzenia>();
        }
    
        public int urzadzenie_id { get; set; }
        public int podatnik_id { get; set; }
        public int miejsce_id { get; set; }
        public int model_id { get; set; }
        public string nr_unikatowy { get; set; }
        public string nr_ewidencyjny { get; set; }
        public string nr_fabryczny { get; set; }
        public System.DateTime data_uruchomienia { get; set; }
        public System.DateTime ostatni_przeglad { get; set; }
        public Nullable<System.DateTime> nastepny_przeglad { get; set; }
        public Nullable<System.DateTime> data_likwidacji { get; set; }
        public int co_ile_przeglad { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GrupaNaprawcza> GrupaNaprawcza { get; set; }
        public virtual Miejsce_instalacji Miejsce_instalacji { get; set; }
        public virtual ModelUrzadzenia ModelUrzadzenia { get; set; }
        public virtual Podatnik Podatnik { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SerwisUrzadzenia> SerwisUrzadzenia { get; set; }
    }
}
