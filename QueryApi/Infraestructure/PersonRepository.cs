using System.CodeDom.Compiler;
using System.Globalization;
using System.Runtime.ExceptionServices;
using System.Xml;
using Microsoft.Win32;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Security.Permissions;
using System.Security.AccessControl;
using System.Diagnostics;
using System.Reflection;
using System.IO.Pipes;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;
using QueryApi.Domain;
using System.Threading.Tasks;

namespace QueryApi.Repositories
{
    public class PersonRepository
    {
       List<Person> _persons;

        public PersonRepository()
        {
            var fileName = "dummy.data.queries.json";
            if(File.Exists(fileName))
            {
                var json = File.ReadAllText(fileName);
                _persons = JsonSerializer.Deserialize<IEnumerable<Person>>(json).ToList();
            }
        }

        // retornar todos los valores
        public IEnumerable<Person> GetAll()//ok
        {
            var query = _persons.Select(person => person); //_person.Select = origen de datos | person = iterador o apuntador (indica el elemento a tener)  | return devuelve el resultado 
            return query;
        }

        
// para trabajar consultas: primero se declara un metodo y despues se contruye una consulta linq


        // retornar campos especificos  
        public IEnumerable<Object> GetField(string v_name)//ok
        {
            //origen de datos= _person.Select | iterador = person | new ....  elememtos a recepcionar |||| //==(igual) es diferente a ===(identico)
            var query = _persons.Where(person => person.LastName == v_name).Select(person => new { 
                NombreCompleto = $"{person.FirstName} { person.LastName}",
                AnioNacimiento = DateTime.Now.AddYears(person.Age * -1).Year,
               CorreoElectronico= person.Email

            });
            return query;
        }

        // retornar elementos que sean iguales
         // un iterador representa un objeto segun coleccion de dato   ||  una  sentencia esta integrada por una coleccion de datos (atributos de la clse Person) + operacion + iterador
        public IEnumerable<Person> GetByGender(char Genero)//ok
        {
            var gender = Genero;
            var query = _persons.Where(person => person.Gender == gender);  //person = iterador, || coleccion || where neesita un indicador  || 
            return query;
        }


         public IEnumerable<Person> GetByMaxAge(int Edad)//ok
        {
            var age= Edad;
            var query = _persons.Where(person => person.Age <= age);
            return query;
        }

  // retornar valores entre un rango
       public IEnumerable<Person> GetByRangeAge(double min, double max)//ok
        {
            var minAge = min;
            var maxAge = max;

            var query = _persons.Where(person => person.Age >= minAge && person.Age <= maxAge); // && es equivalente a decir ó
            return query;
        
        }


           // Retornar elementos que sean diferentes
        public IEnumerable<Person> GetDiferences(string puesto)//ok
        {
            var job = puesto;
            var query = _persons.Where (person => person.Job != job);
            return query;

        }

        public IEnumerable<string> Getjobs()//OK
        {
            
        var query = _persons.Select(person => person.Job).Distinct(); // Distinct hace que el iterador compare en cada instancia del objeto (Person) y devuelve los valores existentes sin que se repitan y los dtos devueltos son de tipo cadena
        return query;
        }

        // retornar valores que contengan
        
        public IEnumerable<Person> GEtContains(string particula) //ok // devuelve los registros que en el campo Nombre contenga "ar"
        {
        var partName = particula;
        var query = _persons.Where(person => person.FirstName.Contains(partName)
        );
        return query;
        }

        public IEnumerable<Person> GetByAges()//pdt
        {
           var ages = new List<int> {15,25,35}; 
           var query = _persons.Where(person => ages.Contains(person.Age));
        return query;
        }


      

          // retornar elementos ordenados
        public IEnumerable<Person> GetPersonOrdered(string puestoaz)//ok
        {
            var job = puestoaz;
            var query = _persons.Where(person => person.Job == job)
                        .OrderBy(person=>person.LastName);
                            return query;
        }
        
       public IEnumerable<Person> GetPersonOrderedDesc(string puestoza)//ok
        {
            var job = puestoza;
            var query = _persons.Where(person => person.Job == job)
                                .OrderByDescending(person => person.Age);
            return query;
        }

        // retorno cantidad de elementos
        
        public int CountPeople(int edadpersona)//ok
        {
        var age = edadpersona;
        var query = _persons.Count(person => person.Age == age);
        return query;
        }
   

   /////////////////////////////////////////


        // Evalua si un elemento existe
        public bool ExistPerson(string empleado) //ok
        {
            var lastName = empleado;
            var query = _persons.Exists(person => person.LastName == lastName); // Exists nos devuelve devuelve un booleano mientras que where nos devuelve una coleccion de elementos. 
            return query; // nos devuelve un valor booleano
        }

        public bool ExistPerson2()
        {
            var lastName = "de Mullett";
            var query = _persons.Exists(p => p.LastName == lastName);
            return query;
        }

        public bool AnyPerson(string apellido) //ok
        {
            var LastName=apellido;
            var query = _persons.Any(p => p.LastName == LastName); //any devuelve el primer valor del elemento que encuentre segun consulta.
            return query;
            
        }
        
        // retornar solo un elemento || al ser un elemento no hay necesidad de usar el tipo de dato IEnumerable
        public Person GetPerson(int Identificador) //ok
        {
            var id = Identificador;
            var query = _persons.FirstOrDefault(person => person.Id == id);
            return query; 
        }
        public Person GetPerson2() //ok
        {
            var generador = new Random(DateTime.Now.Millisecond); // devolvera un registro diferente cada vez que se ejecuta
            var id= generador.Next(1000);
            var query = _persons.FirstOrDefault(person => person.Id == id);
            return query;   // se retorna la informacion de un objeto y no de un arreglo

        }

        // retornar solamente unos elementos
       public IEnumerable<Person> TakePerson0(string estepuesto)  //ok
       {
           var job = estepuesto;
           //var take = 5;
           var query = _persons.Where(person => person.Job == job);
           return query;  // nos retorna todos los elmentos que en Job sean igual al job (13)
       }
       
        public IEnumerable<Person> TakePersons()
        {
            var job = "Physical Therapy Assistant";
            var take = 5;
            var query = _persons.Where(person => person.Job == job).Take(take);
            return query; // devuelve los primeros 5 elementos elementos que en Job sean igual a job
        }
        public IEnumerable<Person> TakeLastPerson(int jobtake, string personjob)//ok
        {
            var job = personjob;
            var take = jobtake;
            var query = _persons.Where(person => person.Job == job).TakeLast(take); /// se toman los tres ultimos
            return query;
        }
        // retornar elementos saltando posición

        public IEnumerable<Person> SkipPerson0() 
        {
            var job = "Professor";
            //var skip = 3;
            var query = _persons.Where(person => person.Job == job);
            return query; /// 
        }

        public IEnumerable<Person> SkipPerson(int skipjob, string jobempleado) //ok
        {
            var job = jobempleado;
            var skip = skipjob;
            var query = _persons.Where(person => person.Job == job).Skip(skip);
            return query; /// devuelve el valor siguiente, a partir del valor de skip, en esta caso muestra del cuarto registro en adelante
        }
        public IEnumerable<Person> SkipTakePerson(string puestoEmp, int skp, int tke) //ok
        {
            var job = puestoEmp;
            var skip = skp; // salta los primero 5 y toma los primeros 3 para mostrar en pantalla, el resto de registro no se muestra
            var take = tke;
            var query = _persons.Where(person => person.Job == job).Skip(skip).Take(take);
            return query;
        }









    }
}