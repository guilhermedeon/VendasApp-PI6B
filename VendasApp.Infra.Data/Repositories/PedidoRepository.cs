using VendasApp.Application.Services.Database.Interfaces;
using VendasApp.Domain.Entities;

namespace VendasApp.Infra.Data.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly VendasAppContext _appContext;

        public PedidoRepository(VendasAppContext appContext)
        {
            _appContext = appContext;
        }

        public void Create(Pedido pedido)
        {
            _appContext.Pedidos.Add(pedido);
            _appContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _appContext.Pedidos.Remove(GetById(id));
            _appContext.SaveChanges();
        }

        public List<Pedido> GetByCliente(Cliente cliente)
        {
            return _appContext.Pedidos.Where(t => t.IdCliente == cliente.Id).ToList();
        }

        public Pedido GetById(int id)
        {
            return _appContext.Pedidos.Where(t => t.Id == id).FirstOrDefault();
        }

        public void Update(Pedido pedido)
        {
            _appContext.Pedidos.Update(pedido);
            _appContext.SaveChanges();
        }
    }
}