﻿using VendasApp.Application.Services.Database.Interfaces;
using VendasApp.Domain.Entities;

namespace VendasApp.Application.Services.Database
{
    public class PedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public Pedido Create(Pedido pedido)
        {
            return _pedidoRepository.Create(pedido);
        }

        public Pedido Update(Pedido pedido)
        {
            return _pedidoRepository.Update(pedido);
        }

        public void Delete(int id)
        {
            _pedidoRepository.Delete(id);
        }

        public Pedido GetById(int id)
        {
            return _pedidoRepository.GetById(id);
        }

        public List<Pedido> GetByCliente(Cliente cliente)
        {
            return _pedidoRepository.GetByCliente(cliente);
        }
    }
}