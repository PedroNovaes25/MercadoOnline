using MercadoDigital.Domain.Entities;

namespace MercadoDigital.Application.DTO.Output
{
    public class PedidoItemOutputDTO
    {
        //PedidoItem
        public int Quantidade { get; set; }
        public double Subtotal { get; set; }
        //Produto
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public DateTime Vencimento { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
    }
}