namespace VendasApp.WebApi.Models.Item
{
    public class ItemResponse
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string ValorUnitario { get; set; }

        public string Unidade { get; set; }

        public ItemResponse(Domain.Entities.Item item)
        {
            this.Id = item.Id;
            this.Nome = item.Nome;
            this.Unidade = item.Unidade;
            this.ValorUnitario = item.ValorUnitario;
        }
    }
}