using System;

namespace QueryApi.Domain.Dto
{
    
        public record PersonFilterDto(int MinAge, int MaxAge, string Job, int Age, string Name, string City);
    
}