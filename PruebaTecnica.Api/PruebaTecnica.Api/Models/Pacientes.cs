using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PruebaTecnica.Api.Models
{
    public class Pacientes
    {
        public int PacienteId { get; set; }
        public int TipoDocumentoId {  get; set; }
        public string NumeroDocumento { get; set; }
        public string NombrePaciente { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public string CorreoElectronico { get; set; }
        public int GeneroId { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public bool Activo { get; set; }
    }
}
