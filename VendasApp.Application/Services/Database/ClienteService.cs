using VendasApp.Application.Services.Database.Interfaces;
using VendasApp.Domain.Entities;

namespace VendasApp.Application.Services.Database
{
    public class ClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository _clienteRepository)
        {
            this._clienteRepository = _clienteRepository;
        }

        public Cliente Create(Cliente cliente)
        {
            return _clienteRepository.Create(cliente);
        }

        public Cliente Update(Cliente cliente)
        {
            return _clienteRepository.Update(cliente);
        }

        public void Delete(int id)
        {
            _clienteRepository.Delete(id);
        }

        public List<Cliente> GetAll()
        {
            return _clienteRepository.GetAll();
        }

        public Cliente GetById(int id)
        {
            return _clienteRepository.GetById(id);
        }

        public Cliente GetByName(string name)
        {
            return _clienteRepository.GetByName(name);
        }
    }
}