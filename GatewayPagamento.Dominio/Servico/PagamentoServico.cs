using GatewayPagamento.Dominio.Entidades;
using GatewayPagamento.Dominio.Interfaces;
using System.Linq;

namespace GatewayPagamento.Dominio.Servico
{
    public class PagamentoServico
    {
        private readonly IPagamentoRepositorio pagamentoRepositorio;
        private readonly ICartaoRepositorio cartaoRepositorio;

        public PagamentoServico(IPagamentoRepositorio pagamentoRepositorio, ICartaoRepositorio cartaoRepositorio)
        {
            this.pagamentoRepositorio = pagamentoRepositorio;
            this.cartaoRepositorio = cartaoRepositorio;
        }

        public StatusPagamento Incluir(Pagamento pagamento)
        {
            var cartao = cartaoRepositorio.Selecionar(pagamento.Cartao.Numero);

            if (cartao == null)
            {
                return StatusPagamento.CartaoInexistente;
            }

            var pagamentoExistente = pagamentoRepositorio.Selecionar(p => p.NumeroPedido == pagamento.NumeroPedido);

            if (!pagamentoExistente.Any())
            {
                return StatusPagamento.PedidoJaPago;
            }

            if (pagamento.Valor > cartao.Limite)
            {
                return StatusPagamento.SaldoIndisponivel;
            }

            pagamentoRepositorio.Inserir(pagamento);

            return StatusPagamento.PagamentoOK;
        }
    }
}