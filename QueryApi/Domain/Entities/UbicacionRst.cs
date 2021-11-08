using System;
using System.Collections.Generic;

#nullable disable

namespace QueryApi.Domain.Entities
{
    public partial class UbicacionRst
    {
        public int Id { get; set; }
        public string Ubicacion { get; set; }
        public string Geoubicacion { get; set; }
        public int RestaurantesIdRts { get; set; }

        public virtual Restaurante RestaurantesIdRtsNavigation { get; set; }
    }
}
