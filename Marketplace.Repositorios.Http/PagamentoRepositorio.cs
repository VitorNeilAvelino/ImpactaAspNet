using Marketplace.Repositorios.Http.Requests;
using Marketplace.Repositorios.Http.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Marketplace.Repositorios.Http
{
    public class PagamentoRepositorio
    {
        private readonly HttpClient httpClient = new HttpClient();
        private const string caminho = "pagamentos";

        public PagamentoRepositorio(string baseAddress)
        {
            httpClient.BaseAddress = new Uri(baseAddress.TrimEnd('/') + '/');
        }

        public async Task<List<PagamentoResponse>> ObterPorCartao(int idCartao)        
        {
            using (var resposta = await httpClient.GetAsync($"{caminho}/cartao/{idCartao}"))
            {
                return await resposta.Content.ReadAsAsync<List<PagamentoResponse>>();
            }
        }

        public async Task Post(PagamentoRequest pagamento)
        {
            using (var resposta = await httpClient.PostAsJsonAsync($"{caminho}", pagamento))
            {
                resposta.EnsureSuccessStatusCode();
            }
        }
    }
}