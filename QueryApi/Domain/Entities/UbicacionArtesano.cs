using System;
using System.Collections.Generic;

#nullable disable

namespace QueryApi.Domain.Entities
{
    public partial class UbicacionArtesano
    {
        public int IdU { get; set; }
        public string Ubicacion { get; set; }
        public string Geoubicacion { get; set; }
        public int ArtesanosIdA { get; set; }

        public virtual Artesano ArtesanosIdANavigation { get; set; }
    }
}
