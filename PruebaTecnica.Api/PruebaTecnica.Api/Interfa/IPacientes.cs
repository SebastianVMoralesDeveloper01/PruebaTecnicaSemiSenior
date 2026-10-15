using PruebaTecnica.Api.DTOs;

namespace PruebaTecnica.Api.Interfa
{
    public interface IPacientes
    {
        Task<int> PacientesCrear(CrearPacienteDto pacienteDto);
    }
}
