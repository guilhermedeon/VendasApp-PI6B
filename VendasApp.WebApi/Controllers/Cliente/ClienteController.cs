using Microsoft.AspNetCore.Mvc;
using VendasApp.Application.Services.Database;
using VendasApp.WebApi.Models.Cliente;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VendasApp.WebApi.Controllers.Cliente
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService clienteService;

        public ClienteController(ClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public ActionResult<List<ClienteResponse>> GetAll()
        {
            var clientes = clienteService.GetAll();
            var response = new List<ClienteResponse>();
            if (clientes.Count > 0)
            {
                clientes.ForEach(t =>
                {
                    response.Add(new ClienteResponse(t));
                });
            }
            return Ok(response);
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public ActionResult<ClienteResponse> GetById(int id)
        {
            return Ok(new ClienteResponse(clienteService.GetById(id)));
        }

        // POST api/<ClienteController>
        [HttpPost]
        public ActionResult<ClienteResponse> Post([FromBody] ClienteRequest request)
        {
            var cliente = new Domain.Entities.Cliente
            {
                Nome = request.Nome,
                Endereco = request.Endereco,
                Documento = request.Documento,
                Telefone = request.Telefone
            };
            return Ok(new ClienteResponse(clienteService.Create(cliente)));
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public ActionResult<ClienteResponse> Put(int id, [FromBody] ClienteRequest request)
        {
            var cliente = clienteService.GetById(id);
            cliente.Nome = request.Nome;
            cliente.Documento = request.Documento;
            cliente.Telefone = request.Telefone;
            cliente.Endereco = request.Endereco;
            cliente = clienteService.Update(cliente);
            return Ok(new ClienteResponse(cliente));
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            clienteService.Delete(id);
            return NoContent();
        }
    }
}