using System;
using Microsoft.AspNetCore.Identity;

namespace Identity.Domain
{
    public class AppUserRole : IdentityUserRole<Guid>
    {
        public AppUser User { get; set; }


    }
}