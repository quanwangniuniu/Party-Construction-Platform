using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Niuniumama.DB
{
    public class MySqlDatabase
    {
        private readonly string _connectionString;
        private MySqlConnection _connection;

        public MySqlDatabase(string connectionString)
        {
            _connectionString = connectionString;
            _connection = new MySqlConnection(_connectionString);
        }

        public async Task OpenConnectionAsync()
        {
            if (_connection.State != System.Data.ConnectionState.Open)
            {
                await _connection.OpenAsync();
            }
        }

        public async Task CloseConnectionAsync()
        {
            if (_connection.State != System.Data.ConnectionState.Closed)
            {
                await _connection.CloseAsync();
            }
        }
    }
}