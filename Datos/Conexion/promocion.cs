//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos.Conexion
{
    using System;
    using System.Collections.Generic;
    
    public partial class promocion
    {
        public long codigo { get; set; }
        public string nombre { get; set; }
        public Nullable<long> precio { get; set; }
        public Nullable<long> empresa { get; set; }
        public Nullable<System.DateTime> fechaInicial { get; set; }
        public Nullable<System.DateTime> fechaFinal { get; set; }
        public string imagen { get; set; }
    
        public virtual empresa empresa1 { get; set; }
    }
}