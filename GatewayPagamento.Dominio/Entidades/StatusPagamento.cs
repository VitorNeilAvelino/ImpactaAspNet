using System.ComponentModel;

namespace GatewayPagamento.Dominio.Entidades
{
    public enum StatusPagamento
    {
        [Description("Saldo indisponível")]
        SaldoIndisponivel = 1,
        
        [Description("Pedido pago anteriormente")]
        PedidoJaPago = 2,

        [Description("Cartão inexistente")]
        CartaoInexistente = 3,

        [Description("Pagamento OK")]
        PagamentoOK = 4
    }
}