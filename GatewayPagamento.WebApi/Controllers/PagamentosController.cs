using GatewayPagamento.Dominio.Entidades;
using GatewayPagamento.Dominio.Servicos;
using GatewayPagamento.Repositorios.SqlServer.CodeFirst;
using GatewayPagamento.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace GatewayPagamento.WebApi.Controllers
{
    public class PagamentosController : ApiController
    {
        private readonly PagamentoRepositorio pagamentoRepositorio = new PagamentoRepositorio();
        private readonly CartaoRepositorio cartaoRepositorio = new CartaoRepositorio();
        private readonly PagamentoServico pagamentoServico;
        public PagamentosController()
        {
            pagamentoServico = new PagamentoServico(pagamentoRepositorio, cartaoRepositorio);
        }

        [Route("api/pagamentos/cartao/{idCartao}")]
        public IEnumerable<PagamentoGetViewModel> Get(int idCartao)
        {
            return PagamentoGetViewModel.Mapear(pagamentoRepositorio.Selecionar(p => p.Cartao.Id == idCartao));
        }

        public IHttpActionResult Post(PagamentoPostViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pagamento = PagamentoPostViewModel.Mapear(viewModel);
            
            pagamentoServico.Incluir(pagamento);

            var responseViewModel = PagamentoGetViewModel.Mapear(pagamento);

            switch (pagamento.Status)
            {
                case StatusPagamento.SaldoIndisponivel:
                case StatusPagamento.PedidoJaPago:
                case StatusPagamento.CartaoInexistente:
                    return Content(HttpStatusCode.BadRequest, responseViewModel);
                case StatusPagamento.PagamentoOK:
                    return Ok(responseViewModel);
            }

            return InternalServerError(new ArgumentOutOfRangeException(nameof(pagamento.Status)));
        }
    }
}