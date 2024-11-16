using GestionPersonas.Application.Contratos;
using GestionPersonas.Domain.Entities;
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
            .FirstOrDefaultAsync(p => p.Email == email) ?? new Paciente();
        }
    }
}
