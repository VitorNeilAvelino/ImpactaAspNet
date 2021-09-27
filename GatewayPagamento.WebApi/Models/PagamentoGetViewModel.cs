using GatewayPagamento.Dominio.Entidades;
using GatewayPagamento.Apoio;
using System.Collections.Generic;

namespace GatewayPagamento.WebApi.Models
{
    public class PagamentoGetViewModel
    {
        public int Id { get; set; }
        public string MascaraCartao { get; set; }
        public string NumeroPedido { get; set; }
        public decimal Valor { get; set; }
        public int Status { get; set; }
        public string MensagemStatus { get; set; }

        public static PagamentoGetViewModel Mapear(Pagamento pagamento)
        {
            var viewModel = new PagamentoGetViewModel();

            viewModel.Id = pagamento.Id;

            var numeroCartao = pagamento.Cartao.Numero;
            viewModel.MascaraCartao = $"{numeroCartao.Substring(0, 6)}...{numeroCartao.Substring(numeroCartao.Length - 4)}";

            viewModel.MensagemStatus = pagamento.Status.ObterDescricao();
            viewModel.NumeroPedido = pagamento.NumeroPedido;
            viewModel.Status = (int)pagamento.Status;
            viewModel.Valor = pagamento.Valor;

            return viewModel;
        }

        internal static List<PagamentoGetViewModel> Mapear(List<Pagamento> pagamentos)
        {
            var viewModels = new List<PagamentoGetViewModel>();

            foreach (var pagamento in pagamentos)
            {
                viewModels.Add(Mapear(pagamento));
            }

            return viewModels;
        }
    }
}