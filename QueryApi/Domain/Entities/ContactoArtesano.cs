using System;
using System.Collections.Generic;

#nullable disable

namespace QueryApi.Domain.Entities
{
    public partial class ContactoArtesano
    {
        public int IdC { get; set; }
        public long Telefono { get; set; }
        public string Correo { get; set; }
        public int ArtesanosIdA { get; set; }

        public virtual Artesano ArtesanosIdANavigation { get; set; }
    }
}
