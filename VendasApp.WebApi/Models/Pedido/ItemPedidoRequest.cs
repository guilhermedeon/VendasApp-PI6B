namespace VendasApp.WebApi.Models.Pedido
{
    public class ItemPedidoRequest
    {
        public int IdItem { get; set; }
        public Decimal Quantidade { get; set; }
    }
}