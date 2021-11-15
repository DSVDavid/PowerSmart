using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Dtos
{
    public class SignedInUserCredsDto
    {
        public string UserName { get; internal set; }
        public string Token { get; internal set; }
    }
}