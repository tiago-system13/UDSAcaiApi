using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UDSAcaiApi.Dominio.Entidades;

namespace UDSAcaiApi.Dados.Mapeamentos
{
    public class AdicionaisMapping : IEntityTypeConfiguration<Adicionais>
    {
        public void Configure(EntityTypeBuilder<Adicionais> builder)
        {
            builder.ToTable("Adicionais", "UDSAcaiApi");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                 .HasColumnName("id");

            builder.Property(x => x.Descricao)
                .HasColumnName("descricao")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(x => x.Valor)
               .HasColumnName("valor")
               .IsRequired();

            builder.Property(x => x.Tempo)
               .HasColumnName("duracao")
               .IsRequired();
        }
    }
}
