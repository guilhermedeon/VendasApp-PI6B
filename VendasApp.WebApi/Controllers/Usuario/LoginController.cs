using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using VendasApp.Application.Services.Database;
using VendasApp.WebApi.Models.Usuario.Login;

namespace VendasApp.WebApi.Controllers.Usuario
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UsuarioService _usuarioService;

        public LoginController(IConfiguration configuration, UsuarioService _usuarioService)
        {
            _configuration = configuration;
            this._usuarioService = _usuarioService;
        }

        [HttpPost]
        public ActionResult<object> Authenticate([FromBody] LoginRequest login)
        {
            var loginResponse = new LoginResponse { };
            LoginRequest loginrequest = new()
            {
                UserName = login.UserName.ToLower(),
                Password = login.Password
            };

            bool isUsernamePasswordValid = false;

            if (login != null)
            {
                Domain.Entities.Usuario user = _usuarioService.GetByUsername(loginrequest.UserName);

                if (user == null)
                {
                    return NotFound("Username not found");
                }
                // make await call to the Database to check username and password. here we only checking if password value is admin
                isUsernamePasswordValid = loginrequest.Password == user.Password ? true : false;
            }
            // if credentials are valid
            if (isUsernamePasswordValid)
            {
                string token = CreateToken(loginrequest.UserName);

                loginResponse.Token = token;
                loginResponse.responseMsg = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK
                };

                //return the token
                return Ok(new { loginResponse });
            }
            else
            {
                // if username/password are not valid send unauthorized status code in response
                return BadRequest("Password Invalid!");
            }
        }

        private string CreateToken(string username)
        {
            List<Claim> claims = new()
            {
                //list of Claims - we only checking username - more claims can be added.
                new Claim("username", Convert.ToString(username)),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: cred
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}