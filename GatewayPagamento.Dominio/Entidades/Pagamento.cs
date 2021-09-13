﻿namespace GatewayPagamento.Dominio.Entidades
{
    public class Pagamento
    {
        public int Id { get; set; }
        public Cartao Cartao { get; set; }
        public string NumeroPedido { get; set; }
        public decimal Valor { get; set; }
        public int Status { get; set; }
    }
}