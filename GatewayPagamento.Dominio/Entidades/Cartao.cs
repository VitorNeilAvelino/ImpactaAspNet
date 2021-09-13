namespace GatewayPagamento.Dominio.Entidades
{
    public class Cartao
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public decimal Limite { get; set; }
    }
}