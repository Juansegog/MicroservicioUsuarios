using GestionPersonas.Domain.Entities;

namespace GestionPersonas.Application.Contratos
{
    public interface IPacienteRepositorio : IRepositorioGenerico<Paciente>
    {
        Task<Paciente> GetPatientByEmail(string email);
    }
}
