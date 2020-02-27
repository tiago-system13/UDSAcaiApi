using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UDSAcaiApi.Dominio.Entidades;

namespace UDSAcaiApi.Dados.Mapeamentos
{
    class ItensAdicionaisMapping : IEntityTypeConfiguration<ItensAdicionaisPedido>
    {
        public void Configure(EntityTypeBuilder<ItensAdicionaisPedido> builder)
        {
            builder.ToTable("ItensAdicionais","UDSAcaiApi");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                 .HasColumnName("Id");

            builder.Property(x => x.PedidioId)
               .HasColumnName("pedidoId");

            builder.Property(x => x.AdicionalId)
               .HasColumnName("adicionaisId");

            builder.HasOne(x => x.Pedido)
              .WithMany(o => o.ItensAdicionais)
              .HasForeignKey(x => x.PedidioId);

            builder.HasOne(x => x.Adicionais)
             .WithMany(o => o.ItensAdicionais)
             .HasForeignKey(x => x.AdicionalId);
        }
    }
}
