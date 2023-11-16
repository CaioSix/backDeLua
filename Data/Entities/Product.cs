namespace DeLua.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public string Categoria { get; set; }
        public int Preco { get; set; }
        public string ImageUrl { get; set; }
        public int PossuiEstoque { get; set; }

    }
}
