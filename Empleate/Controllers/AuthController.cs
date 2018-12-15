using Empleate.Models;
using Empleate.Models.AuthModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Empleate.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, 
            RoleManager<Role> roleManager, IConfiguration configuration) {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost, Route("signin")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Login model invalid" });
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {               
                return BadRequest(new { message = "User doesn't exist" });
            }
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                string tokenString = GenerateJSONWebToken(user);
                return Ok(new { token = tokenString });
            }
            return BadRequest(new { message = "Username or password invalid" });
        }

        private string GenerateJSONWebToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var roles = _userManager.GetRolesAsync(user);
            roles.Wait();
            IList<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            foreach (string rol in roles.Result)
            {
                claims.Add(new Claim(ClaimTypes.Role, rol));
            }
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                 _configuration["Jwt:Issuer"],
                 claims,
                 expires: DateTime.Now.AddMinutes(60),
                 signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost, Route("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Register model invalid" });
            }
            var user = new User { UserName= model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, model.Role);
                return Ok(new { message = "Account created", user = new { email = user.Email } });
            }
            return BadRequest(new { message = "Oops" });
        }
    }
}