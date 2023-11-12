using Npgsql;

namespace DapperTest.Services.SQLConnectionFactory
{
    public interface ISqlConnectionFactory
    {
        public NpgsqlConnection GetNpgsqlConnection(string connectionName);
    }
}
