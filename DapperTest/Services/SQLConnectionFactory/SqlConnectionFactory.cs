using Npgsql;

namespace DapperTest.Services.SQLConnectionFactory
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private IConfiguration _configuration;

        public SqlConnectionFactory(IConfiguration config) 
        { 
            _configuration = config;
        }

       
        public NpgsqlConnection GetNpgsqlConnection(string connectionName)
        {
            var connectionString = _configuration.GetConnectionString(connectionName);

            return new NpgsqlConnection(connectionString);
        }
    }
}
