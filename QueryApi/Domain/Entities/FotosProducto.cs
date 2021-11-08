using System;
using System.Collections.Generic;

#nullable disable

namespace QueryApi.Domain.Entities
{
    public partial class FotosProducto
    {
        public int Idf { get; set; }
        public int Nombre { get; set; }
        public int ProductoIdP { get; set; }

        public virtual Producto ProductoIdPNavigation { get; set; }
    }
}
