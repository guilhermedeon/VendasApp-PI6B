using System.ComponentModel.DataAnnotations;

namespace VendasApp.Domain.Entities;

public partial class Usuario
{
    [Key]
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }

    public IEnumerable<Pedido> Pedidos { get; set; }
}