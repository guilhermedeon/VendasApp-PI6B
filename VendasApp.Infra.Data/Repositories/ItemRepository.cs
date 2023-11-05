using VendasApp.Application.Services.Database.Interfaces;
using VendasApp.Domain.Entities;

namespace VendasApp.Infra.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly VendasAppContext _appContext;

        public ItemRepository(VendasAppContext appContext)
        {
            _appContext = appContext;
        }

        public Item Create(Item item)
        {
            var a = _appContext.Items.Add(item);
            _appContext.SaveChanges();
            return a.Entity;
        }

        public void Delete(int id)
        {
            _appContext.Items.Remove(GetById(id));
            _appContext.SaveChanges();
        }

        public List<Item> GetAll()
        {
            return _appContext.Items.ToList();
        }

        public Item GetById(int id)
        {
            return _appContext.Items.Where(t => t.Id == id).FirstOrDefault();
        }

        public Item GetByNome(string name)
        {
            return _appContext.Items.Where(t => t.Nome == name).FirstOrDefault();
        }

        public Item Update(Item item)
        {
            var a = _appContext.Items.Update(item);
            _appContext.SaveChanges();
            return a.Entity;
        }
    }
}