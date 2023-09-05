using ex04.Models;
using Microsoft.EntityFrameworkCore;

namespace ex04.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Pelicula> peliculas { get; set; }
        public DbSet<Sala> salas { get; set; }

        public MyDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sala>(sala =>
            {
                sala.ToTable("Salas");
                sala.HasKey(p => p.codigo);
                sala.Property(p => p.nombre).HasMaxLength(100);

                sala.HasOne(p => p.v_pelicula).WithMany(p => p.v_sala).HasForeignKey(p => p.fk_pelicula);
            });

            modelBuilder.Entity<Pelicula>(pelicula =>
            {
                pelicula.ToTable("Peliculas");
                pelicula.HasKey(p => p.codigo);
                pelicula.Property(p => p.nombre).HasMaxLength(100);
            });
        }
    }
}
