using System;

namespace QueryApi.Domain.Entities
{
    public record PersonAddress(string Street, string Number, string ZipCode, string City);
    
}