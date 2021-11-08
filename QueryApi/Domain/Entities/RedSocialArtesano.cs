using System;
using System.Collections.Generic;

#nullable disable

namespace QueryApi.Domain.Entities
{
    public partial class RedSocialArtesano
    {
        public int IdRs { get; set; }
        public string Nombre { get; set; }
        public int ArtesanosIdA { get; set; }

        public virtual Artesano ArtesanosIdANavigation { get; set; }
    }
}
