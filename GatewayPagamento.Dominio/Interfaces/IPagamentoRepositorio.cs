using GatewayPagamento.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace GatewayPagamento.Dominio.Interfaces
{
    public interface IPagamentoRepositorio
    {
        void Inserir(Pagamento pagamento);
        List<Pagamento> Selecionar(string numeroCartao);
        List<Pagamento> Selecionar(Func<Pagamento, bool> condicao);
    }
}