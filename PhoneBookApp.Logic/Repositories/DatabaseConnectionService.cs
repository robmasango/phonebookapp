using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using eFindingsRegister.Logic.Abstract;

namespace eFindingsRegister.Logic.Repositories
{
    public class DatabaseConnectionService : IDatabaseConnectionService
    {
        private SqlConnection _sqlConnection;
        private readonly string _connectionString;
        IConfiguration _configuration;
        public DatabaseConnectionService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("eFindingsConection");
        }

        public SqlConnection GetConnection()
        {
            if (_sqlConnection != null)
            {
                if (_sqlConnection.State != System.Data.ConnectionState.Open)
                    _sqlConnection.Open();

                return _sqlConnection;
            }
            return null;
        }

        public async Task<SqlConnection> CreateConnectionAsync()
        {
            _sqlConnection = new SqlConnection(_connectionString);
            await _sqlConnection.OpenAsync();

            return await Task.FromResult(_sqlConnection);
        }

        public SqlConnection CreateConnection()
        {
            _sqlConnection = new SqlConnection(_connectionString);
            _sqlConnection.Open();

            return _sqlConnection;
        }

        public void Dispose()
        {
            if (_sqlConnection == null)
            {
                return;
            }

            _sqlConnection.Dispose();
            _sqlConnection = null;
        }
    }
}
