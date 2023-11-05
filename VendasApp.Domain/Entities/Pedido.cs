using System.ComponentModel.DataAnnotations;

namespace VendasApp.Domain.Entities;

public partial class Pedido
{
    [Key]
    public int Id { get; set; }

    public int? IdCliente { get; set; }

    public int? IdVendedor { get; set; }

    public DateTime? Data { get; set; }

    public string? Status { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Usuario? IdVendedorNavigation { get; set; }

    public virtual ICollection<ItemPedido> ItensPedido { get; set; } = new List<ItemPedido>();
}