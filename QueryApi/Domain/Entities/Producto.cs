using System;
using System.Collections.Generic;

#nullable disable

namespace QueryApi.Domain.Entities
{
    public partial class Producto
    {
        public Producto()
        {
            FotosProductos = new HashSet<FotosProducto>();
        }

        public int IdP { get; set; }
        public string Nombre { get; set; }
        public int Descripcion { get; set; }
        public int MateriaPrima { get; set; }
        public int ArtesanosIdA { get; set; }

        public virtual Artesano ArtesanosIdANavigation { get; set; }
        public virtual ICollection<FotosProducto> FotosProductos { get; set; }
    }
}
