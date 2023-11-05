using Microsoft.AspNetCore.Mvc;
using VendasApp.Application.Services.Database;
using VendasApp.WebApi.Models.Usuario.Cadastro;

namespace VendasApp.WebApi.Controllers.Usuario
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public CadastroController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public ActionResult<object> Cadastrar([FromBody] CadastroRequest b)
        {
            var exists = _usuarioService.GetByUsername(b.Username);
            if (exists != null)
            {
                return BadRequest("User already exists");
            }

            Domain.Entities.Usuario user = new Domain.Entities.Usuario();
            user.Username = b.Username;
            user.Password = b.Password;
            user.Role = "user";
            _usuarioService.Create(user);
            return Ok("Usuario adicionado");
        }
    }
}