using VendasApp.Domain.Entities;

namespace VendasApp.Application.Services.Database.Interfaces
{
    public interface IPedidoRepository
    {
        public void Create(Pedido pedido);

        public void Update(Pedido pedido);

        public void Delete(int id);

        public Pedido GetById(int id);

        public List<Pedido> GetByCliente(Cliente cliente);
    }
}