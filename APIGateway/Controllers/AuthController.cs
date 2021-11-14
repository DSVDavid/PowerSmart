using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using APIGateway.Dtos;
using APIGateway.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace APIGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly string _identityApi;
        private readonly ITokenService _tokenService;

        public AuthController(IHttpClientFactory clientFactory,
         IConfiguration config, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _clientFactory = clientFactory;
            _identityApi = config.GetSection("Services")["IdentityService:Api"];
        }

        [HttpPost("login")]
        public async Task<ActionResult<SignedInUserDto>> AuthUser(UserLoginDto userLoginDto)
        {

            using var client = _clientFactory.CreateClient();

            var data = JsonSerializer.Serialize(userLoginDto);
            var content = new StringContent(data, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(_identityApi + "account/login", content);

            try
            {

                response.EnsureSuccessStatusCode();

                var respContent = await response.Content.ReadAsStringAsync();

                var userClaims = JsonSerializer.Deserialize<UserClaimsDto>(respContent, new JsonSerializerOptions{
                    PropertyNameCaseInsensitive = true
                });

                return new SignedInUserDto
                {
                    UserName = userClaims.UserName,
                    Token = _tokenService.GenerateToken(userClaims.UserName, userClaims.UserRole)
                };



            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

    }
}