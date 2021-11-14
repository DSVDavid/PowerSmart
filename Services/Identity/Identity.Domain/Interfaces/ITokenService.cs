using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Domain.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(AppUser user, string userRole);
    }
}