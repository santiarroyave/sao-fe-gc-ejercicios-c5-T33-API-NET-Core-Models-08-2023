using ex01.Models;
using Microsoft.EntityFrameworkCore;

namespace ex01.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Articulo> articulos { get; set; }
        public DbSet<Fabricante> fabricantes { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulo>(articulo =>
            {
                articulo.ToTable("Articulo");
                articulo.HasKey(p => p.codigo);

                articulo.Property(p => p.nombre).HasMaxLength(100);
                articulo.Property(p => p.fk_fabricante).HasColumnName("fabricante");

                articulo.HasOne(p => p.v_fabricante).WithMany(p => p.v_articulo).HasForeignKey(p => p.fk_fabricante);
            });

            modelBuilder.Entity<Fabricante>(fabricante =>
            {
                fabricante.ToTable("Fabricante");
                fabricante.HasKey(p => p.codigo);

                fabricante.Property(p => p.nombre).HasMaxLength(100);
            });
        }
    }
}
