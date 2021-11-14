using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(string userName, string userRole);
    }
}