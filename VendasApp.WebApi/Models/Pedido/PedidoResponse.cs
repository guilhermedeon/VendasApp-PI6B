namespace VendasApp.WebApi.Models.Pedido
{
    public class PedidoResponse
    {
        public int IdCliente { get; set; }
        public List<ItemPedidoResponse> Itens { get; set; } = new();

        //public int IdVendedor { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;

        public string Status { get; set; }

        public PedidoResponse(Domain.Entities.Pedido pedido)
        {
            this.IdCliente = (int)pedido.IdCliente;
            this.Data = (DateTime)pedido.Data;
            this.Status = pedido.Status;
            if (pedido.ItensPedido.Count > 0)
            {
                pedido.ItensPedido.ToList().ForEach(t =>
                {
                    ItemPedidoResponse item = new(t);
                    Itens.Add(item);
                });
            }
        }
    }
}