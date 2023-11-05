using VendasApp.Domain.Entities;

namespace VendasApp.Application.Services.Database.Interfaces
{
    public interface IItemRepository
    {
        public Item Create(Item item);

        public Item Update(Item item);

        public void Delete(int id);

        public List<Item> GetAll();

        public Item GetById(int id);

        public Item GetByNome(string name);
    }
}