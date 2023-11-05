using VendasApp.Domain.Entities;

namespace VendasApp.Application.Services.Database.Interfaces
{
    public interface IPedidoRepository
    {
        public Pedido Create(Pedido pedido);

        public Pedido Update(Pedido pedido);

        public void Delete(int id);

        public Pedido GetById(int id);

        public List<Pedido> GetByCliente(Cliente cliente);
    }
}