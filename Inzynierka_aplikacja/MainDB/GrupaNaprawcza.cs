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
    
    public partial class GrupaNaprawcza
    {
        public int grupa_id { get; set; }
        public int serwisant_id { get; set; }
        public int urzadzenie_id { get; set; }
        public int ktory { get; set; }
    
        public virtual Serwisant Serwisant { get; set; }
        public virtual Urzadzenie Urzadzenie { get; set; }
    }
}
