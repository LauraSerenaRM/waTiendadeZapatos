//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace waTiendadeZapatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblPedido
    {
        public int intCodigoPedido { get; set; }
        public Nullable<int> intCodigoProducto { get; set; }
        public Nullable<int> intCodigoEmpleado { get; set; }
        public int intCantidad { get; set; }
        public System.DateTime datFechaPedido { get; set; }
    
        public virtual tblEmpleado tblEmpleado { get; set; }
        public virtual tblProducto tblProducto { get; set; }
    }
}
