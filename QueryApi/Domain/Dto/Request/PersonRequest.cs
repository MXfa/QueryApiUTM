using System;
using System.Collections.Generic;


namespace Domain.Dto.Request
{
   public record PersonRequest(int Age, char? Gender, string City);
    
}