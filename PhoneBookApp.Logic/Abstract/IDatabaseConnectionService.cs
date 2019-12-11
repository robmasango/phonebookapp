using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace eFindingsRegister.Logic.Abstract
{
    public interface IDatabaseConnectionService : IDisposable {
        Task<SqlConnection> CreateConnectionAsync();
        SqlConnection CreateConnection();
        SqlConnection GetConnection();
    }
}
