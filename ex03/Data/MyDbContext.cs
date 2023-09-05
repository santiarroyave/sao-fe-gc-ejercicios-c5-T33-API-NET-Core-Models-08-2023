using ex03.Models;
using Microsoft.EntityFrameworkCore;

namespace ex03.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Caja> cajas { get; set; }
        public DbSet<Almacen> almacenes { get; set; }

        public MyDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Caja>(caja =>
            {
                caja.ToTable("Cajas");
                caja.HasKey(p => p.numReferencia);
                caja.Property(p => p.numReferencia).HasMaxLength(5);
                caja.Property(p => p.contenido).HasMaxLength(100);
                caja.Property(p => p.fk_almacen).HasColumnName("almacen");

                caja.HasOne(p => p.v_almacen).WithMany(p => p.v_caja).HasForeignKey(p => p.fk_almacen);
            });

            modelBuilder.Entity<Almacen>(almacen =>
            {
                almacen.ToTable("Almacenes");
                almacen.HasKey(p => p.codigo);
                almacen.Property(p => p.lugar).HasMaxLength(100);
            });
        }
    }
}
