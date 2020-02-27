using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UDSAcaiApi.Dominio.Entidades;

namespace UDSAcaiApi.Dados.Mapeamentos
{
    public class PreparacaoMapping : IEntityTypeConfiguration<Preparacao>
    {
        public void Configure(EntityTypeBuilder<Preparacao> builder)
        {
            builder.ToTable("Preparacao", "UDSAcaiApi");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                 .HasColumnName("id");

            builder.Property(x => x.SaborId)
               .HasColumnName("saborId")
               .IsRequired();

            builder.Property(x => x.TamanhoId)
               .HasColumnName("tamanhoId")
               .IsRequired();

            builder.HasOne(x => x.Sabor)
               .WithMany(o => o.Preparacoes)
               .HasForeignKey(x => x.SaborId);

            builder.Property(x => x.Valor)
               .HasColumnName("valor")
               .IsRequired();

            builder.Property(x => x.Tempo)
              .HasColumnName("duracao")
              .IsRequired();

        }
    }
}
