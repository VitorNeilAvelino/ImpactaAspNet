using GatewayPagamento.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace GatewayPagamento.Repositorios.SqlServer.CodeFirst.ModelConfiguration
{
    public class CartaoConfiguration : EntityTypeConfiguration<Cartao>
    {
        public CartaoConfiguration()
        {
            Property(c => c.Numero)
                .IsRequired()
                .HasMaxLength(16);

            Property(p => p.Limite)
                .IsRequired();
        }
    }
}