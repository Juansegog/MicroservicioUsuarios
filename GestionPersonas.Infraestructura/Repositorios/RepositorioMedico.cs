using GestionPersonas.Application.Contratos;
using GestionPersonas.Domain.Entities;
using GestionPersonas.Domain.ExcepcionesGenerales;
using GestionPersonas.Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace GestionPersonas.Infraestructura.Repositorios
{
    public class RepositorioMedico : RepositorioGenerico<Medico>, IMedicoRepositorio
    {
        public RepositorioMedico(AplicacionDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<Medico> GetDoctorByEmail(string email)
        {
            return await _dbContext.Medico
            .FirstOrDefaultAsync(p => p.Email == email) ?? throw new NoHayDatosException($"No se encontro un usuario para el email: {email}");
        }
    }
}
