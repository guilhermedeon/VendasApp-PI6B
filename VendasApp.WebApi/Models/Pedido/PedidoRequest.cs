namespace VendasApp.WebApi.Models.Pedido
{
    public class PedidoRequest
    {
        public int IdCliente { get; set; }
        public List<ItemPedidoRequest> Itens { get; set; } = new List<ItemPedidoRequest>();

        //public int IdVendedor { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;

        public string Status { get; set; }
    }
}