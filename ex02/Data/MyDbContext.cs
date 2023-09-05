using ex02.Models;
using Microsoft.EntityFrameworkCore;

namespace ex02.Data
{
    public class MyDbContext :DbContext
    {
        public DbSet<Departamento> Departamentos { get; set;}
        public DbSet<Empleado> Empleados { get; set;}

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departamento>(departamento =>
            {
                departamento.ToTable("Departamentos");
                departamento.HasKey(p => p.codigo);

                departamento.Property(p => p.nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<Empleado>(empleado =>
            {
                empleado.ToTable("Empleados");
                empleado.HasKey(p => p.dni);

                empleado.Property(p => p.dni).HasMaxLength(8);
                empleado.Property(p => p.nombre).HasMaxLength(100);
                empleado.Property(p => p.apellidos).HasMaxLength(255);
                empleado.Property(p => p.fk_departamento).HasColumnName("Departamento");

                empleado.HasOne(p => p.v_departamento).WithMany(p => p.v_empleados).HasForeignKey(p => p.fk_departamento);
            });
        }
    }
}
