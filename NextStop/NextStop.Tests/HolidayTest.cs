using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Testcontainers.PostgreSql;
using System.Data.Common;
using Microsoft.Extensions.Configuration;
using NextStop.Dal.Common;
using Npgsql;

namespace NextStop.Tests;

public class HolidayTest : IAsyncLifetime
{
    private readonly PostgreSqlContainer _postgres = new PostgreSqlBuilder()
        .WithImage("postgres:15-alpine")
        .WithDatabase("testdb")         // Set the database name
        .WithUsername("testuser")       // Set the username
        .WithPassword("testpassword")   // Set the password
        .Build();

    private NpgsqlConnection _connection;

    public async Task InitializeAsync()
    {
        // Start the PostgreSQL container
        await _postgres.StartAsync();

        // Set up the connection string
        var connectionString = _postgres.GetConnectionString();

        // Establish a connection to the database
        _connection = new NpgsqlConnection(connectionString);
        await _connection.OpenAsync();

        // Run the SQL script to create the necessary table
        await CreateTableAsync();
    }

    private async Task CreateTableAsync()
    {
        var createTableScript = @"
            CREATE TABLE IF NOT EXISTS holidays (
                id SERIAL PRIMARY KEY,
                name VARCHAR(100) NOT NULL,
                date DATE NOT NULL
            );
        ";

        using var command = new NpgsqlCommand(createTableScript, _connection);
        await command.ExecuteNonQueryAsync();
    }

    public async Task DisposeAsync()
    {
        await _connection.CloseAsync();
        await _postgres.DisposeAsync().AsTask();
    }

    [Fact]
    public void GetAllHolidays()
    {
        /*
        
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var connectionFactory = DefaultConnectionFactory.FromConfiguration(configuration, "NextStopDbConnection");

        CancellationTokenSource tokenSource = new CancellationTokenSource();
        */
        /*
        using DbConnection test = new NpgsqlConnection(_postgres.GetConnectionString());
        using var comm = test.CreateCommand();

        comm.CommandText = "CREATE TABLE IF NOT EXISTS customers (id BIGINT NOT NULL, name VARCHAR NOT NULL, PRIMARY KEY (id))";        
        comm.Connection?.Open();
        comm.ExecuteNonQuery();
*/
        Assert.Equal(1, 2);
    }
}
