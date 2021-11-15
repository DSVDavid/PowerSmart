using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.API.Dtos;
using Identity.Domain;
using Identity.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Identity.API.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly ITokenService _tokenService;
      
        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> UserLogIn(LogInDto logInDto)
        {

            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Email == logInDto.Email);

            if (user == null) return BadRequest();

            var signInResult = await _userManager.CheckPasswordAsync(user, logInDto.Password);

            if (signInResult)
            {
                var userRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

                return Ok(new SignedInUserCredsDto
                {
                    UserName = user.UserName,
                    Token = _tokenService.GenerateToken(user,userRole)
                });
            }

            return BadRequest();
        }
    }
}