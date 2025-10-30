using Microsoft.EntityFrameworkCore;

namespace BuildYourPc.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Descricao).HasMaxLength(500);
                entity.Property(e => e.Preco).HasColumnType("decimal(18,2)");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}