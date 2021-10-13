using System.Collections;
using Microsoft.AspNetCore.Mvc;
using QueryApi.Repositories;
using QueryApi.Domain;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
          var repository = new PersonRepository();
          var persons = repository.GetAll();
          return Ok(persons);
        } 

     
        [HttpGet]
        // [Route("EncontrarA")]
      [Route("EncontrarA/{v_name}")]
      public IActionResult GetEncontrarPersona(string v_name)
      {
         var repository = new PersonRepository();
          var persons = repository.GetField(v_name);
          return Ok(persons);
      }

      [HttpGet]
      [Route("Consulta/xgenero/{Genero}")]
      public IActionResult GetGenero(char Genero)
      {
      var repository = new PersonRepository();
      var persons = repository.GetByGender(Genero);
      return Ok(persons);
      }

      [HttpGet]
      [Route("Consulta/xedad/{Edad}")]
      public IActionResult GetEdad(int Edad)
      {
      var repository = new PersonRepository();
      var persons = repository.GetByMaxAge(Edad);
      return Ok(persons);
      }

      [HttpGet]
      [Route("Consulta/puestodiferenteA/{puesto}")]
      public IActionResult GetPuesto(string puesto)
      {
        var repository = new PersonRepository();
        var persons = repository.GetDiferences(puesto);
        return Ok(persons);
      }
    
      [HttpGet]
      [Route("Consulta/todoslospuestos/")]
      public IActionResult Getjobs()
      {
          var repository = new PersonRepository();
          var persons = repository.Getjobs();
          return Ok(persons);
      } 


       [HttpGet]
      [Route("Consulta/unnombrexparticula/{particula}")]
      public IActionResult GetNombreParticula(string particula)
      {
        var repository = new PersonRepository();
        var persons = repository.GEtContains(particula);
        return Ok(persons);
      }


       [HttpGet] // 
       [Route("Consulta/xRangodeEdad")]
        public IActionResult GetRangoEdad(double min, double max)
        {
          var mn=min;
          var mx=max;
          var repository = new PersonRepository();
          var persons = repository.GetByRangeAge(mn, mx);
          return Ok(persons);
        }


         [HttpGet]
      [Route("Consulta/PersonasConPuestoAz/{puestoaz}")]
      public IActionResult GetPersonasPuestoAz(string puestoaz)
      {
        var repository = new PersonRepository();
        var persons = repository.GetPersonOrdered(puestoaz);
        return Ok(persons);
      }


      [HttpGet]
      [Route("Consulta/PersonasxEdad/{puestoza}")]
      public IActionResult GetPersonasPuestoZa(string puestoza)
      {
        var repository = new PersonRepository();
        var persons = repository.GetPersonOrderedDesc(puestoza);
        return Ok(persons);
      }

      [HttpGet]
      [Route("Consulta/CuantosSon/{edadpersona}")]
      public IActionResult GetCuantosEdad(int edadpersona)
      {

      var repository = new PersonRepository();
      var persons = repository.CountPeople(edadpersona);
      return Ok(persons);
      }

      [HttpGet]
      [Route("Consulta/SitrabajaAqui/{empleado}")]
      public IActionResult GetEmpleado(string empleado)
      {
        var repository = new PersonRepository();
        var persons = repository.ExistPerson(empleado);
        return Ok(persons);
      }


      [HttpGet]
      [Route("Consulta/AnyPerson/{apellido}")]
      public IActionResult GetPersonaApellido(string apellido)
      {
        var repository = new PersonRepository();
        var persons = repository.AnyPerson(apellido);
        return Ok(persons);
      }
    
   [HttpGet]
      [Route("Consulta/PersonaxId/{Identificador}")]
      public IActionResult GetPersonaId(int Identificador) 
      {

      var repository = new PersonRepository();
      var persons = repository.GetPerson(Identificador);
      return Ok(persons);
      }

      [HttpGet]
      [Route("Consulta/PersonaxIdRandom")]
      public IActionResult GetPersonaIdRm()
      {
        var repository = new PersonRepository();
        var persons = repository.GetPerson2();
        return Ok(persons);
      }


       [HttpGet]
      [Route("Consulta/PuestosTake/{estepuesto}")]
      public IActionResult GetPuestosTake(string estepuesto)
      {
        var repository = new PersonRepository();
        var persons = repository.TakePerson0(estepuesto);
        return Ok(persons);
      }

      [HttpGet]
      [Route("Consulta/PersonaxIndicadores")]
      public IActionResult GetPersonaxIndicadores(int jobtake, string personjob) 
      {

      var repository = new PersonRepository();
      var persons = repository.TakeLastPerson(jobtake, personjob);
      return Ok(persons);
      }




      [HttpGet]
      [Route("Consulta/PuestosxIndicadores")]
      public IActionResult puestoxIndicadores(int skipjob, string jobempleado) 
      {

      var repository = new PersonRepository();
      var persons = repository.SkipPerson(skipjob, jobempleado);
      return Ok(persons);
      }

      [HttpGet]
      [Route("Consulta/PuestosEmpxIndicadores")]
      public IActionResult puestoxIndicadores(string puestoEmp, int skp, int tke) 
      {

      var repository = new PersonRepository();
      var persons = repository.SkipTakePerson(puestoEmp, skp, tke);
      return Ok(persons);
      }

      
    }
}