using Microsoft.Data.SqlClient;
using PruebaTecnica.Api.Data;
using PruebaTecnica.Api.DTOs;
using System.Data;
using SqlConnection = Microsoft.Data.SqlClient.SqlConnection;

namespace PruebaTecnica.Api.Interfa
{
    public class Pacientes(ISqlConection sqlConection) : IPacientes
    {
        public async Task<int> PacientesCrear(CrearPacienteDto crearPacienteDto)
        {
            try
            {
                await using var conexion = sqlConection.CrearConexion();
                await using var comando = CreateSqlCommand(conexion, "SP_Crear_Paciente");
                ParametrosPaciente(comando, crearPacienteDto);
                
                await conexion.OpenAsync();
                var result = await comando.ExecuteScalarAsync();

                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("error en la creacion" + ex);
                return 0;
            }
        }

        private static SqlCommand CreateSqlCommand(SqlConnection conexion, string procedimiento) =>
        new(procedimiento, conexion)
        {
            CommandType = CommandType.StoredProcedure,
            CommandTimeout = 30
        };

        private static void ParametrosPaciente(SqlCommand comando, CrearPacienteDto p)
        {
            comando.Parameters.Add("@TipoDocumentoId", SqlDbType.Int).Value = p.TipoDocumentoId!;
            comando.Parameters.Add("@NumeroDocumento", SqlDbType.VarChar, 20).Value = p.NumeroDocumento;
            comando.Parameters.Add("@NombrePaciente", SqlDbType.NVarChar, 150).Value = p.NombrePaciente;
            comando.Parameters.Add("@FechaNacimiento", SqlDbType.Date).Value = p.FechaNacimiento!.ToDateTime(TimeOnly.MinValue);
            comando.Parameters.Add("@CorreoElectronico", SqlDbType.VarChar, 150).Value = p.CorreoElectronico;
            comando.Parameters.Add("@GeneroId", SqlDbType.Int).Value = p.GeneroId!;
            comando.Parameters.Add("@Direccion", SqlDbType.NVarChar, 200).Value = (object?)p.Direccion ?? DBNull.Value;
            comando.Parameters.Add("@Telefono", SqlDbType.VarChar, 20).Value = (object?)p.Telefono ?? DBNull.Value;
            comando.Parameters.Add("@Activo", SqlDbType.Bit).Value = (object?)p.Activo ?? DBNull.Value;
        }
    }
}
