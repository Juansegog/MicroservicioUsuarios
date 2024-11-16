using GestionPersonas.Domain.Entities;
using GestionPersonas.Infraestructura.ConfiguracionesBD;
using Microsoft.EntityFrameworkCore;

namespace GestionPersonas.Infraestructura.Persistencia
{
    public class AplicacionDbContext : DbContext
    {
        public AplicacionDbContext(DbContextOptions<AplicacionDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ConfiguracionMedico());
            builder.ApplyConfiguration(new ConfiguracionPaciente());
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(builder);
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }


        public DbSet<Medico> Medico { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
    }
}
