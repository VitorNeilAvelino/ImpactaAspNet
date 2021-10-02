using GatewayPagamento.Dominio.Entidades;
using GatewayPagamento.Dominio.Interfaces;
using System.Linq;

namespace GatewayPagamento.Dominio.Servicos
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

        public void Incluir(Pagamento pagamento)
        {
            var cartao = cartaoRepositorio.Selecionar(pagamento.Cartao.Numero);

            if (cartao == null)
            {
                pagamento.Status = StatusPagamento.CartaoInexistente;
            }

            var pagamentoExistente = pagamentoRepositorio.Selecionar(p => p.NumeroPedido == pagamento.NumeroPedido);

            if (pagamentoExistente.Any())
            {
                pagamento.Status = StatusPagamento.PedidoJaPago;
            }

            if (pagamento.Valor > cartao?.Limite)
            {
                pagamento.Status = StatusPagamento.SaldoIndisponivel;
            }

            if (pagamento.Status == StatusPagamento.NaoDefinido)
            {
                pagamento.Status = StatusPagamento.PagamentoOK;

                pagamentoRepositorio.Inserir(pagamento); 
            }
        }
    }
}