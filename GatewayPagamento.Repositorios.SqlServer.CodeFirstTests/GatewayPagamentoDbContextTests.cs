using Microsoft.VisualStudio.TestTools.UnitTesting;
using GatewayPagamento.Dominio.Entidades;

namespace GatewayPagamento.Repositorios.SqlServer.CodeFirst.Tests
{
    [TestClass()]
    public class GatewayPagamentoDbContextTests
    {
        private readonly GatewayPagamentoDbContext contexto = new GatewayPagamentoDbContext();

        [TestMethod()]
        public void InserirCartaoTeste()
        {
            contexto.Cartoes.Add(new Cartao { Limite = 1000, Numero = "123" });
        }
    }
}