using VendasApp.WebApi.Models.Pedido;

namespace VendasApp.WebApi.Models.Cliente
{
    public class ClienteResponse
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Documento { get; set; }

        public string Telefone { get; set; }

        public string Endereco { get; set; }

        public List<PedidoResponse> Pedidos { get; set; } = new();

        public ClienteResponse(Domain.Entities.Cliente cliente)
        {
            this.Id = cliente.Id;
            this.Nome = cliente.Nome;
            this.Endereco = cliente.Endereco;
            this.Telefone = cliente.Telefone;
            this.Documento = cliente.Documento;
            if (cliente.Pedidos.Count > 0)
            {
                cliente.Pedidos.ToList().ForEach(t =>
                {
                    PedidoResponse pedido = new(t);
                    Pedidos.Add(pedido);
                });
            }
        }
    }
}