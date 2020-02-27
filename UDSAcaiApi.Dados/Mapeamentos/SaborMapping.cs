using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UDSAcaiApi.Dominio.Entidades;

namespace UDSAcaiApi.Dados.Mapeamentos
{
    public class SaborMapping : IEntityTypeConfiguration<Sabor>
    {
        public void Configure(EntityTypeBuilder<Sabor> builder)
        {
            builder.ToTable("Sabor", "UDSAcaiApi");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                 .HasColumnName("id");

            builder.Property(x => x.Descricao)
                .HasColumnName("descricao")
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
