using Microsoft.EntityFrameworkCore;
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

        public Pedido Create(Pedido pedido)
        {
            var p = _appContext.Pedidos.Add(pedido);
            _appContext.SaveChanges();
            return p.Entity;
        }

        public void Delete(int id)
        {
            _appContext.Pedidos.Remove(GetById(id));
            _appContext.SaveChanges();
        }

        public List<Pedido> GetByCliente(Cliente cliente)
        {
            var a = _appContext.Pedidos
                .Include(t => t.ItensPedido)
                .ThenInclude(t => t.IdItemNavigation)
                .Where(t => t.IdCliente == cliente.Id).ToList();
            return a;
        }

        public Pedido GetById(int id)
        {
            return _appContext.Pedidos.Include(t => t.ItensPedido)
                .ThenInclude(t => t.IdItemNavigation)
                .Where(t => t.Id == id)
                .FirstOrDefault();
        }

        public Pedido Update(Pedido pedido)
        {
            var a = _appContext.Pedidos.Update(pedido);
            _appContext.SaveChanges();
            return a.Entity;
        }
    }
}