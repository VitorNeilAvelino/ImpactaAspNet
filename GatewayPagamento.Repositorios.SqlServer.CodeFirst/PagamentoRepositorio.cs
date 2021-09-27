using GatewayPagamento.Dominio.Entidades;
using GatewayPagamento.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace GatewayPagamento.Repositorios.SqlServer.CodeFirst
{
    public class PagamentoRepositorio : IPagamentoRepositorio
    {
        public List<Pagamento> Selecionar(string numeroCartao)
        {
            using (var contexto = new GatewayPagamentoDbContext())
            {
                return contexto.Pagamentos
                    .Include(p => p.Cartao)
                    .Where(p => p.Cartao.Numero == numeroCartao)
                    .ToList();
            }
        }

        public List<Pagamento> Selecionar(Func<Pagamento, bool> condicao)
        {
            using (var contexto = new GatewayPagamentoDbContext())
            {
                return contexto.Pagamentos
                    .Include(p => p.Cartao)
                    .Where(condicao).ToList();
            }
        }

        public void Inserir(Pagamento pagamento)
        {
            using (var contexto = new GatewayPagamentoDbContext())
            {
                pagamento.Cartao = contexto.Cartoes.SingleOrDefault(c => c.Numero == pagamento.Cartao.Numero);

                contexto.Pagamentos.Add(pagamento);
                contexto.SaveChanges();
            }
        }
    }
}