using GestionPersonas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionPersonas.Infraestructura.ConfiguracionesBD
{
    public class ConfiguracionMedico : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.ToTable("Medicos");
            builder.HasKey(x => x.Id);


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
