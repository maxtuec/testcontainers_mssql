using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextStop.Dal.Common
{
    public class DefaultConnectionFactory : IConnectionFactory
    {
        private readonly DbProviderFactory dbProviderFactory;
        public string ConnectionString { get; }
        public string ProviderName { get; }

        public DefaultConnectionFactory(string connectionString, string providerName)
        {
            ConnectionString = connectionString;
            ProviderName = providerName;

            DbProviderFactories.RegisterFactory("Microsoft.Data.SqlClient", Microsoft.Data.SqlClient.SqlClientFactory.Instance);
            DbProviderFactories.RegisterFactory("Npgsql", Npgsql.NpgsqlFactory.Instance);

            dbProviderFactory = DbProviderFactories.GetFactory(providerName);
        }

        public static IConnectionFactory FromConfiguration(IConfiguration configuration, string connectionStringName)
        {
            var connectionString = configuration.GetConnectionString(connectionStringName);
            var providerName = configuration["ProviderName"];

            return new DefaultConnectionFactory(connectionString!, providerName!);
        }

        public async Task<DbConnection> OpenConnectionAsync(CancellationToken cancellationToken = default)
        {
            DbConnection connection = dbProviderFactory.CreateConnection()
               ?? throw new InvalidOperationException($"Failedd to create connection for provider {ProviderName}");

            connection.ConnectionString = ConnectionString;
            await connection.OpenAsync(cancellationToken);

            return connection;
        }
    }
}
