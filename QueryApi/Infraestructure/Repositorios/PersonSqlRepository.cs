using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using QueryApi.Domain.Entities;
using QueryApi.Repositories;
using QueryApi.Infraestructure.Data;


namespace Infraestructure.Data
{
    public class PersonSqlRepository
    {
        private readonly cnxContext _context;

        public Person GetById(int id)
        {
            var query = _context.People.FirstOrDefault(p=>p.Id == id);
            return query;

        }

        public IEnumerable<Person> GetByFilter(Person person)
        {
           
                if (!string.IsNullOrEmpty(person.FirstName))
                    query = query.Where(x => x.FirstName.Contains(person.FirstName));

                if (person.Age > 0)
                    query = query.Where(x => x.Age == person.Age);

    
                if (!string.IsNullOrEmpty(person.Job))
                    query = query.Where(x => x.Job == person.Job);


                if (person.Gender != null)
                    query = query.Where(x => x.Gender == person.Gender);

            if (person.Address != null && !string.IsNullOrEmpty(person.Address.City))
           query = query.Where(x => x.Address.City == person.Address.City);
    return query;
        }

    }
}