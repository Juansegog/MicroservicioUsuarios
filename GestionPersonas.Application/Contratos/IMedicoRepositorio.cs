using GestionPersonas.Domain.Entities;

namespace GestionPersonas.Application.Contratos
{
    public interface IMedicoRepositorio : IRepositorioGenerico<Medico>
    {
        Task<Medico> GetDoctorByEmail(string email);
    }
}
