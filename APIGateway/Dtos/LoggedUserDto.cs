using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Dtos
{
    public class LoggedUserDto
    {
        public string UserName { get; internal set; }
        
        public string Token { get; internal set; }
        
        
    }
}