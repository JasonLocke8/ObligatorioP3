using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.VO;
using Microsoft.EntityFrameworkCore;

namespace Libreria.LogicaAccesoDatos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Agencia> Agencias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Envio> Envios { get; set; }
        public DbSet<EnvioComun> EnviosComunes { get; set; }
        public DbSet<EnvioUrgente> EnviosUrgentes { get; set; }
        public DbSet<SeguimientoEnvio> SeguimientosEnvios { get; set; }
        public DbSet<Auditoria> Auditorias { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            
            // Agencia y Envio Urgente

            modelBuilder.Entity<Agencia>().OwnsOne(a => a.Direccion, n =>
            {
                n.Property(p => p.Calle).HasColumnName("Calle");
                n.Property(p => p.NroPuerta).HasColumnName("NroPuerta");
                n.Property(p => p.Departamento).HasColumnName("Departamento");
            });
            modelBuilder.Entity<EnvioUrgente>().OwnsOne(a => a.Direccion, n =>
            {
                n.Property(p => p.Calle).HasColumnName("Calle");
                n.Property(p => p.NroPuerta).HasColumnName("NroPuerta");
                n.Property(p => p.Departamento).HasColumnName("Departamento");
            });

            modelBuilder.Entity<Envio>()
                .HasOne(v => v.Cliente)
                .WithMany()
                .HasForeignKey(v => v.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Envio>()
               .HasOne(v => v.Empleado)
               .WithMany()
               .HasForeignKey(v => v.EmpleadoId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Envio>()
                .Property(e => e.Peso)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Envio>()
                .HasDiscriminator<string>("TipoEnvio")
                .HasValue<EnvioComun>("EnvioComun")
                .HasValue<EnvioUrgente>("EnvioUrgente");

        }

    }
}
