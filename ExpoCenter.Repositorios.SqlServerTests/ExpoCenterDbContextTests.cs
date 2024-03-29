﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using ExpoCenter.Dominio.Entidades;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace ExpoCenter.Repositorios.SqlServer.Tests
{
    [TestClass]
    public class ExpoCenterDbContextTests
    {
        private readonly DbContextOptions<ExpoCenterDbContext> dbContextOptions;
        private readonly ExpoCenterDbContext dbContext;

        public ExpoCenterDbContextTests()
        {
            dbContextOptions = new DbContextOptionsBuilder<ExpoCenterDbContext>()
            .UseSqlServer(new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ExpoCenter;Integrated Security=True"))
            .LogTo(ExibirQuery, LogLevel.Information)
            .Options;

            dbContext = new ExpoCenterDbContext(dbContextOptions);
        }

        private void ExibirQuery(string query)
        {
            Console.WriteLine(query);
        }

        [TestMethod()]
        public void InserirEventoTest()
        {
            var evento = new Evento();
            evento.Data = DateTime.Now;
            evento.Descricao = "Expo Dubai 2020";
            evento.Local = "Dubai";
            evento.Preco = 15;

            dbContext.Eventos.Add(evento);
            dbContext.SaveChanges();
        }

        [TestMethod]
        public void InserirParticipanteTeste()
        {
            var participante = new Participante();
            participante.Cpf = "02345678905";
            participante.DataNascimento = new DateTime(2000, 1, 1);
            participante.Email = "felipe@gmail.com";
            participante.Nome = "Felipe";
            participante.Eventos = new List<Evento>
            {
                dbContext.Eventos.Single(e => e.Descricao == "Expo Dubai 2020")
            };

            dbContext.Participantes.Add(participante);
            dbContext.SaveChanges();

            foreach (var evento in participante.Eventos)
            {
                Console.WriteLine(evento.Descricao);
            }
        }

        [TestMethod]
        public void SelecionarParticipantesTeste()
        {
            foreach (var participante in dbContext.Participantes)
            {
                Console.WriteLine(participante.Nome);
            }
        }

        [TestMethod]
        public void InserirPagamentoTeste()
        {
            var pagamento = new Pagamento();
            pagamento.IdCartao = Guid.NewGuid();
            pagamento.IdProduto = Guid.NewGuid();
            pagamento.Valor = 14.45m;

            dbContext.Add(pagamento);
            dbContext.SaveChanges();
        }
    }
}