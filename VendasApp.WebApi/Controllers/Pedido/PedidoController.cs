using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VendasApp.Application.Services.Database;
using VendasApp.Domain.Entities;
using VendasApp.WebApi.Models.Pedido;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VendasApp.WebApi.Controllers.Pedido
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private PedidoService pedidoService;
        private ClienteService clienteService;
        private UsuarioService usuarioService;

        public PedidoController(PedidoService pedidoService, ClienteService clienteService, UsuarioService usuarioService)
        {
            this.pedidoService = pedidoService;
            this.clienteService = clienteService;
            this.usuarioService = usuarioService;
        }

        // GET: api/<PedidoController>
        [HttpGet("/api/Cliente/{idCliente}")]
        public ActionResult<List<PedidoResponse>> GetByCliente(int idCliente)
        {
            var cliente = clienteService.GetById(idCliente);
            List<PedidoResponse> result = new();
            List<Domain.Entities.Pedido> pedidos = pedidoService.GetByCliente(cliente);
            if (pedidos.Count > 0)
            {
                pedidos.ForEach(t =>
                {
                    PedidoResponse p = new(t);
                    result.Add(p);
                });
            }
            return Ok(result);
        }

        // GET api/<PedidoController>/5
        [HttpGet("{id}")]
        public ActionResult<PedidoResponse> GetById(int id)
        {
            var a = new PedidoResponse(pedidoService.GetById(id));
            return Ok(a);
        }

        // POST api/<PedidoController>
        [HttpPost]
        public ActionResult<PedidoResponse> Post([FromBody] PedidoRequest pedido)
        {
            Domain.Entities.Pedido p = new();
            p = pedidoService.Create(p);
            p.IdCliente = pedido.IdCliente;
            p.IdVendedor = usuarioService.GetByUsername(this.User.Claims.ToList()[0].Value).Id;
            p.Data = DateTime.Now.ToLocalTime();
            if (pedido.Itens.Count > 0)
            {
                pedido.Itens.ForEach(i =>
                {
                    ItemPedido it = new();
                    it.IdItem = i.IdItem;
                    it.IdPedido = p.Id;
                    it.Quantidade = i.Quantidade;
                    p.ItensPedido.Add(it);
                });
            }

            p = pedidoService.Update(p);
            var response = new PedidoResponse(p);
            return Ok(response);
        }

        // DELETE api/<PedidoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            pedidoService.Delete(id);
            return NoContent();
        }
    }
}