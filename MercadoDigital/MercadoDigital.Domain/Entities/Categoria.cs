namespace MercadoDigital.Domain.Entities
{
    public class Categoria
    {
        public Categoria(string nome)
        {
            Nome = nome;
        }

        public int IdCategoria { get; set; }
        public string Nome { get; set; }
        public List<CategoriaProduto> CategoriaProduto { get; set; } 
    }
}