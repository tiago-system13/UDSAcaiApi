using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UDSAcaiApi.Dominio.Entidades;

namespace UDSAcaiApi.Dados.Mapeamentos
{
    public class TamanhoMapping : IEntityTypeConfiguration<Tamanho>
    {
        public void Configure(EntityTypeBuilder<Tamanho> builder)
        {
            builder.ToTable("Tamanho", "UDSAcaiApi");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                 .HasColumnName("id");

            builder.Property(x => x.Descricao)
                .HasColumnName("descricao")
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
