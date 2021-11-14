using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Controllers
{
    [Authorize("Admin")]
    public class UserController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;

        public UserController(UserManager<AppUser> userManager)
        {

            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AppUser>>> GetUsers()
        {
            var nonAdminUsers = await _userManager.GetUsersInRoleAsync("BasicUser");

            return nonAdminUsers.ToList();
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser()
        {

            return Ok();
        }
    }
}