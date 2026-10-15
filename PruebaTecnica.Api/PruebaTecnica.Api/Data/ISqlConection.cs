using Microsoft.Data.SqlClient;

namespace PruebaTecnica.Api.Data
{
    public interface ISqlConection
    {
        SqlConnection CrearConexion();
    }

    public class SqlConnectionData : ISqlConection
    {
        public readonly string _ConnectionString;
        public SqlConnectionData(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        public SqlConnectionData(IConfiguration configuration) {
            _ConnectionString = configuration.GetConnectionString("PruebaTecnicaDB") ?? "Error de conexion";
        }

        public SqlConnection CrearConexion() => new(_ConnectionString);
    }
}
