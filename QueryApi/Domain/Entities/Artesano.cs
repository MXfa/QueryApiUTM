using System;
using System.Collections.Generic;

#nullable disable

namespace QueryApi.Domain.Entities
{
    public partial class Artesano
    {
        public Artesano()
        {
            ContactoArtesanos = new HashSet<ContactoArtesano>();
            Productos = new HashSet<Producto>();
            RedSocialArtesanos = new HashSet<RedSocialArtesano>();
            UbicacionArtesanos = new HashSet<UbicacionArtesano>();
        }

        public int IdA { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NombreNegocio { get; set; }
        public string Logo { get; set; }

        public virtual ICollection<ContactoArtesano> ContactoArtesanos { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
        public virtual ICollection<RedSocialArtesano> RedSocialArtesanos { get; set; }
        public virtual ICollection<UbicacionArtesano> UbicacionArtesanos { get; set; }
    }
}
