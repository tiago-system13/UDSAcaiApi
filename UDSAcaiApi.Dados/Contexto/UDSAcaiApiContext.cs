using Microsoft.EntityFrameworkCore;
using UDSAcaiApi.Dados.Mapeamentos;
using UDSAcaiApi.Dominio.Entidades;

namespace UDSAcaiApi.Dados.Contexto
{
    public class UDSAcaiApiContext : DbContext
    {
        public DbSet<Sabor> Sabores { get; set; }
        public DbSet<Tamanho> Tamanhos { get; set; }
        public DbSet<Preparacao> Preparacoes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Adicionais> PedidosAdiconais { get; set; }
        public DbSet<ItensAdicionaisPedido> ItensPedidosAdicionais { get; set; }

        public UDSAcaiApiContext(DbContextOptions<UDSAcaiApiContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SaborMapping());
            modelBuilder.ApplyConfiguration(new TamanhoMapping());
            modelBuilder.ApplyConfiguration(new PreparacaoMapping());
            modelBuilder.ApplyConfiguration(new PedidoMapping());
            modelBuilder.ApplyConfiguration(new AdicionaisMapping());
            modelBuilder.ApplyConfiguration(new ItensAdicionaisMapping());

        }
    }
}
