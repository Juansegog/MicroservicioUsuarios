using AutoMapper;
using GestionPersonas.Application.CaracteristicasMedico.Comandos.ComandoMedico;
using GestionPersonas.Application.CaracteristicasPaciente.Comandos;
using GestionPersonas.Application.CaracteristicasPaciente.Consultas.ConsultarPacienteEmail;
using GestionPersonas.Application.Comunes;
using GestionPersonas.Domain.Entities;

namespace GestionPersonas.Application.Map
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region medico
            CreateMap<CrearComandoMedico, Medico>();
            CreateMap<Medico, CrearComandoMedico>().ReverseMap();
            CreateMap<object, List<MedicoVM>>();
            CreateMap<Medico, MedicoVM>();
            CreateMap<MedicoVM, Medico>().ReverseMap();
            #endregion

            #region paciente

            CreateMap<Task<Paciente>, PacienteVM>();
            CreateMap<ConsultarPacienteEmail, PacienteVM>();
            CreateMap<CrearComandoPaciente, Paciente>();
            CreateMap<Paciente, CrearComandoPaciente>().ReverseMap();
            CreateMap<PacienteVM, Paciente>();
            CreateMap<Paciente, PacienteVM>().ReverseMap();
            #endregion

        }
    }
}
