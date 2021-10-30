using System;

namespace QueryApi.Domain.Entities
{
    public record Person(int Id, string FirstName, string LastName, string Email, char? Gender, string Job, int Age, PersonAddress Address);

}
