namespace VendasApp.Domain.Entities;

public partial class ItemPedido
{
    public int? Id { get; set; }
    public int? IdPedido { get; set; }

    public int? IdItem { get; set; }

    public decimal? Quantidade { get; set; }

    public virtual Item? IdItemNavigation { get; set; }

    public virtual Pedido? IdPedidoNavigation { get; set; }
}