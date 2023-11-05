using VendasApp.Domain.Entities;

namespace VendasApp.Application.Services.Database.Interfaces
{
    public interface IItemRepository
    {
        public void Create(Item item);

        public void Update(Item item);

        public void Delete(int id);

        public List<Item> GetAll();

        public Item GetById(int id);

        public Item GetByNome(string name);
    }
}