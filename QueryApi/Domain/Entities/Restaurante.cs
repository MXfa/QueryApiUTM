using System;
using System.Collections.Generic;

#nullable disable

namespace QueryApi.Domain.Entities
{
    public partial class Restaurante
    {
        public Restaurante()
        {
            ContactoRsts = new HashSet<ContactoRst>();
            UbicacionRsts = new HashSet<UbicacionRst>();
        }

        public int Id { get; set; }
        public int Nombre { get; set; }
        public int Descripcion { get; set; }

        public virtual ICollection<ContactoRst> ContactoRsts { get; set; }
        public virtual ICollection<UbicacionRst> UbicacionRsts { get; set; }
    }
}
