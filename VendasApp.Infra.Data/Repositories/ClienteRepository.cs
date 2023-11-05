using VendasApp.Application.Services.Database.Interfaces;
using VendasApp.Domain.Entities;

namespace VendasApp.Infra.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly VendasAppContext _appContext;

        public ClienteRepository(VendasAppContext appContext)
        {
            _appContext = appContext;
        }

        public void Create(Cliente cliente)
        {
            _appContext.Clientes.Add(cliente);
            _appContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _appContext.Clientes.Remove(GetById(id));
            _appContext.SaveChanges();
        }

        public List<Cliente> GetAll()
        {
            return _appContext.Clientes.ToList();
        }

        public Cliente GetById(int id)
        {
            return _appContext.Clientes.Where(t => t.Id == id).FirstOrDefault();
        }

        public Cliente GetByName(string name)
        {
            return _appContext.Clientes.Where(t => t.Nome == name).FirstOrDefault();
        }

        public void Update(Cliente cliente)
        {
            _appContext.Clientes.Update(cliente);
            _appContext.SaveChanges();
        }
    }
}