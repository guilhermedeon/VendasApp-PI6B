namespace VendasApp.Domain.Entities;

public partial class Item
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? ValorUnitario { get; set; }

    public string? Unidade { get; set; }
}