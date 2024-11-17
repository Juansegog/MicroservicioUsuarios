using GestionPersonas.Application.Contratos;
using GestionPersonas.Domain.Entities;
using GestionPersonas.Domain.ExcepcionesGenerales;
using GestionPersonas.Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace GestionPersonas.Infraestructura.Repositorios
{
    public class RepositorioPaciente : RepositorioGenerico<Paciente>, IPacienteRepositorio
    {
        public RepositorioPaciente(AplicacionDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Paciente> GetPatientByEmail(string email)
        {
            return await _dbContext.Paciente
            .FirstOrDefaultAsync(p => p.Email == email) ?? throw new NoHayDatosException($"No se encontraron datos para el paciente con Email: {email} ");
        }
    }
}
