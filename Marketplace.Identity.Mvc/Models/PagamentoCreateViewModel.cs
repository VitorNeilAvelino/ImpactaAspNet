using Marketplace.Repositorios.Http.Requests;
using System.ComponentModel.DataAnnotations;

namespace Marketplace.Identity.Mvc.Models
{
    public class PagamentoCreateViewModel
    {
        [Required]
        public int IdCartao { get; set; }

        [Required]
        [DataType(DataType.CreditCard)]
        [Display(Name = "Cartão")]
        public string NumeroCartao { get; set; }

        [Required]
        [Display(Name = "Pedido")] 
        public string NumeroPedido { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }

        internal static PagamentoRequest Mapear(PagamentoCreateViewModel viewModel)
        {
            var request = new PagamentoRequest();

            request.NumeroCartao = viewModel.NumeroCartao;
            request.NumeroPedido = viewModel.NumeroPedido;
            request.Valor = viewModel.Valor;

            return request;
        }
    }
}