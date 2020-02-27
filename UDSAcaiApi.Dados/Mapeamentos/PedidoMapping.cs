using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UDSAcaiApi.Dominio.Entidades;

namespace UDSAcaiApi.Dados.Mapeamentos
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido","UDSAcaiApi");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                 .HasColumnName("id");

            builder.Property(x => x.PreparacaoId)
               .HasColumnName("preparacaoId")
               .IsRequired();

            builder.Property(x => x.Total)
               .HasColumnName("total")
               .IsRequired();

            builder.Property(x => x.Data)
              .HasColumnName("data")
              .IsRequired();

            builder.HasOne(x => x.Preparacao)
              .WithMany(o => o.Pedidos)
              .HasForeignKey(x => x.PreparacaoId);
        }
    }
}
