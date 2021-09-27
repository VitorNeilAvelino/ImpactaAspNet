namespace GatewayPagamento.Dominio.Entidades
{
    public class Pagamento
    {
        public int Id { get; set; }
        public /*virtual*/ Cartao Cartao { get; set; }
        public string NumeroPedido { get; set; }
        public decimal Valor { get; set; }
        public StatusPagamento Status { get; set; }
    }
}