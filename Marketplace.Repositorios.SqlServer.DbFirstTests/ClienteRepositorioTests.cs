using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Marketplace.Repositorios.SqlServer.DbFirst.Tests
{
    [TestClass()]
    public class ClienteRepositorioTests
    {
        [TestMethod()]
        public void IncluirTest()
        {
            var cliente = new Cliente();

            cliente.Documento = "12345678910";
            cliente.Email = "avelino.vitor@gmail.com";
            cliente.Nome = "Vítor Avelino";
            cliente.Telefone = "11 9 9999 8888";

            new ClienteRepositorio().Inserir(cliente);
        }

        [TestMethod]
        public void ExcluirTeste()
        {
            new ClienteRepositorio().Excluir(3);
        }
    }
}