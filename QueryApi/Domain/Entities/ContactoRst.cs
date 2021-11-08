using System;
using System.Collections.Generic;

#nullable disable

namespace QueryApi.Domain.Entities
{
    public partial class ContactoRst
    {
        public int Id { get; set; }
        public int Telefono { get; set; }
        public int RestaurantesIdRts { get; set; }

        public virtual Restaurante RestaurantesIdRtsNavigation { get; set; }
    }
}
