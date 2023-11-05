using VendasApp.Application.Services.Database.Interfaces;
using VendasApp.Domain.Entities;

namespace VendasApp.Application.Services.Database
{
    public class ItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public void Create(Item item)
        {
            _itemRepository.Create(item);
        }

        public void Update(Item item)
        {
            _itemRepository.Update(item);
        }

        public void Delete(int id)
        {
            _itemRepository.Delete(id);
        }

        public List<Item> GetAll()
        {
            return _itemRepository.GetAll();
        }

        public Item GetById(int id)
        {
            return _itemRepository.GetById(id);
        }

        public Item GetByNome(string name)
        {
            return _itemRepository.GetByNome(name);
        }
    }
}