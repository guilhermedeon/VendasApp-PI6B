using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VendasApp.Application.Services.Database;
using VendasApp.WebApi.Models.Item;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VendasApp.WebApi.Controllers.Item
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly ItemService _itemService;

        public ItemController(ItemService itemService)
        {
            _itemService = itemService;
        }

        // GET: api/<ItemController>
        [HttpGet]
        public List<Domain.Entities.Item> GetAll()
        {
            return _itemService.GetAll();
        }

        // GET api/<ItemController>/5
        [HttpGet("{id}")]
        public Domain.Entities.Item GetById(int id)
        {
            return _itemService.GetById(id);
        }

        // POST api/<ItemController>
        [HttpPost]
        public void Post([FromBody] CreateItemDAO item)
        {
            Domain.Entities.Item it = new();
            it.Nome = item.Nome;
            it.Unidade = item.Unidade;
            it.ValorUnitario = item.ValorUnitario;
            _itemService.Create(it);
        }

        // PUT api/<ItemController>/5
        [HttpPut]
        public void Put([FromBody] ItemDAO item)
        {
            var it = _itemService.GetById(item.Id);
            it.Nome = item.Nome;
            it.Unidade = item.Unidade;
            it.ValorUnitario = item.ValorUnitario;
            _itemService.Update(it);
        }

        // DELETE api/<ItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _itemService.Delete(id);
        }
    }
}