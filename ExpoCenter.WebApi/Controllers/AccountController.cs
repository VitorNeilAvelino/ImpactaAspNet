using ExpoCenter.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ExpoCenter.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IConfiguration configuration;
        private readonly UserManager<ApplicationUser> userManager; // pode ser usado para recuperar as claims do usuário e adicionar no token.

        public AccountController(SignInManager<ApplicationUser> signInManager, IConfiguration configuration, UserManager<ApplicationUser> userManager)
        {
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.userManager = userManager;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserToken>> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: false);            

            if (result.Succeeded)
            {
                return Ok(BuildToken(model));
            }

            ModelState.AddModelError(string.Empty, "Login inválido.");
            return BadRequest(ModelState);
        }

        private UserToken BuildToken(LoginModel userInfo)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, "Agente")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            
            // tempo de expiração do token: 1 hora
            var expiration = DateTime.UtcNow.AddHours(1);
            
            JwtSecurityToken token = new JwtSecurityToken(
               issuer: null,
               audience: null,
               claims: claims,
               expires: expiration,
               signingCredentials: creds);
            
            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}