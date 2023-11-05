using VendasApp.Domain.Entities;
using VendasApp.WebApi.Models.Item;

namespace VendasApp.WebApi.Models.Pedido
{
    public class ItemPedidoResponse
    {
        public Decimal Quantidade { get; set; }
        public ItemResponse Item { get; set; }

        public ItemPedidoResponse(ItemPedido itemPedido)
        {
            this.Quantidade = (decimal)itemPedido.Quantidade;
            this.Item = new(itemPedido.IdItemNavigation);
        }
    }
}