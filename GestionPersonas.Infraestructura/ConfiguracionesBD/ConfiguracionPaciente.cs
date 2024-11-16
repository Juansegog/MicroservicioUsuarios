using GestionPersonas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionPersonas.Infraestructura.ConfiguracionesBD
{
    public class ConfiguracionPaciente : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("Pacientes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nombre).HasMaxLength(100);
            builder.Property(x => x.Apellido).HasMaxLength(100);
            builder.Property(x => x.NumeroHistoriaClinica).HasMaxLength(20);
            builder.Property(x => x.Diagnostico).HasMaxLength(254);

            builder.OwnsOne(p => p.Direccion)
                    .Property(ci => ci.Ciudad)
                    .HasMaxLength(100)
                    .HasColumnName("Ciudad");

            builder.OwnsOne(p => p.Direccion)
                    .Property(ci => ci.Calle)
                    .HasMaxLength(100)
                    .HasColumnName("Calle");

            builder.OwnsOne(p => p.Direccion)
                    .Property(ci => ci.Departamento)
                    .HasMaxLength(100)
                    .HasColumnName("Departamento");

            builder.OwnsOne(p => p.Direccion)
                    .Property(ci => ci.Municipio)
                    .HasMaxLength(100)
                    .HasColumnName("Municipio");
        }
    }
}
