using VendasApp.Domain.Entities;

namespace VendasApp.Application.Services.Database.Interfaces
{
    public interface IClienteRepository
    {
        public void Create(Cliente cliente);

        public void Update(Cliente cliente);

        public void Delete(int id);

        public List<Cliente> GetAll();

        public Cliente GetById(int id);

        public Cliente GetByName(string name);
    }
}