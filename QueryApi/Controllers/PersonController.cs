using System.ComponentModel.DataAnnotations;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using QueryApi.Repositories;
using QueryApi.Domain.Entities;
using QueryApi.Domain.Dto.Response;
using System.Collections.Generic;
using System.Linq;
using Domain.Dto.Request;

//*actual
namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        [HttpGet]
    
        public IActionResult GetAll()
        {
          var repository = new PersonRepository();
          var persons = repository.GetById2(); //      |||| /// persons rsguarda el repositorio de persona
          var response = CreateDtoFromObject(persons);
          return Ok(response);

        } 

        [HttpGet]
       [Route("EncontrarA")]
        public IActionResult GetByFilter([FromBody]Person person)
        {
          var repository = new PersonRepository();
         var persona = CreateDtoFromObject(person);
         var personas = repository.GetByFilter4(person);
         var respuesta = personas.Select(x=> CreateDtoFromObject(x));

          return Ok(respuesta);
           //return Ok($"La persona ingresada es {person.FirstName}{person.LastName} y vive en {person.Address.City}");
        } 

private Person CreateObjectFromDto(PersonRequest dto)
{
   if(dto.Age<= 0 && dto.Gender == null && string.IsNullOrEmpty(dto.City))
            return null;
            var person = new Person(
                Id:0,
                FirstName:string.Empty,
                LastName:string.Empty,
                Email:string.Empty,
                Gender: dto.Gender,
                Age: dto.Age,
                Job: string.Empty,
                Address: new PersonAddress(
                    Street : string.Empty,
                    Number : string.Empty,
                    ZipCode : string.Empty,
                    City: dto.City
                )
            );
            return person;
}
        private PersonResponDto CreateDtoFromObject(Person personsw)
        {
            
            var personDto = new PersonResponDto(
            Nombre:$"{personsw.FirstName}{personsw.LastName}",   
            Correo: personsw.Email,
           
            //CodigoPostal:personsw?.Address.ZipCode // ? indica que si el valor es diferente de nulo lo aplicque y si no asigne el valor por defecto
            CodigoPostal:personsw.Address == null ? string.Empty : personsw.Address.City


            );
            
            return personDto;

        }



      }

      

    
}