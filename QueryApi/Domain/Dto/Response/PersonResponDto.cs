using System;

namespace QueryApi.Domain.Dto.Response
{
   
//esta es mi abstraccion pra una persona, y sera la estructura con la que respondere cuando me pregunten por una persona. Con esto ocultamos la estructura de mi objeto de dominio Person, elegiendo como quiero mostrar la informacion
        public record PersonResponDto(string Nombre, string Correo, string CodigoPostal);

   
}