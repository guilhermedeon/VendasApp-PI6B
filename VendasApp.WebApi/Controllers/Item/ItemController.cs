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
        public ActionResult<List<ItemResponse>> GetAll()
        {
            var result = new List<ItemResponse>();
            var itens = _itemService.GetAll();
            if (itens.Count > 0)
            {
                itens.ForEach(item =>
                {
                    ItemResponse it = new(item);
                    result.Add(it);
                });
            }

            return Ok(result);
        }

        // GET api/<ItemController>/5
        [HttpGet("{id}")]
        public ActionResult<ItemResponse> GetById(int id)
        {
            return Ok(new ItemResponse(_itemService.GetById(id)));
        }

        // POST api/<ItemController>
        [HttpPost]
        public ActionResult<ItemResponse> Post([FromBody] ItemRequest item)
        {
            Domain.Entities.Item it = new();
            it.Nome = item.Nome;
            it.Unidade = item.Unidade;
            it.ValorUnitario = item.ValorUnitario;
            var a = _itemService.Create(it);
            return Ok(new ItemResponse(a));
        }

        // PUT api/<ItemController>/5
        [HttpPut("{id}")]
        public ActionResult<ItemResponse> Put(int id, [FromBody] ItemRequest item)
        {
            var it = _itemService.GetById(id);
            it.Nome = item.Nome;
            it.Unidade = item.Unidade;
            it.ValorUnitario = item.ValorUnitario;
            var a = _itemService.Update(it);
            return Ok(new ItemResponse(a));
        }

        // DELETE api/<ItemController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _itemService.Delete(id);
            return NoContent();
        }
    }
}