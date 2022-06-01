using GatewayPagamento.Dominio.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace GatewayPagamento.Repositorios.SqlServer.CodeFirst.ModelConfiguration
{
    public class CartaoConfiguration : EntityTypeConfiguration<Cartao>
    {
        public CartaoConfiguration()
        {
            Property(c => c.Numero)
                .IsRequired()
                .HasMaxLength(16)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UKNumeroCartao") { IsUnique = true }));

            Property(p => p.Limite)
                .IsRequired();
        }
    }
}