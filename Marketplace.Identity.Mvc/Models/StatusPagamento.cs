using System.ComponentModel;

namespace Marketplace.Identity.Mvc.Models
{
    public enum StatusPagamento
    {
        [Description("Não definido")]
        NaoDefinido = 0,

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