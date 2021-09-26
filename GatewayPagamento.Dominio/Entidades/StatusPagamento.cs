namespace GatewayPagamento.Dominio.Entidades
{
    public enum StatusPagamento
    {
        SaldoIndisponivel = 1,
        PedidoJaPago = 2,
        CartaoInexistente = 3,
        PagamentoOK = 4
    }
}