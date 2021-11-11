using BlazorTodoList.Api.Entities;
using BlazorTodoList.ViewModel.LoginViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTodoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly SignInManager<User> _signIn;

        public LoginController(IConfiguration config, SignInManager<User> signIn)
        {
            _config = config;
            _signIn = signIn;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest login)
        {
            var isSignIn = await _signIn.PasswordSignInAsync(login.UserName, login.Password, false, false);

            if (!isSignIn.Succeeded)
                return BadRequest(new LoginResponse() { Error = "Tên tài khoản hoặc mật khẩu không đúng" });

            var token = GenerateJSONWebToken(login);
            return Ok(new LoginResponse() { Success = true, Token = token });
        }

        private string GenerateJSONWebToken(LoginRequest login)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,login.UserName)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
