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

    public async Task InitializeAsync()
    {
        // Start the PostgreSQL container
        await _postgres.StartAsync();

        // Set up the connection string
        var connectionString = _postgres.GetConnectionString();

        // Establish a connection to the database
        NpgsqlConnection _connection = new NpgsqlConnection(connectionString);
        await _connection.OpenAsync();

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
    public async Task GetAllHolidays()
    {
        var connectionString = _postgres.GetConnectionString();
        NpgsqlConnection _connection = new NpgsqlConnection(connectionString);
        await _connection.OpenAsync();

        // SQL query to select all entries from the holidays table
        var selectAllQuery = "SELECT COUNT(*) FROM holidays;";

        // Execute the query and retrieve the result
        using var command = new NpgsqlCommand(selectAllQuery, _connection);
        var count = (long)await command.ExecuteScalarAsync();

        // Assert that the count is zero (no entries in the holidays table)
        Assert.Equal(0, count);
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
        
        // Assert.Equal(2, 2);
    }
}
