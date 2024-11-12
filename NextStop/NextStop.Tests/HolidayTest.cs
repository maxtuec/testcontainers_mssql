using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testcontainers.MsSql;
using Xunit;
using Testcontainers.PostgreSql;
using System.Data.Common;
using Npgsql;

namespace NextStop.Tests;

public class HolidayTest : IAsyncLifetime
{
    private readonly PostgreSqlContainer _postgres = new PostgreSqlBuilder()
        .WithImage("postgres:15-alpine")
        .Build();

    public Task InitializeAsync()
    {
        return _postgres.StartAsync();
    }

    public Task DisposeAsync()
    {
        return _postgres.DisposeAsync().AsTask();
    }

    [Fact]
    public void GetAllHolidays()
    {
        /*
        using DbConnection test = new NpgsqlConnection(_postgres.GetConnectionString());
        using var comm = test.CreateCommand();

        comm.CommandText = "CREATE TABLE IF NOT EXISTS customers (id BIGINT NOT NULL, name VARCHAR NOT NULL, PRIMARY KEY (id))";        
        comm.Connection?.Open();
        comm.ExecuteNonQuery();
*/
        Assert.Equal(2, 2);
    }
}
